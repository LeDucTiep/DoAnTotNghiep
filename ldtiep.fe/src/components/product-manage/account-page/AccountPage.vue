<template>
  <div
    style="justify-content: center; padding-top: 40px; min-height: 500px"
    class="d-flex w-100 h-100"
  >
    <div class="account-container">
      <vs-input
        label="Họ và tên"
        placeholder="Lê Đức Tiệp"
        v-model="itemData.EmployeeName"
      />
      <div class="h-10"></div>
      <vs-input
        label="Mã nhân viên"
        placeholder="NV001"
        v-model="itemData.EmployeeCode"
      />
      <div class="h-10"></div>
      <div class="h-10"></div>
      <div class="flex-row gap-10">
        <vs-button @click="showChangePass()" color="primary">
          Đổi mật khẩu
        </vs-button>
        <vs-button @click="logout()" color="primary"> Đăng xuất </vs-button>
      </div>
    </div>
  </div>

  <vs-popup title="Thêm nhân viên" v-model:active="isShowChangePass">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row flex-col">
          <vs-input
            label="Mật khẩu cũ"
            placeholder="******"
            type="password"
            v-model="password.Old"
          />
          <div class="h-10"></div>
          <vs-input
            label="Mật khẩu mới"
            placeholder="******"
            v-model="password.New"
          />
          <div class="h-10"></div>
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="confirmChangePass()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>
    
<script>
import API from "/src/service/api.js";
import { inject } from "vue";
export default {
  name: "AccountPage",
  props: [],
  components: {},
  data() {
    return {
      isValidating: false,
      vs: inject("$vs"),
      api: new API("Employees"),
      itemData: {},
      isShowChangePass: false,
      password: {},
    };
  },
  async created() {
    while (!window.__appinfor) {
      await new Promise((resolve) => setTimeout(resolve, 100));
    }
    this.itemData = window.__appinfor || {};
  },
  methods: {
    logout() {
      this.$cookies.remove("sessionID");

      const p = "/";

      this.$router.push({
        path: p,
      });
    },
    showChangePass() {
      this.isShowChangePass = true;
      this.password = {};
    },
    async confirmChangePass() {
      const param = {
        EmployeeCode: this.itemData.EmployeeCode,
        Password: this.password.Old,
      };

      const res = await this.api.checkPassword(param);

      if (res) {
        this.isShowChangePass = false;

        this.$cookies.set("sessionID", res, "1d"); // Hết hạn sau 1 ngày

        await this.api.changePassword(res, this.password.New);
      } else {
        this.vs.notify({
          title: "Có lỗi xảy ra",
          text: "Mật khẩu không đúng",
          color: "danger",
        });
      }
    },
  },
};
</script>
    
    <style  lang="scss">
</style>
    