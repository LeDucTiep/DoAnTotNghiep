<template>
  <div class="menu-table-buttons">
    <div class="edit-product-button" @click="onEdit()">Sửa</div>
    <div class="delete-product-button" @click="onDelete()">Xóa</div>
  </div>

  <vs-popup title="Xóa sản phẩm" v-model:active="isShowPopupDelete">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa sản phẩm này?</div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Chỉnh sửa sản phẩm" v-model:active="isShowPopupEdit">
    <div class="popup-content">
      <div class="edit-form">
        <div class="form-left">
          <div class="product-image">
            <img :src="itemData.image" />
            <div class="icon-camara">
              <vs-icon color="primary" icon="photo_camera" />
            </div>
          </div>
        </div>
        <div class="form-right">
          <vs-input
            label="Tên sản phẩm"
            placeholder="Áo polo"
            v-model="itemData.name"
          />
          <div class="h-10"></div>
          <vs-input-number
            label="Giá gốc: "
            :min="0"
            v-model="itemData.price"
            :step="1000"
          />
          <div class="h-10"></div>
          <vs-input-number
            label="Phần trăm giảm giá: "
            :min="0"
            v-model="itemData.discount"
            :step="1"
          />
          <div class="h-10"></div>
          <div class="gender">
            <div class="title">Giới tính</div>
            <div class="options">
              <vs-checkbox v-model="itemData.category" vs-value="Nam"
                >Nam</vs-checkbox
              >
              <vs-checkbox v-model="itemData.category" vs-value="Nữ"
                >Nữ</vs-checkbox
              >
              <vs-checkbox v-model="itemData.category" vs-value="Unisex"
                >Unisex</vs-checkbox
              >
            </div>
          </div>
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="confirmEdit()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>
    
    <script>
export default {
  name: "EditProductButton",
  props: ["params"],
  components: {},
  data() {
    return {
      cellValue: null,
      isShowPopupDelete: false,
      isShowPopupEdit: false,
      itemData: {
        product_id: 123,
        name: "Áo Khoác Gió Thông Minh Nữ Trượt Nước",
        image:
          "https://m.yodycdn.com/fit-in/filters:format(webp)/products/akn5042-den-4.jpg",
        price: 569050,
        original_price: 599000,
        discount: 5,
        category: [],
        size: [],
        color: [],
      },
    };
  },
  beforeMount() {
    this.cellValue = this.params.value;
  },
  methods: {
    onEdit() {
      console.log(this.cellValue);
    },
    onDelete() {
      this.isShowPopupDelete = true;
    },
    confirmDelete() {
      this.isShowPopupDelete = false;

      console.log(this.cellValue);
    },
    confirmEdit() {},
  },
};
</script>
    
    <style  lang="scss">
.menu-table-buttons {
  display: flex;
  gap: 10px;

  .edit-product-button {
    background-color: #94ffffff;
    &:hover {
      background-color: #d0ffffff;
    }
  }
  .delete-product-button {
    background-color: #ffa68bff;
    &:hover {
      background-color: #ffd4c7ff;
    }
  }
}
.edit-product-button,
.delete-product-button {
  border-radius: 10px;
  width: 50%;
  border: 1px solid #ccc;
  height: 30px;
  padding: 0px;
  margin: 0px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  margin-top: 5px;
}
.popup-content {
  .content {
    font-size: 16px;
  }
  .buttons {
    display: flex;
    justify-content: end;
    align-items: center;
  }
}
.product-image {
  position: relative;
  width: fit-content;
  &:hover {
    opacity: 0.5;
  }
  .icon-camara {
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    user-select: none;
    right: 0;
    bottom: 0;
    display: flex;
    align-items: center;
    justify-content: center;
  }
  img {
    max-height: 200px;
    cursor: pointer;
    border-radius: 10px;
    max-width: 200px;
  }
}
.edit-form {
  display: flex;

  .form-right {
    padding: 0px 10px;
    width: 100%;

    .vs-con-input {
      width: 400px;
    }
  }
}
.h-10 {
  height: 10px;
}
.gender {
  .title {
    padding-left: 5px;
    margin-bottom: 4px;
  }
  .options {
    display: flex;
    justify-content: start;
    align-items: center;
    gap: 10px;
    margin-bottom: 5px;

    .vs-checkbox--icon {
      height: 18px;
      width: 18px;
    }
  }
}
</style>
    