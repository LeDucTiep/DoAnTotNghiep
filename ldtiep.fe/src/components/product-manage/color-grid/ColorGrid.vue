<template>
  <div class="table-head">
    <div class="add-button">Thêm mới</div>
  </div>
  <div class="table-data">
    <ag-grid-vue
      :rowData="rowData"
      :columnDefs="colDefs"
      :rowSelection="rowSelection"
      :onSelectionChanged="onSelectionChanged"
      style="height: 500px"
      class="ag-theme-quartz"
    >
    </ag-grid-vue>
  </div>
</template>
    
<script>
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the Data Grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid
import { AgGridVue } from "ag-grid-vue3";
import EditProductButton from "/src/components/product-manage/button-edit/EditProductButton.vue";

export default {
  name: "ColorGrid",
  props: [],
  components: {
    AgGridVue,
  },
  data() {
    return {
      rowData: [
        {
          ColorID: 123,
          ColorName: "Áo Khoác Gió Thông Minh Nữ Trượt Nước",
        },
      ],
      colDefs: [
        { field: "ColorName", width: 420 },
        { field: "ColorID", cellRenderer: EditProductButton },
      ],
      rowSelection: {
        mode: "multiRow",
      },
    };
  },
  beforeMount() {},
  methods: {},
};
</script>
    
    <style  lang="scss">
</style>
    