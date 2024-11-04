<template>
  <div class="admin-container">
    <div class="tabbar">
      <div class="left">
        <div class="tab-content tab-content--active">Quản lý sản phẩm</div>
      </div>
      <div class="right">
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
      </div>
    </div>
  </div>
</template>
  
  <script>
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the Data Grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the Data Grid
import { AgGridVue } from "ag-grid-vue3";
import EditProductButton from "/src/components/product-manage/button-edit/EditProductButton.vue";

export default {
  name: "ProductsManage",
  props: {},
  components: {
    AgGridVue,
  },
  data() {
    return {
      rowData: [
        {
          product_id: 123,
          name: "Áo Khoác Gió Thông Minh Nữ Trượt Nước",
          image:
            "https://m.yodycdn.com/fit-in/filters:format(webp)/products/akn5042-den-4.jpg",
          price: 569050,
          original_price: 599000,
          discount: 5,
          category: [],
          size: [],
          color: [],
        },
      ],
      colDefs: [
        { field: "name", width: 420 },
        { field: "price" },
        { field: "original_price" },
        { field: "discount" },
        { field: "product_id", cellRenderer: EditProductButton },
      ],
      rowSelection: {
        mode: "multiRow",
      },
    };
  },
  methods: {
    onSelectionChanged(e) {
      const selected = e.api.getSelectedNodes();

      console.log(selected);
    },
  },
};
</script>
  
  <style lang="scss">
@import "./ProductManage.scss";
</style>
  