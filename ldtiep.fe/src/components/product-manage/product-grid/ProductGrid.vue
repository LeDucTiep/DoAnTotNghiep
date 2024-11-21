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
    <div class="add-button">
      <vs-button @click="showAddForm()" color="primary" type="filled"
        >Thêm mới</vs-button
      >
    </div>
  </div>
  <div class="table-data">
    <TGrid
      v-if="rowData.length > 0"
      :columns="columns"
      :dataSource="rowData"
      @edit="onEdit($event)"
      @delete="onDelete($event)"
      :total="total"
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

  <vs-popup title="Xóa sản phẩm" v-model:active="isShowPopupDeleteMany">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa sản phẩm đã chọn?</div>
      <div class="buttons">
        <vs-button @click="confirmDeleteMany()" color="primary" type="filled"
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
            label="Giảm giá(%): "
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

  <vs-popup fullscreen title="Thêm mới sản phẩm" v-model:active="isShowAdd">
    <div class="popup-add-content">
      <div class="add-product-form">
        <div class="product-image">
          <div class="tiep-input-upload">
            <input
              ref="uploadInput"
              multiple
              accept="image/*"
              type="file"
              @change="handleFileUpload"
            /><span class="text-input">Chọn ảnh sản phẩm</span
            ><span class="input-progress" style="width: 0%"></span
            ><button
              @click="$refs.uploadInput.click()"
              class="btn-upload-all vs-upload--button-upload"
            >
              <i translate="no" class="material-icons notranslate">
                cloud_upload
              </i>
            </button>
          </div>
          <div
            :key="img.src"
            v-for="(img, index) in imageSrcs"
            class="img-preview-blog"
          >
            <vs-chip @click="remove(index)" closable>
              <img width="160" height="auto" :src="img.src" />
            </vs-chip>
          </div>
        </div>
        <div class="h-20"></div>
        <div class="h-20"></div>
        <div class="h-20"></div>

        <vs-row
          vs-align="flex-end"
          vs-type="flex"
          vs-justify="space-between"
          vs-w="12"
        >
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input
              label="Tên sản phẩm"
              class="w-240"
              placeholder="Áo polo"
              :danger="IsValidatingFormAdd && !addFormData.ProductName"
              danger-text="Tên sản phẩm không được để trống"
              v-model="addFormData.ProductName"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input
              label="Mã sản phẩm"
              placeholder="SCM6081"
              :danger="IsValidatingFormAdd && !addFormData.ProductCode"
              danger-text="Mã sản phẩm không được để trống"
              v-model="addFormData.ProductCode"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input-number
              label="Giá gốc: "
              :min="0"
              v-model="addFormData.OriginalPrice"
              :step="1000"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input-number
              label="Giảm giá(%): "
              :min="0"
              :max="100"
              v-model="addFormData.Discount"
              :step="1"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input-number
              label="Giá giảm giá"
              :min="0"
              v-model="addFormData.Price"
              :step="1000"
            />
          </vs-col>
        </vs-row>

        <div class="h-20"></div>
        <vs-row
          vs-align="flex-end"
          vs-type="flex"
          vs-justify="space-between"
          vs-w="12"
        >
          <vs-col
            vs-type="flex"
            vs-justify="center"
            vs-align="center"
            vs-w="12"
          >
            <div class="type-row">
              <vs-radio
                color="success"
                vs-name="radios2"
                v-model="currentCategoryType"
                :vs-value="0"
                >Nam</vs-radio
              >
              <vs-radio
                color="warning"
                vs-name="radios2"
                v-model="currentCategoryType"
                :vs-value="1"
                >Nữ</vs-radio
              >
              <vs-radio
                color="rgb(87, 251, 187)"
                vs-name="radios2"
                v-model="currentCategoryType"
                :vs-value="2"
                >Trẻ em</vs-radio
              >
            </div>
          </vs-col>
        </vs-row>
        <div class="h-20"></div>

        <vs-row
          vs-align="flex-end"
          vs-type="flex"
          vs-justify="space-between"
          vs-w="12"
        >
          <vs-col
            vs-type="flex"
            vs-justify="center"
            vs-align="center"
            vs-w="12"
          >
            <div class="category-block">
              <div
                class="col"
                v-for="(item, index) in CategoryData"
                :key="index"
              >
                <div class="title">
                  {{ item.CategoryName }}
                </div>
                <div class="row" v-for="j in item.Children" :key="j.CategoryID">
                  <vs-checkbox v-model="CategoryFormAdd[j.CategoryID]">{{
                    j.CategoryName
                  }}</vs-checkbox>
                </div>
              </div>
            </div>
          </vs-col>
        </vs-row>
        <div class="h-20"></div>
        <vs-row
          vs-align="flex-end"
          vs-type="flex"
          vs-justify="space-between"
          vs-w="12"
        >
          <vs-col
            vs-type="flex"
            vs-justify="center"
            vs-align="center"
            vs-w="12"
          >
            <div class="f-b">Màu sắc sản phẩm</div>
          </vs-col></vs-row
        >
        <div class="h-10"></div>
        <vs-row
          vs-align="flex-end"
          vs-type="flex"
          vs-justify="space-between"
          vs-w="12"
        >
          <vs-col
            vs-type="flex"
            vs-justify="center"
            vs-align="center"
            vs-w="12"
          >
            <div class="flex-wrap g-14">
              <div
                v-for="(item, index) in Colors"
                :key="index"
                class="color-cell"
              >
                <TColorCheck
                  :cusclass="'color'"
                  :code="item.ColorCode"
                  :name="item.ColorName"
                  v-model="ColorFormAdd[item.ColorCode]"
                >
                </TColorCheck>
              </div>
            </div>
          </vs-col>
        </vs-row>
        <div class="h-20"></div>
        <vs-row
          vs-align="flex-end"
          vs-type="flex"
          vs-justify="space-between"
          vs-w="12"
        >
          <vs-col
            vs-type="flex"
            vs-justify="center"
            vs-align="center"
            vs-w="12"
          >
            <div class="f-b">Kích thước sản phẩm</div>
          </vs-col></vs-row
        >
        <div class="h-10"></div>
        <vs-row
          vs-align="flex-end"
          vs-type="flex"
          vs-justify="space-between"
          vs-w="12"
        >
          <vs-col
            vs-type="flex"
            vs-justify="center"
            vs-align="center"
            vs-w="12"
          >
            <div class="flex-wrap g-14">
              <div
                v-for="(item, index) in Sizes"
                :key="index"
                class="size-cell"
              >
                <TSizeCheck
                  :cusclass="'size'"
                  v-model="SizeFormAdd[item.SizeID]"
                >
                  {{ item.SizeName }}
                </TSizeCheck>
              </div>
            </div>
          </vs-col>
        </vs-row>
      </div>
      <div class="buttons-footer">
        <vs-button @click="confirmAddProduct()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>
    
