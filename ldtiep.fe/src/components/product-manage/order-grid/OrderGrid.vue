<template>
  <div class="table-head">
    <div class="util-buttons">
      <vs-button
        v-if="rowSelected.length > 0"
        @click="deleteSelected()"
        color="danger"
        type="filled"
        >Xóa màu đã chọn</vs-button
      >
    </div>
    <div class="filter-order-button">
      <div class="switch-block">
        <div class="label">Chờ xác nhận</div>
        <vs-switch color="dark" v-model="switchArray" :vs-value="0"></vs-switch>
      </div>
      <div class="switch-block">
        <div class="label">Đã xác nhận</div>
        <vs-switch
          :color="'warning'"
          v-model="switchArray"
          :vs-value="1"
        ></vs-switch>
      </div>
      <div class="switch-block">
        <div class="label">Đang giao hàng</div>
        <vs-switch
          color="primary"
          v-model="switchArray"
          :vs-value="2"
        ></vs-switch>
      </div>
      <div class="switch-block">
        <div class="label">Hoàn thành</div>
        <vs-switch
          color="success"
          v-model="switchArray"
          :vs-value="3"
        ></vs-switch>
      </div>
      <div class="switch-block">
        <div class="label">Đã xóa</div>
        <vs-switch
          color="danger"
          v-model="switchArray"
          :vs-value="4"
        ></vs-switch>
      </div>
    </div>
  </div>
  <div class="table-data">
    <TGrid
      v-if="rowData.length > 0"
      :columns="columns"
      :dataSource="rowData"
      @view="onView($event)"
      @delete="onDelete($event)"
      @status="changeStatus($event)"
      @sort="onSort($event)"
      @changePage="onChangePage($event)"
      v-model="rowSelected"
    ></TGrid>
    <div v-else class="nodata-img flex-center">
      <img
        style="height: 500px"
        src="../../../assets/images/nodata.png"
        alt="Không có dữ liệu"
      />
    </div>
  </div>

  <vs-popup fullscreen title="Đơn hàng" v-model:active="isShowView">
    <div class="view-order-popup-content h-100">
      <div class="product-buy-container h-100">
        <div class="product-buy-container--left">
          <div class="h-20"></div>
          <div class="h-10"></div>
          <div class="block-1">
            <div class="title-employee-recieve">Người nhận</div>
            <div class="h-10"></div>
            <vs-input
              icon-no-border
              disabled
              icon="person"
              label="Tên khách hàng"
              v-model="viewFormData.CustomerName"
              size="large"
            />
            <div class="h-10"></div>
            <vs-input
              icon-no-border
              disabled
              icon="call"
              label="Số điện thoại"
              v-model="viewFormData.PhoneNumber"
              size="large"
            />
            <div class="h-10"></div>
            <vs-input
              icon-no-border
              disabled
              icon="mail"
              label="Địa chỉ email (Không bắt buộc)"
              v-model="viewFormData.Email"
              size="large"
            />
          </div>
          <div class="h-20"></div>
          <div class="block-1">
            <div class="title f-18 b">Địa chỉ</div>
            <div class="h-10"></div>
            <vs-input
              icon-no-border
              disabled
              icon="location_on"
              label="Tỉnh/Thành phố, Quận/Huyện, Phường/Xã"
              v-model="viewFormData.EmployeeAddress"
              size="large"
            />
            <div class="h-10"></div>
            <vs-input
              icon-no-border
              disabled
              icon="home"
              label="Nhập địa chỉ (ví dụ 90 Nguyễn Tuân)"
              v-model="viewFormData.EmployeeExtraAddress"
              size="large"
            />
            <div class="h-10"></div>
            <vs-input
              icon-no-border
              disabled
              icon="edit"
              label="Nhập ghi chú (Không bắt buộc)"
              v-model="viewFormData.EmployeeNote"
              size="large"
            />
          </div>
        </div>
        <div class="product-buy-container--right">
          <div class="product-infors">
            <div class="title">Thông tin sản phẩm</div>
            <div class="product-infors--body scroll gap-10 flex-col">
              <div
                class="product-infor"
                v-for="(item, index) in Products"
                :key="index"
              >
                <div class="product-infor--left">
                  <img
                    width="90"
                    :src="PictureApi.baseUrl + '/' + item.PictureID"
                  />
                </div>
                <div class="product-infor--right">
                  <div class="product-infor--right--top">
                    <div class="title-product">
                      {{ item.ProductName }}
                    </div>
                    <div class="size-and-color">
                      {{ item.ColorName }}, {{ item.SizeName }}
                    </div>
                  </div>
                  <div class="product-infor--right--bottom flex-row">
                    <div class="flex-row gap-10">
                      <div class="price">{{ format(item.Price) }}</div>
                      <div class="org-price">
                        {{ format(item.OriginalPrice) }}
                      </div>
                    </div>
                    <div class="product-count">
                      x{{ item.ProductCartCount }}
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="summary-infor">
              <div class="row d-flex">
                <div class="name">Tổng giá trị sản phẩm</div>
                <div class="value">{{ format(viewFormData.TotalPrice) }}</div>
              </div>
              <div class="row d-flex">
                <div class="name">Vận chuyển</div>
                <div class="value">{{ format(viewFormData.TransCost) }}</div>
              </div>
              <div v-if="viewFormData.TransCostDiscount" class="row d-flex">
                <div class="name">Giảm giá vận chuyển</div>
                <div class="value tran-cost">
                  - {{ format(viewFormData.TransCostDiscount) }}
                </div>
              </div>
              <div class="row-hr"></div>
              <div class="row d-flex total-cost-row">
                <div class="name">Tổng thanh toán</div>
                <div class="value">{{ format(viewFormData.TotalPay) }}</div>
              </div>
            </div>

            <div class="h-20"></div>
          </div>
        </div>
      </div>
      <div class="view-order-buttons p-absolute">
        <vs-button @click="isShowView = false" color="primary" type="filled"
          >Đóng</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa đơn hàng" v-model:active="isShowPopupDelete">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa các đơn hàng đã chọn?</div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa đơn hàng" v-model:active="isShowPopupDeleteOne">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa đơn hàng này?</div>
      <div class="buttons">
        <vs-button @click="confirmDeleteOne()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Sửa đổi trạng thái" v-model:active="isShowPopupStatus">
    <div class="popup-content">
      <div class="h-10"></div>

      <div class="content d-flex gap-10">
        <vs-radio
          v-model="orderChangeStatus.OrderStatus"
          color="dark"
          :vs-value="0"
          >Chờ xác nhận</vs-radio
        >
        <vs-radio
          v-model="orderChangeStatus.OrderStatus"
          color="warning"
          :vs-value="1"
          >Đã xác nhận</vs-radio
        >
        <vs-radio
          v-model="orderChangeStatus.OrderStatus"
          color="primary"
          :vs-value="2"
          >Đang giao hàng</vs-radio
        >
        <vs-radio
          v-model="orderChangeStatus.OrderStatus"
          color="success"
          :vs-value="3"
          >Hoàn thành</vs-radio
        >
        <vs-radio
          v-model="orderChangeStatus.OrderStatus"
          color="danger"
          :vs-value="4"
          >Đã xóa</vs-radio
        >
      </div>

      <div class="h-10"></div>
      <div class="h-10"></div>
      <div class="buttons">
        <vs-button @click="confirmStatus()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>
    
