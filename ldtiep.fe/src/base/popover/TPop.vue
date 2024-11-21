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
      v-show="isShow && !isClickHide"
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
  emits: ["open", "close"],
  data() {
    return {
      isClickHide: false,
      isShow: false,
      isShowTO: null,
    };
  },
  methods: {
    hide() {
      this.isClickHide = true;
      console.log(this.isClickHide);
    },
    titleBoyHover() {
      clearTimeout(this.isShowTO);
      this.isShow = true;
      this.$emit("open");
    },
    titleBoyLeave() {
      if (this.isClickHide) {
        this.isClickHide = false;
        this.isShow = false;
        this.$emit("close");

        clearTimeout(this.isShowTO);
        return;
      }

      clearTimeout(this.isShowTO);
      this.isShowTO = setTimeout(() => {
        this.isShow = false;
        this.$emit("close");
      }, 300);
    },
  },
};
</script>
  
  <!-- Add "scoped" attribute to limit CSS to this component only -->
  <style scoped lang="scss">
@import "/src/components/YodyHome.scss";
</style>
  