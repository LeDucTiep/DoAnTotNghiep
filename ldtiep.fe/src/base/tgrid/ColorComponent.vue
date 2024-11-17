<template>
  <div class="color-block flex-center">
    <div class="code">
      {{ colorCode }}
    </div>
    <div
      v-if="colorCode"
      class="color"
      :style="'background-color: ' + colorCode"
    ></div>
    <div v-else class="color other-color"></div>
  </div>
</template>
      
  <script>
export default {
  name: "ColorComponent",
  props: ["colorCode"],
  components: {},
  data() {
    return {};
  },
};
</script>
      
      <style  lang="scss">
.other-color {
  background-image: url(/src/assets/images/mutipleColor.svg);
}
.color-block {
  width: 100px;
  justify-content: space-between;
  .other-color,
  .color {
    height: 24px;
    width: 24px;
    border-radius: 6px;
    margin-left: 10px;
    border: 1px solid grey;
  }
}
</style>
      