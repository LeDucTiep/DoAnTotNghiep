<template>
  <div class="table-head">
    <div class="add-button">Thêm mới</div>
  </div>
  <div class="table-data">
    <TGrid
      v-if="rowData.length > 0"
      :columns="columns"
      :dataSource="rowData"
      @edit="onEdit($event)"
      @delete="onDelete($event)"
      v-model="selected"
    ></TGrid>
    <div v-else class="nodata-img flex-center">
      <img
        style="height: 500px"
        src="../../../assets/images/nodata.png"
        alt="Không có dữ liệu"
      />
    </div>
  </div>
</template>
    
<script>
import EditProductButton from "/src/components/product-manage/button-edit/EditProductButton.vue";

export default {
  name: "ProductGrid",
  props: [],
  components: {},
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
      columns: [
        { field: "name", width: 420 },
        { field: "price" },
        { field: "original_price" },
        { field: "discount" },
        { field: "product_id", cellRenderer: EditProductButton },
      ],
      selected: [],
    };
  },
  beforeMount() {},
  methods: {},
};
</script>
    
    <style  lang="scss">
</style>
    