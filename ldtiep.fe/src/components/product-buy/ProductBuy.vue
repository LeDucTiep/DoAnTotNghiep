<template>
  <div class="product-buy-container">
    <div class="product-buy-container--left">
      <div class="h-20"></div>
      <div class="h-10"></div>
      <div class="block-1">
        <div class="title-employee-recieve">Người nhận</div>
        <div class="h-10"></div>
        <vs-input
          icon-no-border
          icon="person"
          label="Tên khách hàng"
          :danger="!ProductBuyInfor.CustomerName && isValidating"
          danger-text="Không được để trống"
          v-model="ProductBuyInfor.CustomerName"
          size="large"
        />
        <div class="h-10"></div>
        <vs-input
          icon-no-border
          icon="call"
          label="Số điện thoại"
          :danger="!ProductBuyInfor.PhoneNumber && isValidating"
          danger-text="Không được để trống"
          v-model="ProductBuyInfor.PhoneNumber"
          size="large"
        />
        <div class="h-10"></div>
        <vs-input
          icon-no-border
          icon="mail"
          type="email"
          label="Địa chỉ email (Không bắt buộc)"
          v-model="ProductBuyInfor.Email"
          size="large"
        />
      </div>
      <div class="h-20"></div>
      <div class="block-1">
        <div class="title">Địa chỉ của bạn</div>
        <div class="h-10"></div>
        <div class="flex-row gap-14">
          <vs-select
            class="city-combo"
            label="Tỉnh/Thành phố"
            :danger="!ProductBuyInfor.CityID && isValidating"
            danger-text="Không được để trống"
            autocomplete
            :disabled="!Citys.length"
            v-model="ProductBuyInfor.CityID"
          >
            <vs-select-item :modelValue="undefined" :text="''" />
            <vs-select-item
              :key="index"
              :modelValue="item.CityID"
              :text="item.Name"
              v-for="(item, index) in Citys"
            />
          </vs-select>

          <vs-select
            class="district-combo"
            label="Quận/Huyện"
            :danger="!ProductBuyInfor.DistrictID && isValidating"
            danger-text="Không được để trống"
            autocomplete
            :disabled="!Districts.length"
            v-model="ProductBuyInfor.DistrictID"
          >
            <vs-select-item :modelValue="undefined" :text="''" />
            <vs-select-item
              :key="index"
              :modelValue="item.DistrictID"
              :text="item.Name"
              v-for="(item, index) in Districts"
            />
          </vs-select>

          <vs-select
            class="commune-combo"
            autocomplete
            label="Phường/Xã"
            :danger="!ProductBuyInfor.CommuneID && isValidating"
            danger-text="Không được để trống"
            :disabled="!Communes.length"
            v-model="ProductBuyInfor.CommuneID"
          >
            <vs-select-item :modelValue="undefined" :text="''" />
            <vs-select-item
              :key="index"
              :modelValue="item.CommuneID"
              :text="item.Name"
              v-for="(item, index) in Communes"
            />
          </vs-select>
        </div>
        <div class="h-10"></div>
        <vs-input
          icon-no-border
          icon="home"
          label="Nhập địa chỉ (ví dụ 90 Nguyễn Tuân)"
          :danger="!ProductBuyInfor.EmployeeExtraAddress && isValidating"
          danger-text="Không được để trống"
          v-model="ProductBuyInfor.EmployeeExtraAddress"
          size="large"
        />
        <div class="h-10"></div>
        <vs-input
          icon-no-border
          icon="edit"
          label="Nhập ghi chú (Không bắt buộc)"
          v-model="ProductBuyInfor.EmployeeNote"
          size="large"
        />
      </div>
    </div>
    <div class="product-buy-container--right">
      <div class="product-infors">
        <div class="title">Thông tin sản phẩm</div>
        <div class="product-infors--body scroll gap-10 flex-col">
          <div
            class="product-infor"
            v-for="(item, index) in Products"
            :key="index"
          >
            <div class="product-infor--left">
              <img
                width="90"
                :src="PictureApi.baseUrl + '/' + item.PictureID"
              />
            </div>
            <div class="product-infor--right">
              <div class="product-infor--right--top">
                <div class="title-product">
                  {{ item.ProductName }}
                </div>
                <div class="size-and-color">
                  {{ item.ColorName }}, {{ item.SizeName }}
                </div>
              </div>
              <div class="product-infor--right--bottom flex-row">
                <div class="flex-row gap-10">
                  <div class="price">{{ format(item.Price) }}</div>
                  <div class="org-price">{{ format(item.OriginalPrice) }}</div>
                </div>
                <div class="product-count">x{{ item.ProductCartCount }}</div>
              </div>
            </div>
          </div>
        </div>
        <div class="summary-infor">
          <div class="row d-flex">
            <div class="name">Tổng giá trị sản phẩm</div>
            <div class="value">{{ format(TotalPrice) }}</div>
          </div>
          <div class="row d-flex">
            <div class="name">Vận chuyển</div>
            <div class="value">{{ format(TransCost) }}</div>
          </div>
          <div v-if="TransCostDiscount" class="row d-flex">
            <div class="name">Giảm giá vận chuyển</div>
            <div class="value tran-cost">- {{ format(TransCostDiscount) }}</div>
          </div>
          <div class="row-hr"></div>
          <div class="row d-flex total-cost-row">
            <div class="name">Tổng thanh toán</div>
            <div class="value">{{ format(TotalPay) }}</div>
          </div>

          <div v-if="TotalMoneySaved" class="row d-flex total-extra-row">
            <div class="name">
              Bạn đã tiết kiệm được {{ format(TotalMoneySaved) }}
            </div>
          </div>
        </div>

        <div class="h-20"></div>

        <div @click="onBuyProduct()" class="by-product-button">
          <div class="by-product">Đặt hàng</div>
        </div>

        <div class="h-20"></div>
      </div>
    </div>
  </div>
