<template>
  <div class="product-container">
    <div class="image">
      <img
        loading="lazy"
        decoding="async"
        class="object-cover w-full product-card_image__9h71i"
        :src="src"
        style="color: transparent"
      />
      <div v-if="discount" class="discount-percent">-{{ discount }}%</div>
    </div>
    <div class="name">
      {{ name }}
    </div>
    <div :style="{ color: discount ? '#DF154B' : 'black' }" class="money">
      {{ format(price) }}
    </div>
    <div class="colors">
      <div
        v-for="(item, index) in colors"
        :key="index"
        class="p-color"
        :style="{ backgroundColor: item }"
      ></div>
    </div>
  </div>
</template>

<script>
import API from "/src/service/api.js";
export default {
  name: "ProductSP",
  props: {
    name: {
      default: "Áo khoác gió thông minh nữ trượt trước",
    },
    price: {
      default: 599000,
    },
    originalPrice: {
      default: 480000,
    },
    discount: {
      default: 10,
    },
    colors: {
      default: ["#336DAF", "#3D4D6E", "#FD5C45", "#242E36", "#F5CA49"],
    },
    pictureIds: {
      default: "",
    },
  },
  data() {
    return {
      api: new API("Pictures"),
    };
  },
  computed: {
    src() {
      return this.api.baseUrl + "/" + this.pictureIds.split(";")[0];
    },
  },
  methods: {
    format(val) {
      return val.toLocaleString("vi-VN", {
        style: "currency",
        currency: "VND",
      });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.w-full {
  width: 100%;
}
.p-color {
  width: 22px;
  height: 22px;
  border-radius: 100px;
}
.colors {
  display: flex;
  gap: 5px;
  margin-top: 10px;
}
.name {
  color: #1c2430;
  font-size: 14px;
  margin-top: 10px;
}
.money {
  margin-top: 10px;
  color: #1c2430;
  font-size: 16px;
  font-weight: 600;
}
.product-container {
  .image {
    position: relative;
    .discount-percent {
      background: #e14337;
      position: absolute;
      top: 5px;
      right: 5px;
      padding: 4px 10px;
      border-radius: 16px;
      color: white;
      font-size: 13px;
    }
  }
}
</style>
