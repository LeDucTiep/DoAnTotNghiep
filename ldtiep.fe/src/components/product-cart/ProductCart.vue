<template>
  <div class="product-cart">
    <div class="product-cart-header">Giỏ hàng</div>

    <div class="product-list"></div>
  </div>
</template>

<script>
import API from "/src/service/api.js";
import Cart from "/src/service/cart.js";
import { inject } from "vue";
export default {
  name: "ProductCart",
  props: {},
  components: {},
  data() {
    return {
      vs: inject("$vs"),
      Cart: new Cart(),
      PictureApi: new API("Pictures"),
      ProductApi: new API("Products"),
      Colors: [],
      sizes: [],
      ColorFormView: {},
      Product: {},
      PictureIDs: [],
      CurrentPic: 0,
      swiper: null,
      count: 1,
    };
  },
  computed: {},
  created() {
    this.Cart.get();
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
  },
};
</script>

<style lang="scss">
@import url(./ProductCart.scss);
</style>
