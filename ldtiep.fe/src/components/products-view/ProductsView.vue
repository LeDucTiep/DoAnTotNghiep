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
      <div class="colors">
        <div class="title">Màu sắc</div>
        <div class="col">
          <TColorCheck
            v-for="(item, index) in colorFilters"
            :key="index"
            :cusclass="'color'"
            :id="item.id"
            v-model="item.value"
          >
          </TColorCheck>
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
import TColorCheck from "/src/base/checkbox/TColorCheck.vue";
export default {
  name: "ProductsView",
  props: {},
  components: {
    ProductSP,
    TCheckbox,
    TColorCheck,
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
      colorFilters: [
        {
          id: 1,
          value: false,
        },
        {
          id: 2,
          value: false,
        },
        {
          id: 3,
          value: false,
        },
        {
          id: 4,
          value: false,
        },
        {
          id: 5,
          value: false,
        },
        {
          id: 6,
          value: false,
        },
        {
          id: 7,
          value: false,
        },
        {
          id: 8,
          value: false,
        },
        {
          id: 9,
          value: false,
        },
        {
          id: 10,
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
