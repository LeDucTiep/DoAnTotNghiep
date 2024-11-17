<template>
  <div class="table-head">
    <div class="util-buttons">
      <vs-button
        v-if="rowSelected.length > 0"
        @click="deleteSelected()"
        color="danger"
        type="filled"
        >Xóa kích thước đã chọn</vs-button
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

  <vs-popup title="Thêm mới kích thước" v-model:active="isShowAdd">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <vs-input
            :danger="isExistsSize"
            danger-text="Kích thước này đã tồn tại"
            label="Tên kích thước"
            placeholder="XL"
            v-model="addFormData.SizeName"
          />
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="addSize()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa sản phẩm" v-model:active="isShowPopupDelete">
    <div class="popup-content">
      <div class="content">
        Bạn có chắc chắn muốn xóa các kích thước đã chọn?
      </div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa sản phẩm" v-model:active="isShowPopupDeleteOne">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa kích thước này?</div>
      <div class="buttons">
        <vs-button @click="confirmDeleteOne()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Chỉnh sửa kích thước" v-model:active="isShowPopupEdit">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <vs-input
            label="Tên kích thước"
            placeholder="XL"
            v-model="itemData.SizeName"
          />
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
  name: "SizeGrid",
  props: [],
  components: {},
  data() {
    return {
      isExistsSize: false,
      api: new API("Sizes"),
      rowData: [],
      columns: [
        { field: "SizeName", name: "Tên kích thước" },
        {
          field: "SizeID",
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
    };
  },
  created() {
    this.getData();
  },
  beforeMount() {},
  methods: {
    async getData() {
      const param = {
        PageSize: 500,
        PageNumber: 1,
        Sorter: {
          ModifiedDate: "desc",
        },
      };
      const res = await this.api.paging(param);
      this.rowData = res.Data;

      this.rowSelected = [];
    },
    async validateSize() {
      const param = {
        SizeName: this.addFormData.SizeName,
      };

      const res = await this.api.checkExisted(param);

      this.isExistsSize = res;

      return !res;
    },
    async validateEditSize() {
      const param = {
        SizeName: this.itemData.SizeName,
      };

      const res = await this.api.checkExisted(param);

      this.isExistsSize = res;

      return !res;
    },
    async addSize() {
      if (!(await this.validateSize())) {
        return;
      }
      this.isShowAdd = false;

      await this.api.add(this.addFormData);

      this.getData();
    },
    async deleteSelected() {
      this.isShowPopupDelete = true;
    },
    async confirmDelete() {
      this.isShowPopupDelete = false;

      const ids = this.rowSelected.map((e) => e.SizeID);

      await this.api.deleteMany(ids);

      this.getData();
    },
    showAddForm() {
      this.isShowAdd = true;
      this.addFormData = {};
      this.isExistsSize = false;
    },
    async onEdit(e) {
      this.itemData = { ...e };

      this.isShowPopupEdit = true;
    },
    onDelete(e) {
      this.deletingID = e.SizeID;

      this.isShowPopupDeleteOne = true;
    },
    async confirmDeleteOne() {
      this.isShowPopupDeleteOne = false;
      console.log(this.deletingID);
      await this.api.deleteByID(this.deletingID);

      this.getData();
    },
    async confirmEdit() {
      if (!this.validateEditSize()) return;

      await this.api.updateByID(this.itemData.SizeID, this.itemData);

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
    