<script>
import API from "/src/service/api.js";
export default {
  name: "OrderGrid",
  props: [],
  components: {},
  data() {
    return {
      isShowView: false,
      PictureApi: new API("Pictures"),
      api: new API("Orders"),
      rowData: [],
      columns: [
        { field: "OrderStatus", name: "Trạng thái", type: 54 },
        { field: "CustomerName", name: "Tên Khách hàng" },
        {
          field: "PhoneNumber",
          name: "Số điện thoại",
          type: 67,
        },
        {
          field: "Email",
          name: "Mail",
          type: 67,
        },
        {
          field: "EmployeeAddress",
          name: "Tỉnh thành",
        },
        {
          field: "EmployeeExtraAddress",
          name: "Địa chỉ",
        },
        {
          field: "EmployeeNote",
          name: "Ghi chú",
        },
        {
          field: "TotalPay",
          name: "Tổng thanh toán",
          type: 45,
        },
        {
          field: "OrderID",
          type: 15,
        },
      ],
      viewFormData: {},
      rowSelected: [],
      isShowPopupDelete: false,
      deletingID: [],
      Products: [],
      isShowPopupDeleteOne: false,
      isShowPopupEdit: false,
      currentSort: {
        CreatedDate: "desc",
        ModifiedDate: "desc",
      },
      pageIndex: 1,
      switchArray: [0, 1, 2, 3],
      isShowPopupStatus: false,
      orderChangeStatus: {},
    };
  },
  watch: {
    switchArray(val, oldVal) {
      if (val != oldVal) {
        this.getData();
        localStorage.setItem("orderSwitchArr", JSON.stringify(val));
      }
    },
  },
  created() {
    this.switchArray = JSON.parse(localStorage.getItem("orderSwitchArr")) || [
      0, 1, 2, 3,
    ];

    this.getData();
  },
  beforeMount() {},
  methods: {
    format(val) {
      if (!val) return "0 đ";
      return val
        .toLocaleString("vi-VN", {
          style: "currency",
          currency: "VND",
        })
        .replace("₫", "đ");
    },
    async getData() {
      const filterIn = {
        OrderStatus: this.switchArray.map((e) => e.toString()),
      };

      const param = {
        PageSize: 100,
        PageNumber: this.pageIndex,
        Sorter: this.currentSort,
        SearchIn: filterIn,
      };

      const res = await this.api.paging(param);

      this.rowData = res.Data;

      this.rowSelected = [];
    },
    onView(e) {
      this.viewFormData = e;
      this.Products = [];
      this.Products = JSON.parse(e.Products);

      this.isShowView = true;
    },
    onDelete(e) {
      this.isShowPopupDeleteOne = true;
      this.deletingID = [e.OrderID];
    },
    async changeStatus(e) {
      this.isShowPopupStatus = true;
      this.orderChangeStatus = await this.api.byID(e.OrderID);
    },
    async confirmDelete() {
      this.isShowPopupDelete = false;

      for (let i = 0; i < this.deletingID.length; i++) {
        const id = this.deletingID[i];
        const order = await this.api.byID(id);
        order.OrderStatus = 4;
        await this.api.updateByID(id, order);
      }
      this.getData();
    },
    async confirmDeleteOne() {
      this.isShowPopupDeleteOne = false;
      for (let i = 0; i < this.deletingID.length; i++) {
        const id = this.deletingID[i];
        const order = await this.api.byID(id);
        order.OrderStatus = 4;
        await this.api.updateByID(id, order);
      }
      this.getData();
    },
    deleteSelected() {
      this.isShowPopupDelete = true;

      this.deletingID = this.rowSelected.map((e) => e.OrderID);
    },
    async confirmStatus() {
      this.isShowPopupStatus = false;
      const id = this.orderChangeStatus.OrderID;
      await this.api.updateByID(id, this.orderChangeStatus);
      this.getData();
    },
  },
};
</script>
    
    <style  lang="scss">
