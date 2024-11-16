<template>
  <div class="table-head">
    <div class="add-button" @click="showAddForm()">Thêm mới</div>
  </div>
  <div class="table-data">
    <ag-grid-vue
      v-if="rowData.length > 0"
      :rowData="rowData"
      :columnDefs="colDefs"
      :rowSelection="rowSelection"
      :onSelectionChanged="onSelectionChanged"
      style="height: 500px"
      class="ag-theme-quartz"
    >
    </ag-grid-vue>
    <div v-else class="nodata-img flex-center">
      <img
        style="height: 500px"
        src="../../../assets/images/nodata.png"
        alt="Không có dữ liệu"
      />
    </div>
  </div>

  <vs-popup
    v-if="isShowAdd"
    title="Thêm mới màu sắc"
    v-model:active="isShowAdd"
  >
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <vs-input
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
</template>
    
<script>
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the Data Grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid
import { AgGridVue } from "ag-grid-vue3";
import EditColorButton from "/src/components/product-manage/button-edit/EditColorButton.vue";
import API from "/src/service/api.js";
import ColorComponent from "./ColorComponent";

export default {
  name: "ColorGrid",
  props: [],
  components: {
    AgGridVue,
  },
  data() {
    return {
      api: new API("Colors"),
      rowData: [],
      colDefs: [
        { field: "ColorName", headerName: "Tên màu", width: 520 },
        {
          field: "ColorCode",
          headerName: "Mã màu",
          width: 320,
          cellRenderer: ColorComponent,
        },
        {
          field: "ColorID",
          headerName: "",
          cellRenderer: EditColorButton,
          cellRendererParams: {
            action: this.getData,
          },
        },
      ],
      rowSelection: {
        mode: "multiRow",
      },
      addFormData: {},
      isShowAdd: false,
    };
  },
  created() {
    this.getData();
  },
  beforeMount() {},
  methods: {
    async getData() {
      const param = {
        PageSize: 1,
        PageNumber: 1,
      };
      const res = await this.api.paging(param);

      this.rowData = res.Data;
    },
    async addColor() {
      if (!this.isValidHexColor(this.addFormData.ColorCode)) {
        return;
      }
      await this.api.add(this.addFormData);

      this.getData();
    },
    showAddForm() {
      this.isShowAdd = true;
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
</style>
    