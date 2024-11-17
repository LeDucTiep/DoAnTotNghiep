<template>
  <div class="color-block flex-center">
    <div class="code">
      {{ colorCode }}
    </div>
    <div class="color" :style="'background-color: ' + colorCode"></div>
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
.color-block {
  width: 100px;
  justify-content: space-between;

  .color {
    height: 24px;
    width: 24px;
    border-radius: 6px;
    margin-left: 10px;
  }
}
</style>
      