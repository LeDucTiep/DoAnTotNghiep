<template>
  <div
    style="justify-content: center; padding-top: 40px; min-height: 500px"
    class="d-flex w-100 h-100"
  >
    <div class="account-container">
      <vs-input
        label="Mã nhân viên"
        placeholder="NV035"
        v-model="itemData.EmployeeCode"
      />
      <div class="h-10"></div>
      <vs-input
        label="Mật khẩu"
        type="password"
        placeholder="******"
        v-model="itemData.Password"
      />
      <div class="h-10"></div>
      <div class="h-10"></div>
      <div class="d-flex" style="justify-content: end">
        <vs-button @click="onLogin()" color="primary"> Đăng nhập </vs-button>
      </div>
    </div>
  </div>
</template>
    
<script>
import API from "/src/service/api.js";
export default {
  name: "LoginPage",
  props: [],
  components: {},
  data() {
    return {
      isValidating: false,
      api: new API("Employees"),
      itemData: {},
    };
  },
  created() {},
  methods: {
    async onLogin() {
      const res = await this.api.checkPassword(this.itemData);

      if (res) {
        this.$cookies.set("sessionID", res, "1d"); // Hết hạn sau 1 ngày

        const p = "/admin";

        this.$router.push({
          path: p,
        });
      }
    },
  },
};
</script>
    
    <style  lang="scss">
</style>
    