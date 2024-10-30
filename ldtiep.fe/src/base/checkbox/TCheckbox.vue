<template>
  <div class="tcheckbox" @click="onClick()">
    <div class="box">
      <div v-if="model" class="checked-box">
        <svg
          width="18"
          height="18"
          viewBox="0 0 24 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
          id=":ru7:"
          class="text-white"
        >
          <path
            d="M9.9998 13.6L15.8998 7.70005C16.0831 7.51672 16.3165 7.42505 16.5998 7.42505C16.8831 7.42505 17.1165 7.51672 17.2998 7.70005C17.4831 7.88338 17.5748 8.11671 17.5748 8.40005C17.5748 8.68338 17.4831 8.91672 17.2998 9.10005L10.6998 15.7C10.4998 15.9 10.2665 16 9.9998 16C9.73314 16 9.4998 15.9 9.2998 15.7L6.6998 13.1C6.51647 12.9167 6.4248 12.6834 6.4248 12.4C6.4248 12.1167 6.51647 11.8834 6.6998 11.7C6.88314 11.5167 7.11647 11.425 7.3998 11.425C7.68314 11.425 7.91647 11.5167 8.0998 11.7L9.9998 13.6Z"
            fill="currentcolor"
          ></path>
        </svg>
      </div>

      <div v-else class="uncheck-box"></div>

      <input ref="inputCB" class="hidden" type="checkbox" v-model="model" />
    </div>
    <span class="cb-label">
      <slot></slot>
    </span>
  </div>
</template>
    
<script>
export default {
  name: "TCheckbox",
  components: {},
  props: {
    modelValue: { type: [Boolean] },
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
.tcheckbox {
  height: 38px;
  width: 100%;
  background-color: white;
  display: flex;
  align-items: center;
  justify-content: start;
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
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
}
.uncheck-box {
  width: 20px;
  height: 20px;
  border: 1px solid #cfd7e3;
  border-radius: 6px;
}
.checked-box {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 20px;
  height: 20px;
  border: 1px solid #cfd7e3;
  background-color: #394960;
  color: white;
  border-radius: 6px;
}
</style>
    