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
  props: ["params"],
  components: {},
  data() {
    return {
      colorCode: "",
    };
  },
  beforeMount() {
    this.colorCode = this.params.value;
    console.log(this.params);
  },
  methods: {},
};
</script>
      
      <style  lang="scss">
.color-block {
  .color {
    height: 24px;
    width: 24px;
    border-radius: 6px;
    margin-left: 10px;
  }
}
</style>
      