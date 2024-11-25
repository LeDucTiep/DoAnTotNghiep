<template>
  <div class="admin-container">
    <div class="tabbar">
      <div class="left">
        <div
          v-for="(item, index) in tabs"
          :key="index"
          :class="{ 'tab-content--active': index == currentTab }"
          class="tab-content"
          @click="onChangeTab(index)"
        >
          {{ item.name }}
        </div>
      </div>
      <div v-if="currentTab == 0" class="right">
        <ProductGrid></ProductGrid>
      </div>
      <div v-if="currentTab == 1" class="right">
        <ColorGrid></ColorGrid>
      </div>
      <div v-if="currentTab == 2" class="right">
        <SizeGrid></SizeGrid>
      </div>
      <div v-if="currentTab == 3" class="right">
        <CategoryGrid></CategoryGrid>
      </div>
      <div v-if="currentTab == 4" class="right">
        <OrderGrid></OrderGrid>
      </div>
    </div>
  </div>
</template>
  
  <script>
import ProductGrid from "./product-grid/ProductGrid.vue";
import ColorGrid from "./color-grid/ColorGrid.vue";
import CategoryGrid from "./category-grid/CategoryGrid.vue";
import OrderGrid from "./order-grid/OrderGrid.vue";
import SizeGrid from "./size-grid/SizeGrid.vue";

export default {
  name: "ProductManage",
  props: {},
  components: {
    ProductGrid,
    SizeGrid,
    ColorGrid,
    CategoryGrid,
    OrderGrid,
  },
  data() {
    return {
      currentTab: 1,
      tabs: [
        {
          id: 0,
          name: "Sản phẩm",
        },
        {
          id: 1,
          name: "Màu sắc",
        },
        {
          id: 2,
          name: "Kích thước",
        },
        {
          id: 3,
          name: "Thể loại",
        },
        {
          id: 4,
          name: "Đơn hàng",
        },
      ],
    };
  },
  created() {
    this.currentTab = localStorage.getItem("currentAdminTabId") || 0;
  },
  methods: {
    onChangeTab(e) {
      const me = this;
      me.currentTab = e;
      localStorage.setItem("currentAdminTabId", me.currentTab);
    },
  },
};
</script>
  
  <style lang="scss">
@import "./ProductManage.scss";
</style>
  