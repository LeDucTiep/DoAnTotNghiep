<template>
  <div class="table-head">
    <div class="filter-radios">
      <vs-radio
        color="success"
        vs-name="radios1"
        v-model="currentCategoryType"
        :vs-value="0"
        >Nam</vs-radio
      >
      <vs-radio
        color="warning"
        vs-name="radios1"
        v-model="currentCategoryType"
        :vs-value="1"
        >Nữ</vs-radio
      >
      <vs-radio
        color="rgb(87, 251, 187)"
        vs-name="radios1"
        v-model="currentCategoryType"
        :vs-value="2"
        >Trẻ em</vs-radio
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
      :multiple="false"
      :columns="columns"
      :dataSource="rowData"
      @edit="onEdit($event)"
      @delete="onDelete($event)"
      @sort="onSort($event)"
      @changePage="onChangePage($event)"
    ></TGrid>
    <div v-else class="nodata-img flex-center">
      <img
        style="height: 500px"
        src="../../../assets/images/nodata.png"
        alt="Không có dữ liệu"
      />
    </div>
  </div>

  <vs-popup title="Thêm thể loại" v-model:active="isShowAddForm">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <div class="left">
            <vs-input
              :danger="isExistsName"
              danger-text="Thể loại này đã tồn tại"
              label="Tên thể loại"
              placeholder="Áo trẻ em"
              v-model="addFormData.CategoryName"
            />

            <vs-input-number v-model="addFormData.SortOrder" label="Thứ tự:" />
          </div>
          <div class="type-row">
            <vs-radio
              color="success"
              vs-name="radios2"
              v-model="addFormData.CategoryType"
              :vs-value="0"
              >Nam</vs-radio
            >
            <vs-radio
              color="warning"
              vs-name="radios2"
              v-model="addFormData.CategoryType"
              :vs-value="1"
              >Nữ</vs-radio
            >
            <vs-radio
              color="rgb(87, 251, 187)"
              vs-name="radios2"
              v-model="addFormData.CategoryType"
              :vs-value="2"
              >Trẻ em</vs-radio
            >
          </div>
        </div>
        <div class="children-row">
          <table class="children-row--table">
            <tr class="children-row--row">
              <th>Tên thể loại con</th>
              <th>
                <div class="flex-center">Thứ tự</div>
              </th>
              <th>
                <div class="flex-center">
                  <vs-button
                    @click="formAddChildren()"
                    color="success"
                    type="border"
                    >Thêm</vs-button
                  >
                </div>
              </th>
            </tr>
            <tr
              v-for="item in addFormData.Children"
              :key="item.CategoryID"
              class="children-row--row"
            >
              <td>
                <vs-input
                  :danger="isExistsCategory"
                  danger-text="Thể loại này đã tồn tại"
                  placeholder="Áo polo"
                  v-model="item.CategoryName"
                />
              </td>
              <td>
                <vs-input-number v-model="item.SortOrder" />
              </td>
              <td>
                <div class="flex-center">
                  <vs-button
                    @click="formAddDeleteChildren(item)"
                    color="danger"
                    type="border"
                    >Xóa</vs-button
                  >
                </div>
              </td>
            </tr>
          </table>
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="onAdd()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Sửa thể loại" v-model:active="isShowEditForm">
    <div class="popup-content">
      <div class="add-form">
        <div class="name-row">
          <div class="left">
            <vs-input
              label="Tên thể loại"
              placeholder="Áo trẻ em"
              v-model="editFormData.CategoryName"
            />

            <vs-input-number v-model="editFormData.SortOrder" label="Thứ tự:" />
          </div>
          <div class="type-row">
            <vs-radio
              color="success"
              v-model="editFormData.CategoryType"
              :vs-value="0"
              vs-name="radios3"
              >Nam</vs-radio
            >
            <vs-radio
              color="warning"
              v-model="editFormData.CategoryType"
              :vs-value="1"
              vs-name="radios3"
              >Nữ</vs-radio
            >
            <vs-radio
              color="rgb(87, 251, 187)"
              v-model="editFormData.CategoryType"
              :vs-value="2"
              vs-name="radios3"
              >Trẻ em</vs-radio
            >
          </div>
        </div>
        <div class="children-row">
          <table class="children-row--table">
            <tr class="children-row--row">
              <th>Tên thể loại con</th>
              <th>
                <div class="flex-center">Thứ tự</div>
              </th>
              <th>
                <div class="flex-center">
                  <vs-button
                    @click="formEditChildren()"
                    color="success"
                    type="border"
                    >Thêm</vs-button
                  >
                </div>
              </th>
            </tr>
            <tr
              v-for="item in editFormData.Children"
              :key="item.CategoryID"
              class="children-row--row"
            >
              <td>
                <vs-input
                  :danger="isExistsCategory"
                  danger-text="Thể loại này đã tồn tại"
                  placeholder="Áo polo"
                  v-model="item.CategoryName"
                />
              </td>
              <td>
                <vs-input-number v-model="item.SortOrder" />
              </td>
              <td>
                <div class="flex-center">
                  <vs-button
                    @click="formEditDeleteChildren(item)"
                    color="danger"
                    type="border"
                    >Xóa</vs-button
                  >
                </div>
              </td>
            </tr>
          </table>
        </div>
      </div>
      <div class="buttons">
        <vs-button @click="onConfirmEdit()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup title="Xóa thể loại" v-model:active="isShowPopupDelete">
    <div class="popup-content">
      <div class="content">Bạn có chắc chắn muốn xóa thể loại này?</div>
      <div class="buttons">
        <vs-button @click="confirmDelete()" color="primary" type="filled"
          >Xác nhận</vs-button
        >
      </div>
    </div>
  </vs-popup>
