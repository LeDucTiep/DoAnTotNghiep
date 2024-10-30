<template>
  <div class="product-view-container d-flex">
    <div class="bo-loc">
      <div class="total">175 sản phẩm</div>
      <div class="name">Bộ lọc</div>
      <div class="gender">
        <div class="title">Giới tính</div>
        <div class="col">
          <TCheckbox
            v-for="(item, index) in genderFilters"
            :key="index"
            v-model="item.value"
            @change="onChangeGenderFilter()"
          >
            {{ item.name }}
          </TCheckbox>
        </div>
      </div>
    </div>

    <div class="products-list">
      <div class="products f-row f-wrap">
        <ProductSP
          v-for="(item, index) in products"
          :key="index"
          :name="item.name"
          class="w-25"
        ></ProductSP>
      </div>
    </div>
  </div>
</template>

<script>
import ProductSP from "/src/components/cloth/ProductSP.vue";
import TCheckbox from "/src/base/checkbox/TCheckbox.vue";
export default {
  name: "ProductsView",
  props: {},
  components: {
    ProductSP,
    TCheckbox,
  },
  data() {
    return {
      genderFilters: [
        {
          name: "Nữ",
          value: false,
        },
        {
          name: "Nam",
          value: false,
        },
        {
          name: "Unisex",
          value: false,
        },
      ],
      products: [
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
        {},
      ],
    };
  },
  methods: {
    onChangeGenderFilter() {
      console.log("Genders changed");
    },
  },
};
</script>

<style lang="scss">
@import "/src/base/style/style.scss";
@import "./ProductsView.scss";
</style>