<script>
import API from "/src/service/api.js";
import TSizeCheck from "/src/base/checkbox/TSizeCheck.vue";
import TColorCheck from "/src/base/checkbox/TColorCheck.vue";
import { inject } from "vue";
export default {
  name: "ProductGrid",
  props: [],
  components: { TColorCheck, TSizeCheck },
  data() {
    return {
      vs: inject("$vs"),
      ColorApi: new API("Colors"),
      PictureApi: new API("Pictures"),
      SizeApi: new API("Sizes"),
      CateApi: new API("Categorys"),
      ProductApi: new API("Products"),
      uploadProgress: null,
      rowData: [],
      total: 0,
      columns: [
        { field: "ProductName", name: "Tên sản phẩm" },
        { field: "ProductCode", name: "Mã sản phẩm" },
        { field: "PictureIDS", name: "Ảnh", type: 10 },
        { field: "OriginalPrice", name: "Giá gốc" },
        { field: "Discount", name: "Giảm giá(%)" },
        { field: "Price", name: "Giá giảm giá" },
        {
          field: "ProductID",
          type: 1,
        },
      ],
      isShowPopupDeleteMany: false,
      isShowPopupDelete: false,
      isShowPopupEdit: false,
      isShowAdd: false,
      itemData: {},
      addFormData: {},
      rowSelected: [],
      imageSrcs: [],
      CategoryData: [],
      currentCategoryType: 0,
      Colors: [],
      Sizes: [],
      // Dữ liệu form thêm mới
      ColorFormAdd: {},
      SizeFormAdd: {},
      CategoryFormAdd: {},
      IsValidatingFormAdd: false,
      deletingData: {},
    };
  },
  watch: {
    currentCategoryType(val, oldVal) {
      if (val != oldVal) {
        this.getCategory(val);
      }
    },
    "addFormData.OriginalPrice": function (val, oldVal) {
      if (val != oldVal) {
        this.addFormData.Price = val - (val * this.addFormData.Discount) / 100;
      }
    },
    "addFormData.Discount": function (val, oldVal) {
      if (val != oldVal) {
        this.addFormData.Price =
          this.addFormData.OriginalPrice -
          (this.addFormData.OriginalPrice * val) / 100;
      }
    },
  },
  beforeMount() {
    this.getCategory(this.currentCategoryType);
    this.getColors();
    this.getSizes();
    this.getProducts();
  },
  methods: {
    async getProducts() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: {
          ModifiedDate: "asc",
        },
      };

      const res = await this.ProductApi.paging(param);

      this.rowData = res.Data;
      this.total = res.TotalRecord;
    },
    async getSizes() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: {
          ModifiedDate: "asc",
        },
      };
      const res = await this.SizeApi.paging(param);
      this.Sizes = res.Data;
    },
    async getColors() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: {
          ModifiedDate: "desc",
        },
      };

      const res = await this.ColorApi.paging(param);

      this.Colors = res.Data;
    },
    async getCategory(t) {
      const param = {
        PageSize: 500,
        PageNumber: 1,
        SearchEquals: {
          CategoryType: t,
        },
      };

      let res = await this.CateApi.paging(param);

      let parents = [];

      res.Data.forEach((e) => {
        if (!e.ParentID) {
          parents.push(e);
        }
      });

      function comparer(a, b) {
        return a.SortOrder - b.SortOrder;
      }

      parents.forEach((e) => {
        e.Children = res.Data.filter((j) => e.CategoryID == j.ParentID).sort(
          comparer
        );
      });

      parents = parents.sort(comparer);

      this.CategoryData = parents;
    },
    remove(index) {
      this.imageSrcs.splice(index, 1);
    },
    handleFileUpload(event) {
      const files = event.target.files;

      for (let i = 0; i < files.length; i++) {
        this.imageSrcs.push({
          src: URL.createObjectURL(files[i]),
          file: files[i],
        });
      }

      this.$refs.uploadInput.value = null;
    },
    onEdit() {},
    onDelete(e) {
      this.deletingData = e;
      this.isShowPopupDelete = true;
    },
    async confirmDelete() {
      this.isShowPopupDelete = false;

      await this.ProductApi.deleteByID(this.deletingData.ProductID);

      this.getProducts();
    },
    async confirmDeleteMany() {
      this.isShowPopupDeleteMany = false;

      const ids = this.rowSelected.map((e) => e.ProductID);
      await this.ProductApi.deleteMany(ids);

      this.getProducts();
    },
    confirmEdit() {},
    deleteSelected() {
      this.isShowPopupDeleteMany = true;
    },
    async showAddForm() {
      const code = await this.ProductApi.genNewKey();

      // Thêm dữ liệu mặc định
      this.IsValidatingFormAdd = false;
      this.SizeFormAdd = {};
      this.CategoryFormAdd = {};
      this.ColorFormAdd = {};
      this.imageSrcs = [];
      this.addFormData = {
        ProductCode: code,
        OriginalPrice: 0,
        Discount: 0,
        Price: 0,
      };

      this.isShowAdd = true;
    },
    validateAddForm() {
      this.IsValidatingFormAdd = true;

      if (!this.addFormData.ProductName) {
        this.vs.notify({
          title: "Có lỗi xảy ra",
          text: "Tên sản phẩm không được để trống",
          color: "danger",
        });
        return false;
      }

      if (!this.addFormData.ProductCode) {
        this.vs.notify({
          title: "Có lỗi xảy ra",
          text: "Mã sản phẩm không được để trống",
          color: "danger",
        });
        return false;
      }

      if (this.imageSrcs.length == 0) {
        this.vs.notify({
          title: "Có lỗi xảy ra",
          text: "Hình ảnh sản phẩm không được để trống",
          color: "danger",
        });
        return false;
      }

      const colors = this.Colors.filter((e) => {
        return this.ColorFormAdd[e.ColorCode];
      });

      if (colors.length == 0) {
        this.vs.notify({
          title: "Có lỗi xảy ra",
          text: "Màu sắc sản phẩm không được để trống",
          color: "danger",
        });
        return false;
      }

      const sizes = this.Sizes.filter((e) => {
        return this.SizeFormAdd[e.SizeID];
      });

      if (sizes.length == 0) {
        this.vs.notify({
          title: "Có lỗi xảy ra",
          text: "Kích thước sản phẩm không được để trống",
          color: "danger",
        });
        return false;
      }

      let hasData = false;
      let keys = Object.keys(this.CategoryFormAdd);
      for (let i = 0; i < keys.length; i++) {
        if (this.CategoryFormAdd[keys[i]]) {
          hasData = true;
        }
      }

      if (!hasData) {
        this.vs.notify({
          title: "Có lỗi xảy ra",
          text: "Thể loại sản phẩm không được để trống",
          color: "danger",
        });
        return false;
      }

      return true;
    },
    async confirmAddProduct() {
      if (!this.validateAddForm()) return;

      const colors = this.Colors.filter((e) => {
        return this.ColorFormAdd[e.ColorCode];
      });

      this.addFormData.ColorIDs = colors.map((e) => e.ColorID).join(";");
      this.addFormData.ColorCodes = colors.map((e) => e.ColorCode).join(";");
      this.addFormData.ColorNames = colors.map((e) => e.ColorName).join(";");

      const sizes = this.Sizes.filter((e) => {
        return this.SizeFormAdd[e.SizeID];
      });

      this.addFormData.SizeIDs = sizes.map((e) => e.SizeID).join(";");
      this.addFormData.SizeNames = sizes.map((e) => e.SizeName).join(";");

      const cateIDs = [];
      const cateNames = [];

      for (let i = 0; i < this.CategoryData.length; i++) {
        const children = this.CategoryData[i].Children;

        let hasValue = false;

        for (let j = 0; j < children.length; j++) {
          const item = children[j];

          if (this.CategoryFormAdd[item.CategoryID]) {
            hasValue = true;
            cateIDs.push(item.CategoryID);
            cateNames.push(item.CategoryName);
          }
        }

        if (hasValue) {
          cateIDs.push(this.CategoryData[i].CategoryID);
          cateNames.push(this.CategoryData[i].CategoryName);
        }
      }

      this.addFormData.CategoryIDs = cateIDs.join(";");
      this.addFormData.CategoryNames = cateNames.join(";");

      const tasks = [];

      for (let i = 0; i < this.imageSrcs.length; i++) {
        const task = this.PictureApi.upFile(this.imageSrcs[i].file);
        tasks.push(task);
      }

      const images = [];

      for (let i = 0; i < this.imageSrcs.length; i++) {
        images.push(await tasks[i]);
      }

      this.addFormData.PictureIDS = images.map((e) => e.PictureID).join(";");

      await this.ProductApi.add(this.addFormData);

      this.isShowAdd = false;

      this.getProducts();
    },
  },
};
</script>
    
    <style  lang="scss">