.product-buy-container {
  display: flex;

  .product-infors {
    .title {
      font-size: 16px;
      padding: 20px 0;

      color: #1c2430;
      font-weight: 600;
    }
  }

  .product-buy-container--left {
    background-color: white;
    width: 50%;
    color: #1c2430;
    padding-right: 56px;
    padding-left: 200px;

    .title-employee-recieve {
      font-size: 20px;
      font-weight: 600;
    }

    .vs-input-primary {
      width: 100%;
    }
  }

  .product-buy-container--right {
    background: #fafafa;
    width: 50%;
    padding-left: 56px;
    padding-right: 200px;
    padding-top: 10px;
    border-left: 1px solid #d6d6d6;

    .product-infor {
      display: flex;
      flex-direction: row;
      gap: 10px;
    }

    .product-infor--right--top {
      gap: 8px;
      display: flex;
      flex-direction: column;
    }

    .product-infor--right {
      width: 100%;
      display: flex;
      flex-direction: column;
      justify-content: space-between;

      .size-and-color,
      .title-product {
        font-size: 14px;
        color: #1c2430;
      }
    }

    .product-infor--right--bottom {
      justify-content: space-between;
    }

    .product-infors--body {
      max-height: 390px;
    }

    .summary-infor {
      display: flex;
      flex-direction: column;
      gap: 14px;
      font-size: 16px;
      color: #616161;
      margin-top: 20px;

      .tran-cost {
        color: #e14337 !important;
      }

      .row {
        justify-content: space-between;
      }

      .row-hr {
        height: 1px;
        background-color: #eceff4;
        width: 100%;
      }

      .total-cost-row {
        color: #1c2430;
        font-size: 20px;
      }

      .total-extra-row {
        justify-content: end;
        color: #e14337;
        font-size: 14px;
      }
    }
  }
}

.product-infor--right--bottom {
  padding-bottom: 4px;

  .price {
    font-size: 14px;
    color: #e14337;
  }

  .org-price {
    text-decoration-line: line-through;
    color: #c7c7c7 !important;
    font-size: 14px;
    font-weight: 400;
  }

  .product-count {
    color: #1c2430;
    font-weight: 400;
    font-size: 14px;
  }
}

.by-product-button {
  background-color: #fcaf17;
  color: #2a2a86;
  cursor: pointer;
  margin-top: 20px;
  border-color: #1c2430;
  font-size: 16px;
  padding: 14px;
  border-radius: 10px;
  user-select: none;
  width: 100%;
  display: flex;
  border-bottom: 3px solid;
  border-color: #ca8c12;
  justify-content: center;
  font-weight: bold;

  &:hover {
    background-color: #fdc75d;
  }
}

.total-cost-row {
  .name {
    font-size: 20px;
  }
  .value {
    font-size: 20px;
  }
}

.gap-10 {
  gap: 10px;
}

.vs-popup--content:has(.view-order-popup-content) {
  padding: 0px !important;
  margin: 0px !important;
}

.f-18 {
  font-size: 18px;
}

.b {
  font-weight: 600;
}

.view-order-buttons {
  display: flex;
  justify-content: end;
  padding-right: 24px;
  bottom: 0;
  width: 100%;
}

.view-order-popup-content {
  position: relative;
}

.h-100 {
  height: 100%;
}

.p-absolute {
  position: absolute;
}

.filter-order-button {
  display: flex;
  flex-direction: row;
  gap: 14px;

  .switch-block {
    display: flex;
    align-items: center;
    gap: 6px;
  }
  .label {
    user-select: none;
  }
}

.table-head {
  height: 35px;
}
</style>
    