</template>
    
<script>
import API from "/src/service/api.js";
import { uuid } from "vue-uuid";
export default {
  name: "CategoryGrid",
  props: [],
  components: {},
  watch: {
    currentCategoryType(val, oldVal) {
      if (val != oldVal) {
        setTimeout(() => {
          this.getData();
        }, 100);
      }
    },
  },
  data() {
    return {
      currentCategoryType: 0,
      isShowPopupDelete: false,
      isShowEditForm: false,
      editFormData: {},
      api: new API("Categorys"),
      uuid: uuid.v1(),
      rowData: [],
      isExistsCategory: false,
      columns: [
        { field: "CategoryName", name: "Thể loại", type: 0 },
        { field: "SortOrder", name: "Thứ tự", type: 0 },
        { field: "CategoryID", type: 1 },
      ],
      isShowAddForm: false,
      addFormData: {
        CategoryType: 0,
        SortOrder: 1,
        Children: [],
      },
      isExistsName: false,
      deletingData: {},
      pageIndex: 1,
      currentSort: {},
    };
  },
  created() {
    this.getData();
  },
  methods: {
    onSort(e) {
      this.currentSort = e;
      this.getData();
    },
    onChangePage(e) {
      this.pageIndex = e;
      this.getData();
    },
    async getData() {
      const param = {
        PageSize: 100,
        PageNumber: this.pageIndex,
        SearchEquals: {
          CategoryType: this.currentCategoryType,
        },
        Sorter: this.currentSort,
      };

      const res = await this.api.paging(param);

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

      this.rowData = parents;
    },
    getDefaultChildren() {
      return {
        SortOrder: 1,
        CategoryID: uuid.v4(),
      };
    },
    showAddForm() {
      this.isShowAddForm = true;
      const newRow = this.getDefaultChildren();
      newRow.SortOrder = 1;

      this.addFormData = {
        CategoryType: this.currentCategoryType,
        SortOrder: this.rowData.length + 1,
        Children: [newRow],
      };
    },
    async onAdd() {
      const param = {
        CategoryName: this.addFormData.CategoryName,
        ParentID: null,
        CategoryType: `${this.addFormData.CategoryType}`,
      };

      this.isExistsName = await this.api.checkExisted(param);
      if (this.isExistsName) return;

      this.addFormData.Children = this.addFormData.Children.filter((e) =>
        e.CategoryName?.trim()
      );

      this.addFormData.Children.forEach((e) => {
        e.CategoryType = this.addFormData.CategoryType;
      });

      await this.api.add(this.addFormData);

      this.isShowAddForm = false;

      this.getData();
    },
    async onConfirmEdit() {
      const me = this;

      const deletingChildren = [];

      const raw = me.rowData.filter((e) => {
        return e.CategoryID == me.editFormData.CategoryID;
      })[0];

      const children = me.editFormData.Children.map((e) => e.CategoryID);

      raw.Children?.forEach((e) => {
        if (!children.includes(e.CategoryID)) {
          deletingChildren.push(e);
        }
      });

      if (deletingChildren.length) {
        await me.api.deleteMany(deletingChildren.map((e) => e.CategoryID));
      }

      this.editFormData.Children.forEach((e) => {
        e.CategoryType = this.editFormData.CategoryType;
      });

      await me.api.updateByID(me.editFormData.CategoryID, me.editFormData);

      for (
        let i = 0;
        me.editFormData.Children && i < me.editFormData.Children.length;
        i++
      ) {
        const e = me.editFormData.Children[i];
        if (!e.CategoryName) continue;

        e.ParentID = me.editFormData.CategoryID;

        const param = {
          CategoryID: e.CategoryID,
        };

        if (await me.api.checkExisted(param)) {
          await me.api.updateByID(e.CategoryID, e);
        } else {
          await me.api.add(e);
        }
      }

      me.isShowEditForm = false;

      this.getData();
    },
    onEdit(e) {
      this.isShowEditForm = true;

      this.editFormData = {};

      if (e.ParentID) {
        const arr = this.rowData.filter((x) => x.CategoryID == e.ParentID);

        if (arr.length) {
          this.editFormData = arr[0];
        }
      } else {
        this.editFormData = e;
      }

      this.editFormData = JSON.parse(JSON.stringify(this.editFormData));
    },
    onDelete(e) {
      this.isShowPopupDelete = true;
      this.deletingData = e;
    },
    async confirmDelete() {
      const ids = [this.deletingData.CategoryID];
      this.isShowPopupDelete = false;

      this.deletingData.Children?.forEach((e) => {
        ids.push(e.CategoryID);
      });

      await this.api.deleteMany(ids);

      this.getData();
    },
    formAddDeleteChildren(row) {
      this.addFormData.Children = this.addFormData.Children.filter(
        (e) => e.CategoryID != row.CategoryID
      );
    },
    formAddChildren() {
      const newRow = this.getDefaultChildren();
      newRow.SortOrder = this.addFormData.Children.length + 1;

      this.addFormData.Children.push(newRow);
    },
    formEditDeleteChildren(row) {
      this.editFormData.Children = this.editFormData.Children.filter(
        (e) => e.CategoryID != row.CategoryID
      );
    },
    formEditChildren() {
      const newRow = this.getDefaultChildren();
      newRow.SortOrder = this.editFormData.Children.length + 1;

      this.editFormData.Children.push(newRow);
    },
  },
};
</script>
    
    <style  lang="scss">
.children-row--table {
  border-collapse: collapse;

  tr,
  th,
  td {
    border: 1px solid #dfe2e5;
  }
  th,
  td {
    height: 40px;
    padding: 2px 10px;
    min-width: 100px;
  }
}
.type-row {
  display: flex;
  gap: 14px;
  user-select: none;
  margin-right: 8px;
}
.name-row {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: start;
}
.children-row {
  overflow-y: scroll;
  max-height: 400px;
  height: 400px;

  &::-webkit-scrollbar {
    width: 12px;
  }

  &::-webkit-scrollbar-thumb {
    background-color: #ccc;
    border-radius: 10px;
  }

  &::-webkit-scrollbar-track {
    background-color: #f1f1f1;
    border-radius: 10px;
  }

  &::-webkit-scrollbar-thumb:hover {
    background-color: #aaa;
  }
}
.expand-table--cell {
  width: 30%;
}
.filter-radios {
  display: flex;
  gap: 14px;
}
</style>
    