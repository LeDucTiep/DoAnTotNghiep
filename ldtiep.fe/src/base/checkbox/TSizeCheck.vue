<template>
  <div
    :class="`tsizecheck ${cusclass} ${model ? 'b-black' : ''}`"
    @click="onClick()"
  >
    <div class="box">
      <div class="checked-box" :class="{ 'uncheck-box': model }">
        <span class="cb-label">
          <slot></slot>
        </span>
      </div>

      <input ref="inputCB" class="hidden" type="checkbox" v-model="model" />
    </div>
  </div>
</template>
    
<script>
export default {
  name: "TSizeCheck",
  components: {},
  props: {
    modelValue: { type: [Boolean] },
    cusclass: { type: [String] },
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
.tsizecheck {
  padding: 10px;
  border: 1px solid #cfd7e3;
  align-items: center;
  display: flex;
  justify-items: center;
  width: 100%;
  height: 100%;
  justify-content: center;
  background-color: white;
  cursor: pointer;
  user-select: none;

  &:hover {
    background-color: #f2f5f8;
  }
}
.b-black {
  border: 1px solid black !important;
}
.box {
  width: 100%;
  align-items: center;
  display: flex;
  justify-content: center;
  input.hidden {
    position: absolute;
  }
}
.cb-label {
  font-size: 14px;
  color: #394960;
}
</style>
    