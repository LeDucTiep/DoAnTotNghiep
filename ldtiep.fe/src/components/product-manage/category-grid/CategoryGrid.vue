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
          <vs-input
            :danger="isExistsCategory"
            danger-text="Thể loại này đã tồn tại"
            label="Tên thể loại"
            placeholder="Trẻ em"
            v-model="addFormData.CategoryName"
          />
        </div>
        .d
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
export default {
  name: "CategoryGrid",
  props: [],
  components: {},
  data() {
    return {
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
        { field: "CategoryID", type: 1 },
      ],
      isShowAddForm: false,
      addFormData: {},
    };
  },
  beforeMount() {},
  methods: {
    onSelectionChanged(e) {
      const selected = e.api.getSelectedNodes();

      console.log(selected);
    },
    deleteSelected() {},
    showAddForm() {
      this.isShowAddForm = true;
    },
    onAdd() {},
    onEdit(e) {
      console.log(e);
    },
    onDelete(e) {
      console.log(e);
    },
  },
};
</script>
    
    <style  lang="scss">
</style>
    