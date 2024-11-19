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
      v-model="selected"
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
          <div :key="src" v-for="src in imageSrcs" class="img-preview-blog">
            <vs-chip @click="remove(src)" closable>
              <img width="160" height="auto" :src="src" />
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
              placeholder="Áo polo"
              v-model="addFormData.name"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input
              label="Mã sản phẩm"
              placeholder="SCM6081"
              v-model="addFormData.name"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input-number
              label="Giá gốc: "
              :min="0"
              v-model="addFormData.price"
              :step="1000"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input-number
              label="Phần trăm giảm giá: "
              :min="0"
              v-model="addFormData.discount"
              :step="1"
            />
          </vs-col>
          <vs-col vs-type="flex" vs-justify="center" vs-align="center" vs-w="2">
            <vs-input-number
              label="Giá giảm giá"
              :min="0"
              v-model="addFormData.discount"
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
                <div
                  class="title"
                  @click="
                    onChooseCategory({
                      CategoryType: item.CategoryType,
                      CategoryID: item.CategoryID,
                    })
                  "
                >
                  {{ item.CategoryName }}
                </div>
                <div
                  class="row"
                  v-for="j in item.Children"
                  :key="j.CategoryID"
                  @click="
                    onChooseCategory({
                      CategoryType: item.CategoryType,
                      CategoryID: j.CategoryID,
                    })
                  "
                >
                  <vs-checkbox v-model="j.IsChecked" :vs-value="j.CategoryID">{{
                    j.CategoryName
                  }}</vs-checkbox>
                </div>
              </div>
            </div>
          </vs-col>
        </vs-row>
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
            <TColorCheck
              v-for="(item, index) in Colors"
              :key="index"
              :cusclass="'color'"
              :code="item.ColorCode"
              :name="item.ColorName"
              v-model="item.IsChecked"
              @change="onChangeColors()"
            >
            </TColorCheck>
          </vs-col>
        </vs-row>
      </div>
      <div class="buttons-footer">
        <vs-button @click="confirmEdit()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>
    
<script>
import API from "/src/service/api.js";
import TColorCheck from "/src/base/checkbox/TColorCheck.vue";
export default {
  name: "ProductGrid",
  props: [],
  components: { TColorCheck },
  data() {
    return {
      ColorApi: new API("Colors"),
      CateApi: new API("Categorys"),
      selectedFiles: null,
      uploadProgress: null,
      rowData: [],
      columns: [
        { field: "name", width: 420 },
        { field: "price" },
        { field: "original_price" },
        { field: "discount" },
      ],
      selected: [],
      isShowPopupDelete: false,
      isShowPopupEdit: false,
      isShowAdd: true,
      itemData: {},
      addFormData: {},
      rowSelected: [],
      imageSrcs: [],
      CategoryData: [],
      currentCategoryType: 0,
      Colors: [],
    };
  },
  watch: {
    currentCategoryType(val, oldVal) {
      if (val != oldVal) {
        this.getCategory(val);
      }
    },
  },
  beforeMount() {
    this.getCategory(this.currentCategoryType);
    this.getColors();
  },
  methods: {
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
    onChooseCategory(e) {
      console.log(e);
    },
    async getCategory(t) {
      const param = {
        PageSize: 500,
        PageNumber: 1,
        SearchTerm: {
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
    remove(item) {
      this.imageSrcs.splice(this.imageSrcs.indexOf(item), 1);
    },
    handleFileUpload(event) {
      console.log(event.target.files);
      this.selectedFiles = event.target.files;

      for (let i = 0; i < this.selectedFiles.length; i++) {
        // const reader = new FileReader();

        //     reader.onload
        // = (e) => {
        //       imagePreview.src = e.target.result;
        //     };

        //     reader.readAsDataURL(file);

        this.imageSrcs.push(URL.createObjectURL(this.selectedFiles[i]));
      }

      this.$refs.uploadInput.value = null;
    },
    async uploadFile() {
      this.selectedFiles.forEach((file) => {
        const formData = new FormData();
        formData.append("file", file);
        const xhr = new XMLHttpRequest();
        xhr.open("POST", "https://your-backend-api/upload", true);
        xhr.upload.onprogress = (event) => {
          if (event.lengthComputable) {
            this.uploadProgress = Math.round(
              (event.loaded / event.total) * 100
            );
          }
        };
        xhr.onload = () => {
          if (xhr.status === 200) {
            console.log("File uploaded successfully");
            this.uploadProgress = null;
          } else {
            console.error("Error uploading file");
          }
        };
        xhr.send(formData);
      });
    },
    onEdit() {},
    onDelete() {
      this.isShowPopupDelete = true;
    },
    confirmDelete() {
      this.isShowPopupDelete = false;
    },
    confirmEdit() {},
    deleteSelected() {
      this.isShowPopupDelete = true;
    },
    showAddForm() {
      this.isShowAdd = true;
      this.addFormData = {};
    },
    onChangeColors() {},
  },
};
</script>
    
    <style  lang="scss">
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
</style>
    