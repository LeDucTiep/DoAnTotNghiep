<template>
  <div class="product-cart">
    <div class="product-cart-header">Giỏ hàng</div>

    <div class="product-list-header">
      <div class="select-all-box">
        <TCheckbox v-model="SelectedAll" @change="onSelectAll()"> </TCheckbox>
      </div>
      <div class="select-all-name">Đã chọn 0 sản phẩm</div>
    </div>
    <div class="product-list">
      <div
        v-for="(item, index) in Products"
        :key="index"
        class="product-container-cart"
      >
        <TCheckbox v-model="SelecteCell[index]" @change="onSelectChange()">
        </TCheckbox>

        <div class="product-container-cart--right d-flex">
          <img
            loading="lazy"
            decoding="async"
            height="160"
            src="https://localhost:44356/api/v1/Pictures/d886ad44-0002-4eaa-bd50-c00d1c089369"
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
              <InputCounter v-model="item.ProductCartCount"></InputCounter>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import API from "/src/service/api.js";
import Cart from "/src/service/cart.js";
import TCheckbox from "/src/base/checkbox/TCheckbox.vue";
import InputCounter from "/src/base/input/InputCounter.vue";
import { inject } from "vue";
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
      SelecteCell: {},
      Products: [],
    };
  },
  computed: {},
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
    }

    console.log(this.Products);
  },
  methods: {
    format(val) {
      if (!val) return "";
      return val
        .toLocaleString("vi-VN", {
          style: "currency",
          currency: "VND",
        })
        .replace("₫", "đ");
    },
    onSelectAll() {},
    onSelectChange() {},
  },
};
</script>

<style lang="scss">
@import url(./ProductCart.scss);
</style>
