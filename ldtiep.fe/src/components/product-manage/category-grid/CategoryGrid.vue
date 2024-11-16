<template>
  <div class="table-head">
    <div></div>
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
              :danger="isExistsCategory"
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
              v-model="addFormData.CategoryType"
              :vs-value="0"
              >Nam</vs-radio
            >
            <vs-radio
              color="warning"
              v-model="addFormData.CategoryType"
              :vs-value="1"
              >Nữ</vs-radio
            >
            <vs-radio
              color="rgb(87, 251, 187)"
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
                <vs-button
                  @click="formAddChildren()"
                  color="success"
                  type="border"
                  >Thêm</vs-button
                >
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
                <vs-button
                  @click="formAddDeleteChildren(item)"
                  color="danger"
                  type="border"
                  >Xóa</vs-button
                >
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
</template>
    
<script>
import { uuid } from "vue-uuid";
export default {
  name: "CategoryGrid",
  props: [],
  components: {},
  data() {
    return {
      uuid: uuid.v1(),
      rowData: [
        {
          CategoryName: "Nam",
          CategoryID: 1234,
          Children: [
            {
              CategoryID: 2213,
              CategoryName: "Quần nam",
            },
          ],
        },
      ],
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
    };
  },
  beforeMount() {},
  methods: {
    getDefaultChildren() {
      return {
        SortOrder: this.addFormData.Children.length + 1,
        CategoryID: uuid.v4(),
      };
    },
    onSelectionChanged(e) {
      const selected = e.api.getSelectedNodes();

      console.log(selected);
    },
    deleteSelected() {},
    showAddForm() {
      this.isShowAddForm = true;
      const newRow = this.getDefaultChildren();
      this.addFormData = {
        CategoryType: 0,
        SortOrder: 1,
        Children: [newRow],
      };
    },
    onAdd() {},
    onEdit(e) {
      console.log(e);
    },
    onDelete(e) {
      console.log(e);
    },
    formAddDeleteChildren(row) {
      this.addFormData.Children = this.addFormData.Children.filter(
        (e) => e.CategoryID != row.CategoryID
      );
    },
    formAddChildren() {
      const newRow = this.getDefaultChildren();
      this.addFormData.Children.push(newRow);
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
</style>
    