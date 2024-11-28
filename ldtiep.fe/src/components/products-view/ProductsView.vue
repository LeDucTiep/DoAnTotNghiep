<template>
  <div class="view-page-container">
    <div v-if="!isShowCategoryFilter" class="filter-name">{{ filterName }}</div>
    <div class="product-view-container d-flex">
      <div class="bo-loc">
        <div class="total">{{ total }} sản phẩm</div>
        <div class="name">Bộ lọc</div>
        <div v-if="isShowCategoryFilter" class="gender">
          <div class="title">Thể loại</div>
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
            :productID="item.ProductID"
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
      Categorys: [],
      productDatas: [],
      total: 0,
      filterName: "",
      isShowCategoryFilter: true,
    };
  },
  async created() {
    this.CategoryFilter[this.$route.query.CategoryType] = true;
    await this.getColors();
    await this.getCategorys();
    await this.getSizes();
    await this.getProducts();
    await this.mapFilterName();
  },
  watch: {
    "$route.query.CategoryType": function (val, oldVal) {
      if (val != oldVal) {
        this.CategoryFilter = {};
        this.CategoryFilter[val] = true;
        this.mapFilterName();
        this.getProducts();
      }
    },
    "$route.query.CategoryID": function (val, oldVal) {
      if (val != oldVal) {
        this.mapFilterName();
        this.getProducts();
      }
    },
    "$route.query.q": function (val, oldVal) {
      if (val != oldVal) {
        this.mapFilterName();
        this.getProducts();
      }
    },
    "$route.query.Search": function (val, oldVal) {
      if (val != oldVal) {
        this.getProducts();
      }
    },
  },
  methods: {
    async mapFilterName() {
      if (this.$route.query.CategoryID) {
        const cate = await this.CateApi.byID(this.$route.query.CategoryID);

        this.filterName = cate.CategoryName;

        this.isShowCategoryFilter = false;
      } else {
        switch (this.$route.query.CategoryType) {
          case 0:
            this.filterName = "Nam";
            break;
          case 1:
            this.filterName = "Nữ";
            break;
          default:
            this.filterName = "Trẻ em";
            break;
        }
        this.isShowCategoryFilter = true;
      }
    },
    buildProductParam() {
      const filter = {};
      const filterIn = {};
      const sortBuilder = {};
      const SearchBigger = {};
      const SearchSmaller = {};

      switch (this.$route.query.q) {
        case "sale-50%":
          SearchBigger.Discount = 50;
          break;
        case "moi-ve":
          sortBuilder.CreatedDate = "desc";
          break;
        case "ban-chay":
          sortBuilder.SoldCount = "desc";
          break;
      }

      if (this.$route.query.CategoryID)
        filterIn.CategoryIDs = [this.$route.query.CategoryID];
      else {
        const ca = [];

        for (let i = 0; i < this.Categorys.length; i++) {
          const e = this.Categorys[i];

          if (this.CategoryFilter[e.CategoryType]) {
            ca.push(e.CategoryID);
          }

          for (let j = 0; j < e.Children.length; j++) {
            const element = e.Children[j];

            if (this.CategoryFilter[element.CategoryType]) {
              ca.push(element.CategoryID);
            }
          }
        }
        filterIn.CategoryIDs = ca;
      }

      const colorIds = [];

      for (const key of Object.keys(this.ColorFilter)) {
        if (this.ColorFilter[key]) {
          colorIds.push(key);
        }
      }

      if (colorIds.length) {
        filterIn.ColorIDs = colorIds;
      }

      const sizeIds = [];

      for (const key of Object.keys(this.SizeFilter)) {
        if (this.SizeFilter[key]) {
          sizeIds.push(key);
        }
      }

      if (sizeIds.length) {
        filterIn.SizeIDs = sizeIds;
      }

      let min = [];
      let max = [];

      for (let i = 0; i < 3; i++) {
        if (this.CostFilter[i]) {
          switch (i) {
            case 0:
              min.push(0);
              max.push(350000);
              break;
            case 1:
              min.push(350000);
              max.push(750000);
              break;
            case 2:
              min.push(750000);
              max.push(9999999999999);
              break;
          }
        }
      }

      if (min.length) {
        SearchBigger.Price = Math.min(...min);
        SearchSmaller.Price = Math.max(...max);
      }

      sortBuilder.ModifiedDate = "asc";

      const searchContains = {};

      if (this.$route.query.Search) {
        searchContains.ProductName = this.$route.query.Search;
      }

      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: sortBuilder,
        SearchEquals: filter,
        SearchIn: filterIn,
        SearchBigger: SearchBigger,
        SearchSmaller: SearchSmaller,
        SearchContains: searchContains,
      };
      return param;
    },
    async getCategorys() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
      };

      const res = await this.CateApi.paging(param);

      let parents = [];

      res.Data.forEach((e) => {
        if (!e.ParentID) {
          parents.push(e);
        }
      });

      function comparer(a, b) {
        return a.SortOrder - b.SortOrder;
      }

      parents.forEach((e) => {
        e.Children = res.Data.filter((j) => e.CategoryID == j.ParentID).sort(
          comparer
        );
      });

      parents = parents.sort(comparer);

      this.Categorys = parents;
    },
    async getProducts() {
      const param = this.buildProductParam();

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
      this.getProducts();
    },
  },
};
</script>

<style lang="scss">
@import "./ProductsView.scss";
</style>