</template>

<script>
import API from "/src/service/api.js";
import Cart from "/src/service/cart.js";
import { inject } from "vue";
export default {
  name: "ProductBuy",
  props: {},
  components: {},
  data() {
    return {
      vs: inject("$vs"),
      Cart: new Cart(),
      PictureApi: new API("Pictures"),
      ProductApi: new API("Products"),
      CityApi: new API("Citys"),
      DistrictApi: new API("Districts"),
      CommuneApi: new API("Communes"),
      OrderApi: new API("Orders"),
      CategoryApi: new API("Categorys"),
      ProductBuyInfor: {},
      Citys: [],
      Districts: [],
      Communes: [],
      TotalPrice: 0,
      TotalOriginalPrice: 0,
      TransCost: 20000,
      TransCostDiscount: 0,
      Products: [],
      isValidating: false,
    };
  },
  computed: {
    TotalPay() {
      return this.TotalPrice + this.TransCost - this.TransCostDiscount;
    },
    TotalMoneySaved() {
      return this.TotalOriginalPrice - this.TotalPrice + this.TransCostDiscount;
    },
  },
  watch: {
    "ProductBuyInfor.CityID": function (val, oldVal) {
      if (val != oldVal) {
        this.onCityChange();
      }
    },
    "ProductBuyInfor.DistrictID": function (val, oldVal) {
      if (val != oldVal) {
        this.onDistrictChange();
      }
    },
    "ProductBuyInfor.CommuneID": function (val, oldVal) {
      if (val != oldVal) {
        this.onCommuneChange();
      }
    },
  },
  async created() {
    const selected = JSON.parse(atob(this.$route.query.q));

    const arr = this.Cart.get();

    this.Products = [];

    for (let i = 0; i < arr.length; i++) {
      const e = arr[i];

      if (selected[i]) {
        const p = await this.ProductApi.byID(e.ProductID);
        e.ProductName = p.ProductName;
        e.ProductCode = p.ProductCode;
        e.Price = p.Price;
        e.Discount = p.Discount;
        e.OriginalPrice = p.OriginalPrice;
        e.PictureID = p.PictureIDS.split(";")[0];

        this.Products.push(e);
      }
    }

    this.getCity();

    this.calculateSelected();
  },
  methods: {
    calculateSelected() {
      this.TotalPrice = 0;
      this.TotalOriginalPrice = 0;

      for (let i = 0; i < this.Products.length; i++) {
        const p = this.Products[i];
        this.TotalPrice += p.Price * p.ProductCartCount;
        this.TotalOriginalPrice += p.OriginalPrice * p.ProductCartCount;
      }

      if (this.TotalPrice >= 500000) {
        this.TransCostDiscount = 20000;
      } else {
        this.TransCostDiscount = 0;
      }
    },
    format(val) {
      if (!val) return "0 đ";
      return val
        .toLocaleString("vi-VN", {
          style: "currency",
          currency: "VND",
        })
        .replace("₫", "đ");
    },
    async getCity() {
      const param = {
        PageSize: 1000,
        PageNumber: 1,
        Sorter: {
          Name: "asc",
        },
      };
      const res = await this.CityApi.paging(param);

      this.Citys = res.Data;
    },
    async getDistrict(CityID) {
      const param = {
        PageSize: 1000,
        PageNumber: 1,
        Sorter: {
          Name: "asc",
        },
        SearchEquals: {
          CityID: CityID,
        },
      };
      const res = await this.DistrictApi.paging(param);

      this.Districts = res.Data;
    },
    async getCommune(districtID) {
      const param = {
        PageSize: 1000,
        PageNumber: 1,
        Sorter: {
          Name: "asc",
        },
        SearchEquals: {
          DistrictID: districtID,
        },
      };
      const res = await this.CommuneApi.paging(param);

      this.Communes = res.Data;
    },
    onCityChange() {
      if (this.ProductBuyInfor.CityID) {
        this.getDistrict(this.ProductBuyInfor.CityID);
      }
    },
    onDistrictChange() {
      if (this.ProductBuyInfor.DistrictID) {
        this.getCommune(this.ProductBuyInfor.DistrictID);
      }
    },
    onCommuneChange() {},
    validateOrder() {
      this.isValidating = true;

      if (!this.ProductBuyInfor.CustomerName) {
        return false;
      }

      if (!this.ProductBuyInfor.PhoneNumber) {
        return false;
      }

      if (!this.ProductBuyInfor.CityID) {
        return false;
      }

      if (!this.ProductBuyInfor.DistrictID) {
        return false;
      }

      if (!this.ProductBuyInfor.CommuneID) {
        return false;
      }

      if (!this.ProductBuyInfor.EmployeeExtraAddress) {
        return false;
      }

      return true;
    },
    async onBuyProduct() {
      if (this.validateOrder()) {
        let address = [];

        const citySelected = this.Citys.filter((e) => {
          return e.CityID == this.ProductBuyInfor.CityID;
        });
        address.push(citySelected[0].Name.trim());

        const districtSelected = this.Districts.filter((e) => {
          return e.DistrictID == this.ProductBuyInfor.DistrictID;
        });
        address.push(districtSelected[0].Name.trim());

        const communeSelected = this.Communes.filter((e) => {
          return e.CommuneID == this.ProductBuyInfor.CommuneID;
        });
        address.push(communeSelected[0].Name.trim());

        address = address.filter((e) => e);

        this.ProductBuyInfor.EmployeeAddress = address.join(", ");

        this.ProductBuyInfor.TotalPrice = this.TotalPrice;
        this.ProductBuyInfor.TransCost = this.TransCost;
        this.ProductBuyInfor.TransCostDiscount = this.TransCostDiscount;
        this.ProductBuyInfor.TotalPay = this.TotalPay;

        this.ProductBuyInfor.Products = JSON.stringify(this.Products);

        try {
          await this.OrderApi.add(this.ProductBuyInfor);
          this.vs.notify({
            title: "Thành công",
            text: "Đặt hàng thành công",
            color: "success",
          });

          for (let i = 0; i < this.Products.length; i++) {
            const id = this.Products[i].ProductID;

            const p = await this.ProductApi.byID(id);

            p.SoldCount = (p.SoldCount || 0) + 1;

            await this.ProductApi.updateByID(id, p);

            const categories = p.CategoryIDs.split(";");

            for (let j = 0; j < categories.length; j++) {
              const c = await this.CategoryApi.byID(categories[j]);

              c.SoldCount = (c.SoldCount || 0) + 1;

              await this.CategoryApi.updateByID(categories[j], c);
            }
          }

          this.toHomePage();
        } catch (e) {
          this.vs.notify({
            title: "Có lỗi xảy ra",
            text: "Vui lòng kiểm tra kết nối mạng của bạn",
            color: "danger",
          });
        }
      }
    },
    toHomePage() {
      const p = "/";

      this.$router.push({
        path: p,
      });
    },
  },
};
</script>

<style lang="scss">
@import url(./ProductBuy.scss);
</style>
