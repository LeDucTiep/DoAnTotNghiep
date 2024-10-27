<template>
  <div class="product-container">
    <div class="image">
      <img
        loading="lazy"
        decoding="async"
        class="object-cover w-full product-card_image__9h71i"
        src="https://m.yodycdn.com/fit-in/filters:format(webp)/products/akn5042-xth-5.jpg"
        style="color: transparent"
      />
    </div>
    <div class="name">
      {{ name }}
    </div>
    <div class="money">
      {{ money }}
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
export default {
  name: "ProductSP",
  props: {
    name: {
      default: "Áo khoác gió thông minh nữ trượt trước",
    },
    money: {
      default: "599.000 đ",
    },
    colors: {
      default: ["#336DAF", "#3D4D6E", "#FD5C45", "#242E36", "#F5CA49"],
    },
  },
  data() {
    return {};
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
</style>
