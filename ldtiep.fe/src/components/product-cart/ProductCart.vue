<template>
  <div class="product-cart">
    <div class="product-cart-header">Giỏ hàng</div>

    <div class="product-cart-body">
      <div class="product-cart--left">
        <div class="product-list-header">
          <div class="select-all-box">
            <TCheckbox v-model="SelectedAll" @change="onSelectAll()">
            </TCheckbox>
          </div>
          <div class="select-all-name">
            Đã chọn {{ SelectedProducts.length }} sản phẩm
          </div>
        </div>
        <div class="product-list scroll">
          <div
            v-for="(item, index) in Products"
            :key="index"
            class="product-container-cart"
          >
            <TCheckbox v-model="SelectedCell[index]" @change="onSelectChange()">
            </TCheckbox>

            <div class="product-container-cart--right d-flex">
              <img
                loading="lazy"
                decoding="async"
                height="160"
                :src="PictureApi.baseUrl + '/' + item.PictureID"
              />

              <div class="cart-item-right">
                <div class="cart-item-right--top">
                  <div class="name">{{ item.ProductName }}</div>
                  <div class="pri d-flex">
                    <div class="price">
                      {{ format(item.Price) }}
                    </div>
                    <div class="org-price">
                      {{ format(item.OriginalPrice) }}
                    </div>
                  </div>

                  <div
                    v-if="item.Discount"
                    class="w-fit inline-flex items-center h-4 border-y-[0.6px] border-yd-alert-error bg-yd-alert-error-background text-yd-alert-error text-yd-subtitle-4"
                  >
                    <svg
                      width="4"
                      height="15"
                      viewBox="0 0 4 15"
                      fill="none"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <rect
                        y="0.600006"
                        width="0.6"
                        height="4"
                        fill="#E14337"
                      ></rect>
                      <path
                        d="M0 4.60001C1.65685 4.60001 3 5.94315 3 7.60001C3 9.25686 1.65685 10.6 0 10.6V4.60001Z"
                        fill="white"
                      ></path>
                      <path
                        d="M0 4.60001C1.65685 4.60001 3 5.94315 3 7.60001C3 9.25686 1.65685 10.6 0 10.6"
                        stroke="#E14337"
                        stroke-width="0.6"
                      ></path>
                      <rect
                        y="10.6"
                        width="0.6"
                        height="4"
                        fill="#E14337"
                      ></rect></svg
                    ><span class="px-1"
                      >Đã tiết kiệm -{{
                        format(item.OriginalPrice - item.Price)
                      }}</span
                    ><svg
                      width="4"
                      height="15"
                      viewBox="0 0 4 15"
                      fill="none"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <rect
                        x="3.40039"
                        y="0.599998"
                        width="0.6"
                        height="4"
                        fill="#E14337"
                      ></rect>
                      <path
                        d="M4 10.6C2.34315 10.6 1 9.25685 1 7.6C1 5.94314 2.34315 4.6 4 4.6L4 10.6Z"
                        fill="white"
                      ></path>
                      <path
                        d="M4 10.6C2.34315 10.6 1 9.25685 1 7.6C1 5.94314 2.34315 4.6 4 4.6"
                        stroke="#E14337"
                        stroke-width="0.6"
                      ></path>
                      <rect
                        x="3.40039"
                        y="10.6"
                        width="0.6"
                        height="4"
                        fill="#E14337"
                      ></rect>
                    </svg>
                  </div>
                </div>

                <div class="cart-item-right--bottom">
                  <div class="color-and-size">
                    {{ item.ColorName }}, {{ item.SizeName }}
                  </div>
                  <InputCounter
                    v-model="item.ProductCartCount"
                    :min="0"
                    @change="reduceProductNumber(index, $event)"
                  ></InputCounter>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="product-cart--right">
        <div class="title">Chi tiết đơn hàng</div>
        <div class="infor-cart">
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

        <div class="by-product-button">
          <div class="by-product">Mua hàng</div>
        </div>
      </div>
    </div>
  </div>

  <vs-popup
    title="Xóa sản phẩm khỏi giỏ hàng"
    v-model:active="isShowDeleteProduct"
  >
    <div class="popup-content">
      <div class="content">
        Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng?
      </div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>

<script>
import API from "/src/service/api.js";
import Cart from "/src/service/cart.js";
import TCheckbox from "/src/base/checkbox/TCheckbox.vue";
import InputCounter from "/src/base/input/InputCounter.vue";
import { inject } from "vue";
import EventBus from "../../service/EventBus";
export default {
  name: "ProductCart",
  props: {},
  components: { TCheckbox, InputCounter },
  data() {
    return {
      vs: inject("$vs"),
      Cart: new Cart(),
      PictureApi: new API("Pictures"),
      ProductApi: new API("Products"),
      PictureIDs: [],
      CurrentPic: 0,
      SelectedAll: false,
      SelectedCell: {},
      Products: [],
      SelectedProducts: [],
      TotalPrice: 0,
      TotalOriginalPrice: 0,
      TransCost: 20000,
      TransCostDiscount: 0,
      isShowDeleteProduct: false,
      indexDeleteProduct: 0,
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
  async created() {
    this.Products = this.Cart.get();

    for (let i = 0; i < this.Products.length; i++) {
      const e = this.Products[i];
      const p = await this.ProductApi.byID(e.ProductID);
      e.ProductName = p.ProductName;
      e.ProductCode = p.ProductCode;
      e.Price = p.Price;
      e.Discount = p.Discount;
      e.OriginalPrice = p.OriginalPrice;
      e.PictureID = p.PictureIDS.split(";")[0];
    }
  },
  methods: {
    updateCart() {
      EventBus.emit("updateCart", "");
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
    onSelectAll() {
      this.SelectedCell = {};
      if (this.SelectedAll) {
        for (let i = 0; i < this.Products.length; i++) {
          this.SelectedCell[i] = true;
        }
      }
      this.calculateSelected();
    },
    onSelectChange() {
      let isNotAll = false;
      for (let i = 0; i < this.Products.length; i++) {
        if (!this.SelectedCell[i]) {
          isNotAll = true;
          break;
        }
      }

      this.SelectedAll = !isNotAll;

      this.calculateSelected();
    },
    calculateSelected() {
      const arr = [];

      this.TotalPrice = 0;
      this.TotalOriginalPrice = 0;

      for (let i = 0; i < this.Products.length; i++) {
        if (this.SelectedCell[i]) {
          const p = this.Products[i];
          arr.push(p);

          this.TotalPrice += p.Price * p.ProductCartCount;
          this.TotalOriginalPrice += p.OriginalPrice * p.ProductCartCount;
        }
      }

      this.SelectedProducts = arr;
    },
    reduceProductNumber(i, val) {
      if (val === 0) {
        this.showDeleteProduct(i);
      }
      this.saveProductsConfig();
    },
    showDeleteProduct(index) {
      this.indexDeleteProduct = index;
      this.isShowDeleteProduct = true;
    },
    confirmDelete() {
      this.Products.splice(this.indexDeleteProduct, 1);
      this.isShowDeleteProduct = false;
      this.saveProductsConfig();
      this.updateCart();
    },
    saveProductsConfig() {
      this.Cart.save(this.Products);
    },
  },
};
</script>

<style lang="scss">
@import url(./ProductCart.scss);
</style>
