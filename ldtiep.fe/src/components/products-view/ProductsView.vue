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
            @change="onChangeFilter()"
          >
            {{ item.name }}
          </TCheckbox>
        </div>
      </div>
      <div class="colors">
        <div class="title">Màu sắc</div>
        <div class="col">
          <TColorCheck
            v-for="(item, index) in Colors"
            :key="index"
            :cusclass="'color'"
            :code="item.ColorCode"
            :name="item.ColorName"
            v-model="item.IsChecked"
            @change="onChangeColors()"
          >
          </TColorCheck>
        </div>
      </div>
      <div class="sizes">
        <div class="title">Kích thước</div>
        <div class="col">
          <TSizeCheck
            v-for="(item, index) in sizes"
            :key="index"
            :cusclass="'size'"
            v-model="item.value"
            @change="onChangeFilter()"
          >
            {{ item.name }}
          </TSizeCheck>
        </div>
      </div>

      <div class="by-cost">
        <div class="title">Theo giá</div>
        <div class="col">
          <TCheckbox
            v-for="(item, index) in costFilters"
            :key="index"
            v-model="item.value"
            @change="onChangeFilter()"
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
import API from "/src/service/api.js";
import TCheckbox from "/src/base/checkbox/TCheckbox.vue";
import TColorCheck from "/src/base/checkbox/TColorCheck.vue";
import TSizeCheck from "/src/base/checkbox/TSizeCheck.vue";
export default {
  name: "ProductsView",
  props: {},
  components: {
    ProductSP,
    TCheckbox,
    TColorCheck,
    TSizeCheck,
  },
  data() {
    return {
      Colors: [],
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
      costFilters: [
        {
          name: "Dưới 350.000đ",
          value: false,
        },
        {
          name: "Từ 350.000đ - 750.000đ",
          value: false,
        },
        {
          name: "Trên 750.000đ",
          value: false,
        },
      ],
      ColorApi: new API("Colors"),
      sizes: [
        { value: false, name: "S" },
        { value: false, name: "M" },
        { value: false, name: "L" },
        { value: false, name: "XL" },
        { value: false, name: "2XL" },
        { value: false, name: "3XL" },
        { value: false, name: "3XL" },
        { value: false, name: "4XL" },
        { value: false, name: "5XL" },
        { value: false, name: "F" },
        { value: false, name: "XXX" },
        { value: false, name: "0" },
        { value: false, name: "1" },
        { value: false, name: "2" },
        { value: false, name: "3" },
        { value: false, name: "4" },
        { value: false, name: "27" },
        { value: false, name: "28" },
        { value: false, name: "29" },
        { value: false, name: "30" },
        { value: false, name: "31" },
        { value: false, name: "32" },
        { value: false, name: "33" },
        { value: false, name: "34" },
        { value: false, name: "35" },
        { value: false, name: "36" },
        { value: false, name: "38" },
        { value: false, name: "39" },
        { value: false, name: "40" },
        { value: false, name: "41" },
        { value: false, name: "42" },
        { value: false, name: "43" },
        { value: false, name: "44" },
        { value: false, name: "110" },
        { value: false, name: "115" },
        { value: false, name: "120" },
        { value: false, name: "125" },
        { value: false, name: "130" },
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
  created() {
    this.getColors();
  },
  methods: {
    onChangeFilter() {
      console.log("Genders changed");
    },
    onChangeColors() {},

    async getColors() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: {
          ModifiedDate: "desc",
        },
      };

      const res = await this.ColorApi.paging(param);

      this.Colors = res.Data;
    },
  },
};
</script>

<style lang="scss">
@import "./ProductsView.scss";
</style>
