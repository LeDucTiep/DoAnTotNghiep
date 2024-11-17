<template>
  <div class="table-head">
    <div class="util-buttons">
      <vs-button
        v-if="rowSelected.length > 0"
        @click="deleteSelected()"
        color="danger"
        type="filled"
        >Xóa màu đã chọn</vs-button
      >
    </div>
    <div class="add-button">
      <vs-button @click="showAddForm()" color="primary" type="filled"
        >Thêm mới</vs-button
      >
    </div>
  </div>
  <div class="table-data">
    <TGrid
      v-if="rowData.length > 0"
      :columns="columns"
      :dataSource="rowData"
      @edit="onEdit($event)"
      @delete="onDelete($event)"
      @sort="onSort($event)"
      @changePage="onChangePage($event)"
      v-model="rowSelected"
    ></TGrid>
    <div v-else class="nodata-img flex-center">
      <img
        style="height: 500px"
        src="../../../assets/images/nodata.png"
        alt="Không có dữ liệu"
      />
    </div>
  </div>

  <vs-popup title="Thêm mới màu sắc" v-model:active="isShowAdd">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <vs-input
            :danger="isExistsColor"
            danger-text="Màu sắc này đã tồn tại"
            label="Tên màu"
            placeholder="Hồng cánh sen"
            v-model="addFormData.ColorName"
          />
        </div>
        <div class="color-row">
          <vs-input
            label="Mã màu"
            placeholder="#ffffff"
            v-model="addFormData.ColorCode"
          />
          <pick-colors v-model:value="addFormData.ColorCode" />
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="addColor()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa sản phẩm" v-model:active="isShowPopupDelete">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa các màu sắc đã chọn?</div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa sản phẩm" v-model:active="isShowPopupDeleteOne">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa màu sắc này?</div>
      <div class="buttons">
        <vs-button @click="confirmDeleteOne()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Chỉnh sửa màu sắc" v-model:active="isShowPopupEdit">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <vs-input
            label="Tên màu"
            placeholder="Hồng cánh sen"
            v-model="itemData.ColorName"
          />
        </div>
        <div class="color-row">
          <vs-input
            label="Mã màu"
            placeholder="#ffffff"
            v-model="itemData.ColorCode"
          />
          <pick-colors v-model:value="itemData.ColorCode" />
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="confirmEdit()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>
    
<script>
import API from "/src/service/api.js";
export default {
  name: "ColorGrid",
  props: [],
  components: {},
  data() {
    return {
      isExistsColor: false,
      api: new API("Colors"),
      rowData: [],
      columns: [
        { field: "ColorName", name: "Tên màu" },
        {
          field: "ColorCode",
          name: "Mã màu",
          type: 2,
        },
        {
          field: "ColorID",
          type: 1,
        },
      ],
      addFormData: {},
      isShowAdd: false,
      rowSelected: [],
      isShowPopupDelete: false,
      deletingID: {},
      isShowPopupDeleteOne: false,
      isShowPopupEdit: false,
      itemData: {},
      currentSort: {
        ModifiedDate: "desc",
      },
      pageIndex: 1,
    };
  },
  created() {
    this.getData();
  },
  beforeMount() {},
  methods: {
    onSort(e) {
      this.currentSort = e;
      this.getData();
    },
    onChangePage(e) {
      this.pageIndex = e;
      this.getData();
    },
    async getData() {
      const param = {
        PageSize: 100,
        PageNumber: this.pageIndex,
        Sorter: this.currentSort,
      };
      const res = await this.api.paging(param);

      this.rowData = res.Data;

      this.rowSelected = [];
    },
    async validateColor() {
      if (!this.isValidHexColor(this.addFormData.ColorCode)) {
        return false;
      }

      const param = {
        ColorName: this.addFormData.ColorName,
      };

      const res = await this.api.checkExisted(param);

      this.isExistsColor = res;

      return !res;
    },
    async validateEditColor() {
      if (!this.isValidHexColor(this.itemData.ColorCode)) {
        return false;
      }

      const param = {
        ColorName: this.itemData.ColorName,
      };

      const res = await this.api.checkExisted(param);

      this.isExistsColor = res;

      return !res;
    },
    async addColor() {
      if (!(await this.validateColor())) {
        return;
      }
      this.isShowAdd = false;

      if (!this.addFormData.ColorCode) this.addFormData.ColorCode = "";

      await this.api.add(this.addFormData);

      this.getData();
    },
    async deleteSelected() {
      this.isShowPopupDelete = true;
    },
    async confirmDelete() {
      this.isShowPopupDelete = false;

      const ids = this.rowSelected.map((e) => e.ColorID);

      await this.api.deleteMany(ids);

      this.getData();
    },
    showAddForm() {
      this.isShowAdd = true;
      this.addFormData = {};
      this.isExistsColor = false;
    },
    isValidHexColor(hexColor) {
      if (hexColor == null || hexColor == "") return true;

      const regex = /^#([0-9A-F]{3}|[0-9A-F]{6})$/i;
      return regex.test(hexColor);
    },
    async onEdit(e) {
      this.itemData = { ...e };

      this.isShowPopupEdit = true;
    },
    onDelete(e) {
      this.deletingID = e.ColorID;

      this.isShowPopupDeleteOne = true;
    },
    async confirmDeleteOne() {
      this.isShowPopupDeleteOne = false;
      console.log(this.deletingID);
      await this.api.deleteByID(this.deletingID);

      this.getData();
    },
    async confirmEdit() {
      if (!this.validateEditColor()) return;

      if (!this.itemData.ColorCode) this.itemData.ColorCode = "";

      await this.api.updateByID(this.itemData.ColorID, this.itemData);

      this.isShowPopupEdit = false;

      this.getData();
    },
  },
};
</script>
    
    <style  lang="scss">
.color-row {
  display: flex;
  align-items: end;
}
.add-form {
  display: flex;
  flex-direction: column;
  gap: 12px;
}
.menu-table-buttons {
  display: flex;
  gap: 10px;
  height: 100%;
  align-items: center;

  .edit-product-button {
    background-color: #94ffffff;
    &:hover {
      background-color: #d0ffffff;
    }
  }
  .delete-product-button {
    background-color: #ffa68bff;
    &:hover {
      background-color: #ffd4c7ff;
    }
  }
}
.edit-product-button,
.delete-product-button {
  border-radius: 10px;
  width: 50%;
  border: 1px solid #ccc;
  height: 30px;
  padding: 0px;
  margin: 0px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  margin-top: 5px;
}
.popup-content {
  .content {
    font-size: 16px;
  }
  .buttons {
    display: flex;
    justify-content: end;
    align-items: center;
  }
}
.product-image {
  position: relative;
  width: fit-content;
  &:hover {
    opacity: 0.5;
  }
  .icon-camara {
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    user-select: none;
    right: 0;
    bottom: 0;
    display: flex;
    align-items: center;
    justify-content: center;
  }
  img {
    max-height: 200px;
    cursor: pointer;
    border-radius: 10px;
    max-width: 200px;
  }
}
.edit-form {
  display: flex;

  .form-right {
    padding: 0px 10px;
    width: 100%;

    .vs-con-input {
      width: 400px;
    }
  }
}
.h-10 {
  height: 10px;
}
.gender {
  .title {
    padding-left: 5px;
    margin-bottom: 4px;
  }
  .options {
    display: flex;
    justify-content: start;
    align-items: center;
    gap: 10px;
    margin-bottom: 5px;

    .vs-checkbox--icon {
      height: 18px;
      width: 18px;
    }
  }
}
</style>
    