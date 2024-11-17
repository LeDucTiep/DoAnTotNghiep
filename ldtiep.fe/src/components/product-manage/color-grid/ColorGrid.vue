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
      };
      const res = await this.api.paging(param);

      this.rowData = res.Data;
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
    async addColor() {
      if (!(await this.validateColor())) {
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

      const ids = this.rowSelected.map((e) => e.data.ColorID);

      await this.api.deleteMany(ids);

      this.getData();
    },
    showAddForm() {
      this.isShowAdd = true;
      this.addFormData = {};
      this.isExistsColor = false;
    },
    isValidHexColor(hexColor) {
      const regex = /^#([0-9A-F]{3}|[0-9A-F]{6})$/i;
      return regex.test(hexColor);
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
</style>
    