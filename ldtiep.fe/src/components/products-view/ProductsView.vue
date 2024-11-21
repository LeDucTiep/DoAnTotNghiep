<template>
  <div class="product-view-container d-flex">
    <div class="bo-loc">
      <div class="total">{{ total }} sản phẩm</div>
      <div class="name">Bộ lọc</div>
      <div class="gender">
        <div class="title">Giới tính</div>
        <div class="col">
          <TCheckbox
            v-for="(item, index) in [
              {
                name: 'Nữ',
                value: 1,
              },
              {
                name: 'Nam',
                value: 0,
              },
              {
                name: 'Trẻ em',
                value: 2,
              },
            ]"
            :key="index"
            v-model="CategoryFilter[item.value]"
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
            v-model="ColorFilter[item.ColorID]"
            @change="onChangeFilter()"
          >
          </TColorCheck>
        </div>
      </div>
      <div class="sizes">
        <div class="title">Kích thước</div>
        <div class="col">
          <TSizeCheck
            v-for="(item, index) in Sizes"
            :key="index"
            :cusclass="'size'"
            v-model="SizeFilter[item.SizeID]"
            @change="onChangeFilter()"
          >
            {{ item.SizeName }}
          </TSizeCheck>
        </div>
      </div>

      <div class="by-cost">
        <div class="title">Theo giá</div>
        <div class="col">
          <TCheckbox
            v-for="(item, index) in [
              {
                name: 'Dưới 350.000đ',
                value: 0,
              },
              {
                name: 'Từ 350.000đ - 750.000đ',
                value: 1,
              },
              {
                name: 'Trên 750.000đ',
                value: 2,
              },
            ]"
            :key="index"
            v-model="CostFilter[item.value]"
            @change="onChangeFilter()"
          >
            {{ item.name }}
          </TCheckbox>
        </div>
      </div>
    </div>

    <div class="products-list">
      <div v-if="productDatas.length" class="products f-row f-wrap">
        <ProductSP
          v-for="(item, index) in productDatas"
          :key="index"
          :name="item.ProductName"
          :colors="item.ColorCodes.split(';')"
          :price="item.Price"
          :originalPrice="item.OriginalPrice"
          :discount="item.Discount"
          :pictureIds="item.PictureIDS"
          class="w-25"
        ></ProductSP>
      </div>
      <div v-else class="products empty-product-data">
        <div class="nodata-img flex-center">
          <img
            style="height: 500px"
            src="../../assets/images/nodata.png"
            alt="Không có dữ liệu"
          />
        </div>
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
import { inject } from "vue";
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
      vs: inject("$vs"),
      ColorApi: new API("Colors"),
      PictureApi: new API("Pictures"),
      SizeApi: new API("Sizes"),
      CateApi: new API("Categorys"),
      ProductApi: new API("Products"),
      SizeFilter: {},
      CategoryFilter: {},
      ColorFilter: {},
      CostFilter: {},
      Colors: [],
      Sizes: [],
      productDatas: [],
      total: 0,
    };
  },
  created() {
    this.getColors();
    this.getSizes();
    this.getProducts();

    console.log(this.$route);

    this.CategoryFilter[this.$route.query.CategoryType] = true;
  },
  watch: {
    "$route.query.CategoryType": function (val, oldVal) {
      if (val != oldVal) {
        this.CategoryFilter = {};
        this.CategoryFilter[val] = true;
      }
    },
    "$route.query.CategoryID": function (val, oldVal) {
      if (val != oldVal) {
        console.log(val);
      }
    },
  },
  methods: {
    async getProducts() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: {
          ModifiedDate: "asc",
        },
      };

      const res = await this.ProductApi.paging(param);

      this.productDatas = res.Data;
      this.total = res.TotalRecord;
    },
    async getSizes() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: {
          ModifiedDate: "asc",
        },
      };
      const res = await this.SizeApi.paging(param);
      this.Sizes = res.Data;
    },
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
    onChangeFilter() {
      console.log(this.CategoryFilter);
      console.log(this.SizeFilter);
      console.log(this.ColorFilter);
      console.log(this.CostFilter);
    },
  },
};
</script>

<style lang="scss">
@import "./ProductsView.scss";
</style>
