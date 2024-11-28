<template>
  <div class="table-head">
    <div class="util-buttons">
      <vs-button
        v-if="rowSelected.length > 0"
        @click="deleteSelected()"
        color="danger"
        type="filled"
        >Xóa nhân viên đã chọn</vs-button
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

  <vs-popup title="Thêm nhân viên" v-model:active="isShowAdd">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row flex-col">
          <vs-input
            :danger="!addFormData.EmployeeName && isValidating"
            danger-text="Tên nhân viên không được để trống"
            label="Tên nhân viên"
            placeholder="Lê Đức Tiệp"
            v-model="addFormData.EmployeeName"
          />
          <div class="h-10"></div>
          <vs-input
            :danger="
              (!addFormData.EmployeeCode || isExistsCode) && isValidating
            "
            danger-text="Mã nhân viên không được để trống"
            label="Mã nhân viên"
            placeholder="NV001"
            v-model="addFormData.EmployeeCode"
          />
          <div class="h-10"></div>

          <div class="title-rule">Phân quyền</div>

          <div class="rules d-flex">
            <div
              class="rule-block flex-center gap-10 pb10"
              v-for="(item, index) in [
                { id: 'san-pham', name: 'Sản phẩm' },
                { id: 'mau-sac', name: 'Màu sắc' },
                { id: 'kich-thuoc', name: 'Kích thước' },
                { id: 'the-loai', name: 'Thể loại' },
                { id: 'don-hang', name: 'Đơn hàng' },
                { id: 'nhan-vien', name: 'Nhân viên' },
              ]"
              :key="index"
            >
              <vs-switch
                vs-type="success"
                v-model="rulesAdd"
                :vs-value="item.id"
              ></vs-switch>
              {{ item.name }}
            </div>
          </div>
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="confirmAdd()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa nhân viên" v-model:active="isShowPopupDelete">
    <div class="popup-content">
      <div class="content">
        Bạn có chắc chắn muốn xóa các nhân viên đã chọn?
      </div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa nhân viên" v-model:active="isShowPopupDeleteOne">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa nhân viên này?</div>
      <div class="buttons">
        <vs-button @click="confirmDeleteOne()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Chỉnh sửa nhân viên" v-model:active="isShowPopupEdit">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row flex-col">
          <vs-input
            :danger="!itemData.EmployeeName && isValidating"
            danger-text="Tên nhân viên không được để trống"
            label="Tên nhân viên"
            placeholder="Lê Đức Tiệp"
            v-model="itemData.EmployeeName"
          />
          <div class="h-10"></div>
          <vs-input
            :danger="(!itemData.EmployeeCode || isExistsCode) && isValidating"
            danger-text="Mã nhân viên không được để trống"
            label="Mã nhân viên"
            placeholder="NV001"
            v-model="itemData.EmployeeCode"
          />
          <div class="h-10"></div>

          <div class="title-rule">Phân quyền</div>

          <div class="rules d-flex">
            <div
              class="rule-block flex-center gap-10 pb10"
              v-for="(item, index) in [
                { id: 'san-pham', name: 'Sản phẩm' },
                { id: 'mau-sac', name: 'Màu sắc' },
                { id: 'kich-thuoc', name: 'Kích thước' },
                { id: 'the-loai', name: 'Thể loại' },
                { id: 'don-hang', name: 'Đơn hàng' },
              ]"
              :key="index"
            >
              <vs-switch
                vs-type="success"
                v-model="rulesEdit"
                :vs-value="item.id"
              ></vs-switch>
              {{ item.name }}
            </div>
          </div>
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
  name: "EmployeeGrid",
  props: [],
  components: {},
  data() {
    return {
      isValidating: false,
      api: new API("Employees"),
      rowData: [],
      columns: [
        { field: "EmployeeName", name: "Tên nhân viên" },
        { field: "EmployeeCode", name: "Mã nhân viên" },
        {
          field: "EmployeeID",
          type: 1,
        },
      ],
      addFormData: {},
      rulesAdd: [],
      rulesEdit: [],
      isShowAdd: false,
      rowSelected: [],
      isShowPopupDelete: false,
      deletingID: {},
      isShowPopupDeleteOne: false,
      isShowPopupEdit: false,
      itemData: {},
      pageIndex: 1,
      currentSort: {
        ModifiedDate: "desc",
      },
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
        SearchEquals: {
          TypeAccount: 0,
        },
      };
      const res = await this.api.paging(param);
      this.rowData = res.Data;

      this.rowSelected = [];
    },
    async validateEmployee() {
      this.isValidating = true;

      const isNotEmpty =
        this.addFormData.EmployeeName && this.addFormData.EmployeeCode;

      if (!isNotEmpty) return false;

      const param = {
        EmployeeCode: this.addFormData.EmployeeCode,
      };

      const res = await this.api.checkExisted(param);

      this.isExistsCode = res;

      return isNotEmpty && !this.isExistsCode;
    },
    async validateEditEmployee() {
      this.isValidating = true;

      const isNotEmpty =
        this.addFormData.EmployeeName && this.addFormData.EmployeeCode;

      if (!isNotEmpty) return false;

      const emp = await this.api.byID(this.addFormData.EmployeeID);
      const old = emp.EmployeeCode;

      const param = {
        EmployeeCode: this.addFormData.EmployeeCode,
      };

      const res = await this.api.checkExisted(param);

      this.isExistsCode = res && old != this.addFormData.EmployeeCode;

      return isNotEmpty && !this.isExistsCode;
    },
    async confirmAdd() {
      if (!(await this.validateEmployee())) {
        return;
      }
      this.isShowAdd = false;

      const employee = {
        ...this.addFormData,
        Rules: JSON.stringify(this.rulesAdd),
      };

      await this.api.add(employee);

      this.getData();
    },
    async deleteSelected() {
      this.isShowPopupDelete = true;
    },
    async confirmDelete() {
      this.isShowPopupDelete = false;

      const ids = this.rowSelected.map((e) => e.EmployeeID);

      await this.api.deleteMany(ids);

      this.getData();
    },
    async showAddForm() {
      this.isShowAdd = true;
      this.addFormData = {};
      this.rulesAdd = [];

      const code = await this.api.genCode();

      this.addFormData.EmployeeCode = code;
    },
    async onEdit(e) {
      this.rulesEdit = JSON.parse(e.Rules);
      this.itemData = { ...e };
      this.isShowPopupEdit = true;
    },
    onDelete(e) {
      this.deletingID = e.EmployeeID;

      this.isShowPopupDeleteOne = true;
    },
    async confirmDeleteOne() {
      this.isShowPopupDeleteOne = false;

      await this.api.deleteByID(this.deletingID);

      this.getData();
    },
    async confirmEdit() {
      if (!this.validateEditEmployee()) return;

      const employee = {
        ...this.itemData,
        Rules: JSON.stringify(this.rulesEdit),
      };

      await this.api.updateByID(this.itemData.EmployeeID, employee);

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

.flex-col {
  display: flex;
  flex-direction: column;
}

.title-rule {
  font-size: 16px;
}

.rules {
  flex-direction: column;
  justify-content: start;
  align-items: start;
  .vs-checkbox--check {
    scale: 0.8;
    padding: 0;

    i.vs-checkbox--icon {
      width: 13px;
      height: 17px;
      margin: 0;
      padding: 0;
    }
  }
}
.rule-block {
  display: flex;
}
.pb10 {
  padding-top: 10px;
}
</style>
    