<template>
  <div class="input-counter">
    <div class="box d-flex">
      <div class="down" @click="down()">
        <svg
          width="20"
          height="20"
          viewBox="0 0 24 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
          id=":rqm:"
          class="product-quantity-update-tool_icon__PMqPH"
        >
          <path
            d="M18 12.75H6C5.59 12.75 5.25 12.41 5.25 12C5.25 11.59 5.59 11.25 6 11.25H18C18.41 11.25 18.75 11.59 18.75 12C18.75 12.41 18.41 12.75 18 12.75Z"
            :fill="model <= min ? '#ccc' : '#000'"
          ></path>
        </svg>
      </div>
      <div class="number">
        {{ model }}
      </div>

      <div class="up" @click="up()">
        <svg
          width="20"
          height="20"
          viewBox="0 0 24 24"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
          id=":rqn:"
          class="product-quantity-update-tool_icon__PMqPH"
        >
          <path
            d="M18 12.75H6C5.59 12.75 5.25 12.41 5.25 12C5.25 11.59 5.59 11.25 6 11.25H18C18.41 11.25 18.75 11.59 18.75 12C18.75 12.41 18.41 12.75 18 12.75Z"
            fill="currentcolor"
          ></path>
          <path
            d="M12 18.75C11.59 18.75 11.25 18.41 11.25 18V6C11.25 5.59 11.59 5.25 12 5.25C12.41 5.25 12.75 5.59 12.75 6V18C12.75 18.41 12.41 18.75 12 18.75Z"
            fill="currentcolor"
          ></path>
        </svg>
      </div>
    </div>
  </div>
</template>
      
  <script>
export default {
  name: "InputCounter",
  components: {},
  props: {
    modelValue: { type: [Number] },
    min: {
      type: Number,
      default: 1,
    },
  },
  emits: ["change", "update:modelValue"],
  computed: {
    model: {
      get() {
        return this.modelValue ?? 0;
      },
      set(val) {
        this.$emit("update:modelValue", val ?? 0);
        this.$emit("change", val);
      },
    },
  },
  methods: {
    down() {
      const n = this.model - 1;
      this.model = n < this.min ? this.min : n;
    },
    up() {
      this.model = this.model + 1;
    },
  },
};
</script>
      
  <style scoped lang="scss">
.input-counter {
  width: fit-content;
  border: 1px solid #cfd7e3;
  display: flex;
  justify-content: space-between;
  border-radius: 10px;
  user-select: none;
  .box {
    height: 48px;
    justify-content: space-between;

    .down {
      padding: 14px;
      cursor: pointer;
    }
    .up {
      padding: 14px;
      cursor: pointer;
    }
    .number {
      padding: 14px;
      width: 50px;
      justify-content: center;
      display: flex;
    }
  }
}
</style>
      