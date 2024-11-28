<template>
  <div class="admin-container">
    <div class="tabbar">
      <div class="left">
        <template v-for="(item, index) in tabs" :key="index">
          <div
            :class="{ 'tab-content--active': index == currentTab }"
            class="tab-content"
            v-if="tabPermission[index]"
            @click="onChangeTab(index)"
          >
            {{ item.name }}
          </div>
        </template>
      </div>
      <div v-if="currentTab == 0 && tabPermission[0]" class="right">
        <ProductGrid></ProductGrid>
      </div>
      <div v-if="currentTab == 1 && tabPermission[1]" class="right">
        <ColorGrid></ColorGrid>
      </div>
      <div v-if="currentTab == 2 && tabPermission[2]" class="right">
        <SizeGrid></SizeGrid>
      </div>
      <div v-if="currentTab == 3 && tabPermission[3]" class="right">
        <CategoryGrid></CategoryGrid>
      </div>
      <div v-if="currentTab == 4 && tabPermission[4]" class="right">
        <OrderGrid></OrderGrid>
      </div>
      <div v-if="currentTab == 5 && tabPermission[5]" class="right">
        <EmployeeGrid></EmployeeGrid>
      </div>
      <div v-if="currentTab == 6 && tabPermission[6]" class="right">
        <AccountPage></AccountPage>
      </div>
    </div>
  </div>
</template>
  
  <script>
import ProductGrid from "./product-grid/ProductGrid.vue";
import ColorGrid from "./color-grid/ColorGrid.vue";
import CategoryGrid from "./category-grid/CategoryGrid.vue";
import OrderGrid from "./order-grid/OrderGrid.vue";
import SizeGrid from "./size-grid/SizeGrid.vue";
import EmployeeGrid from "./employee-grid/EmployeeGrid.vue";
import AccountPage from "./account-page/AccountPage.vue";
import API from "/src/service/api.js";

export default {
  name: "ProductManage",
  props: {},
  components: {
    ProductGrid,
    EmployeeGrid,
    SizeGrid,
    ColorGrid,
    CategoryGrid,
    AccountPage,
    OrderGrid,
  },
  data() {
    return {
      api: new API("Employees"),
      currentTab: 1,
      tabPermission: {},
      tabs: [
        {
          id: 0,
          code: "san-pham",
          name: "Sản phẩm",
        },
        {
          id: 1,
          code: "mau-sac",
          name: "Màu sắc",
        },
        {
          id: 2,
          code: "kich-thuoc",
          name: "Kích thước",
        },
        {
          id: 3,
          code: "the-loai",
          name: "Thể loại",
        },
        {
          id: 4,
          code: "don-hang",
          name: "Đơn hàng",
        },
        {
          id: 5,
          code: "nhan-vien",
          name: "Nhân viên",
        },
        {
          id: 6,
          name: "Tài khoản",
        },
      ],
    };
  },
  created() {
    this.currentTab = localStorage.getItem("currentAdminTabId") || 0;
    this.getUserInfor();
  },
  methods: {
    async getUserInfor() {
      const sessionID = this.$cookies.get("sessionID");

      const infor = await this.api.GetUserInfor(sessionID);

      if (!infor) {
        this.$router.push({
          path: "/login",
        });
        return;
      }
      window.__appinfor = infor;

      if (window.__appinfor.Rules) {
        window.__appinfor.Rules = JSON.parse(window.__appinfor.Rules);
      }

      for (let i = 0; i < this.tabs.length; i++) {
        const o = this.tabs[i];
        if (window.__appinfor.Rules.includes(o.code))
          this.tabPermission[o.id] = true;
      }
      this.tabPermission[6] = true;
    },
    onChangeTab(e) {
      const me = this;
      me.currentTab = e;
      localStorage.setItem("currentAdminTabId", me.currentTab);
    },
  },
};
</script>
  
  <style lang="scss">
@import "./ProductManage.scss";
</style>
  