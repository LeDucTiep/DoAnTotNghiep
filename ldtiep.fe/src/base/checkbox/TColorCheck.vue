<template>
  <div :class="`tcolorcheck ${cusclass}`" @click="onClick()">
    <div class="box">
      <div
        v-if="model"
        class="checked-box"
        :style="{ backgroundColor: code }"
        :class="{ 'other-color': !code }"
      >
        <img height="26" src="../../assets/images/check-mark.png" alt="" />
      </div>

      <div
        v-else
        class="uncheck-box"
        :style="{ backgroundColor: code }"
        :class="{ 'other-color': !code }"
      ></div>

      <input ref="inputCB" class="hidden" type="checkbox" v-model="model" />
    </div>
    <span class="cb-label">
      {{ name }}
    </span>
  </div>
</template>
      
  <script>
export default {
  name: "TColorCheck",
  components: {},
  props: {
    modelValue: { type: [Boolean] },
    cusclass: { type: [String] },
    code: { type: [String] },
    name: { default: "Khác" },
  },
  emits: ["change", "update:modelValue"],
  computed: {
    model: {
      get() {
        return this.modelValue;
      },
      set(val) {
        this.$emit("update:modelValue", val);
        this.$emit("change", val);
      },
    },
  },
  methods: {
    onClick() {
      this.$refs.inputCB.click();
    },
  },
};
</script>
      
  <style scoped lang="scss">
.tcolorcheck {
  height: 68px;
  width: 100%;
  background-color: white;
  display: flex;
  align-items: center;
  flex-direction: column;
  justify-content: center;
  cursor: pointer;
  user-select: none;

  &:hover {
    background-color: #f2f5f8;
  }
}
.cb-label {
  font-size: 14px;
  color: #394960;
}
.box {
  height: 24px;
  width: 100%;
  justify-content: center;
  display: flex;
  margin-bottom: 4px;
  input.hidden {
    position: absolute;
  }
}
.uncheck-box {
  width: 24px;
  height: 24px;
  border: 1px solid #cfd7e3;
  border-radius: 50%;
}
.checked-box {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 24px;
  height: 24px;
  border: 1px solid #53565a;
  border-radius: 50%;
}
.other-color {
  background-image: url(/src/assets/images/mutipleColor.svg);
}
</style>
      