.vs-input-primary.w-240 {
  .vs-con-input {
    width: 240px;
  }
  width: 240px;
}
.menu-table-buttons {
  display: flex;
  gap: 10px;
  height: 100%;
  align-items: center;

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
  gap: 16px;

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
.h-20 {
  height: 20px;
}
.tiep-input-upload {
  background: #f5f5f5;
  width: 200px;
  height: 200px;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  border-radius: 8px;
  position: relative;
  -webkit-transition: all 0.25s ease;
  transition: all 0.25s ease;
  border: 1px dashed rgba(0, 0, 0, 0.1);
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-align: center;
  -ms-flex-align: center;
  align-items: center;
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  justify-content: center;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  -ms-flex-direction: column;
  flex-direction: column;
  margin: 15px;
}
.tiep-input-upload input {
  position: absolute;
  width: 100%;
  height: 100%;
  opacity: 0;
  left: 0;
  top: 0;
  cursor: pointer;
}
.tiep-input-upload .text-input {
  min-width: 200px;
  display: block;
  text-align: center;
  margin: 0 !important;
  padding: 0 !important;
  width: 100%;
  font-weight: 700;
}
.product-image {
  display: flex;
  flex-wrap: wrap;
}
.img-preview-blog {
  width: fit-content;
  height: fit-content;
}
.popup-add-content {
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  padding: 0px 20px;
  background: white;
}
.vs-popup--content {
  height: 100%;
}
.buttons-footer {
  display: flex;
  justify-content: end;
}
.w-100 {
  width: 100%;
}
.category-block {
  display: flex;
  justify-content: space-around;
  width: 100%;
  flex-wrap: wrap;

  .col {
    margin-bottom: 20px;
    display: flex;
    flex-direction: column;
    gap: 15px;
    min-width: 150px;
    align-items: start;

    .title {
      font-weight: bold;
      padding-bottom: 10px;
      cursor: pointer;
    }

    .row {
      &:hover {
        font-weight: 600;
      }

      cursor: pointer;
    }
  }
}

.add-product-form {
  .vs-checkbox--check {
    scale: 0.8;
    padding: 0;

    i.vs-checkbox--icon {
      width: 13px;
      height: 17px;
      margin: 0;
      padding: 0;
    }
  }
}
.flex-wrap {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}

.color-cell {
  width: 60px;
  height: 60px;
  border-radius: 10px;
  background: white;
  overflow: hidden;
  &:hover {
    background: #f2f5f8;
  }
}

.f-b {
  font-weight: bold;
}

.size-cell {
  height: 40px;
  width: 58px;
  border-radius: 10px;
}
.tsizecheck {
  border-radius: 10px;
}
.g-14 {
  gap: 14px;
}
</style>
    