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
        <CategoryGrid></CategoryGrid>
      </div>
    </div>
  </div>
</template>
  
  <script>
import ProductGrid from "./product-grid/ProductGrid.vue";
import ColorGrid from "./color-grid/ColorGrid.vue";
import CategoryGrid from "./category-grid/CategoryGrid.vue";

export default {
  name: "ProductManage",
  props: {},
  components: {
    ProductGrid,

    ColorGrid,
    CategoryGrid,
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
          name: "Thể loại",
        },
      ],
    };
  },
  methods: {
    onSelectionChanged(e) {
      const selected = e.api.getSelectedNodes();

      console.log(selected);
    },
    onChangeTab(e) {
      const me = this;
      me.currentTab = e;
    },
  },
};
</script>
  
  <style lang="scss">
@import "./ProductManage.scss";
</style>
  