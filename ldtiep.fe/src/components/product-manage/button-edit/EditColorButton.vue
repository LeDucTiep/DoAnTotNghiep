<template>
  <div class="menu-table-buttons">
    <div class="edit-product-button" @click="onEdit()">Sửa</div>
    <div class="delete-product-button" @click="onDelete()">Xóa</div>
  </div>

  <vs-popup title="Xóa sản phẩm" v-model:active="isShowPopupDelete">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa màu sắc này?</div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup
    v-if="isShowPopupEdit"
    title="Chỉnh sửa màu sắc"
    v-model:active="isShowPopupEdit"
  >
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <vs-input
            label="Tên màu"
            placeholder="Hồng cánh sen"
            v-model="itemData.ColorName"
          />
        </div>
        <div class="color-row">
          <vs-input
            label="Mã màu"
            placeholder="#ffffff"
            v-model="itemData.ColorCode"
          />
          <pick-colors v-model:value="itemData.ColorCode" />
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
import API from "/src/service/api.js";
export default {
  name: "EditColorButton",
  props: ["params"],
  components: {},
  data() {
    return {
      api: new API("Colors"),
      colorID: null,
      isShowPopupDelete: false,
      isShowPopupEdit: false,
      itemData: {},
    };
  },
  beforeMount() {
    this.colorID = this.params.value;
  },
  methods: {
    async onEdit() {
      const res = await this.api.byID(this.colorID);

      this.itemData = res;

      this.isShowPopupEdit = true;
    },
    onDelete() {
      this.isShowPopupDelete = true;
    },
    confirmDelete() {
      this.isShowPopupDelete = false;

      console.log(this.colorID);
    },
    async confirmEdit() {
      if (!this.isValidHexColor(this.itemData.ColorCode)) {
        return;
      }
      await this.api.updateByID(this.colorID, this.itemData);

      this.isShowPopupEdit = false;

      this.params.action();
    },
    isValidHexColor(hexColor) {
      const regex = /^#([0-9A-F]{3}|[0-9A-F]{6})$/i;
      return regex.test(hexColor);
    },
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
    