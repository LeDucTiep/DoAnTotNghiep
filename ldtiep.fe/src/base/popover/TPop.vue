<template>
  <div class="tpop">
    <div
      class="target"
      @mouseover="titleBoyHover()"
      @mouseleave="titleBoyLeave()"
    >
      <slot></slot>
    </div>
    <div
      v-show="isShow"
      @mouseover="titleBoyHover()"
      @mouseleave="titleBoyLeave()"
      class="content"
    >
      <slot name="content"></slot>
    </div>
  </div>
</template>
  
  <script>
export default {
  name: "TPop",
  components: {},
  props: {},
  data() {
    return {
      isShow: false,
      isShowTO: null,
    };
  },
  methods: {
    titleBoyHover() {
      clearTimeout(this.isShowTO);
      this.isShow = true;
    },
    titleBoyLeave() {
      clearTimeout(this.isShowTO);
      this.isShowTO = setTimeout(() => {
        this.isShow = false;
      }, 500);
    },
  },
};
</script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped lang="scss">
@import "/src/components/YodyHome.scss";
</style>
  