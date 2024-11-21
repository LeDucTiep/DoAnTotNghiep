<template>
  <vs-table
    :multiple="multiple"
    :sst="true"
    :search="search"
    v-model="selected"
    :pagination="!!pageSize"
    :max-items="pageSize"
    :data="dataSource"
    @change-page="handleChangePage"
    :total="total"
    @sort="handleSort"
    maxHeight="700px"
  >
    <template #header> </template>
    <template #thead>
      <vs-th
        v-for="(item, index) in columns"
        :key="index"
        :sort-key="item.field"
      >
        {{ item.name }}
      </vs-th>
    </template>

    <template v-slot="{ data }">
      <vs-tr :data="tr" :key="indextr" v-for="(tr, indextr) in data">
        <vs-td
          v-for="(col, index) in columns"
          :key="index"
          :data="tr[col.field]"
        >
          <div v-if="col.type == 1" class="cell">
            <div class="menu-table-buttons">
              <vs-button
                @click.stop="onEdit($event, tr)"
                color="primary"
                type="border"
                >Sửa</vs-button
              >
              <vs-button
                @click.stop="onDelete($event, tr)"
                color="danger"
                type="border"
                >Xóa</vs-button
              >
            </div>
          </div>
          <div v-else-if="col.type == 2" class="cell">
            <ColorComponent :colorCode="tr[col.field]"></ColorComponent>
          </div>
          <div v-else-if="col.type == 10" class="cell">
            <PictureComponent :ids="tr[col.field]"></PictureComponent>
          </div>
          <div v-else class="cell">
            {{ tr[col.field] }}
          </div>
        </vs-td>

        <template v-if="tr.Children && tr.Children.length" #expand>
          <table class="expand-table">
            <tr
              :key="i"
              v-for="(row, i) in tr.Children"
              class="expand-table--row"
            >
              <td
                class="expand-table--cell"
                v-for="(col, j) in columns"
                :key="j"
                :data="row[col.field]"
              >
                <div v-if="col.type == 1" class="cell">
                  <div class="menu-table-buttons">
                    <vs-button
                      @click.stop="onEdit($event, row)"
                      color="primary"
                      type="border"
                      >Sửa</vs-button
                    >
                    <vs-button
                      @click.stop="onDelete($event, row)"
                      color="danger"
                      type="border"
                      >Xóa</vs-button
                    >
                  </div>
                </div>
                <div v-else-if="col.type == 2" class="cell">
                  <ColorComponent :colorCode="row[col.field]"></ColorComponent>
                </div>
                <div v-else class="cell">
                  {{ row[col.field] }}
                </div>
              </td>
            </tr>
          </table>
        </template>
      </vs-tr>
    </template>
  </vs-table>
</template>
    
<script>
import ColorComponent from "./ColorComponent";
import PictureComponent from "./PictureComponent";
export default {
  name: "TGrid",
  props: {
    search: {
      default: false,
    },
    multiple: {
      default: true,
    },
    columns: {
      default: [],
    },
    dataSource: {
      default: [],
    },
    // selected
    modelValue: {
      default: [],
    },
    pageSize: {
      default: 100,
    },
    total: {
      default: 0,
    },
  },
  emits: ["update:modelValue", "edit", "delete", "sort", "changePage"],
  components: { ColorComponent, PictureComponent },
  computed: {
    selected: {
      get() {
        return this.modelValue;
      },
      set(val) {
        this.$emit("update:modelValue", val);
      },
    },
  },
  data() {
    return {};
  },
  beforeMount() {},
  methods: {
    onEdit(e, row) {
      e.preventDefault();
      this.$emit("edit", row);
    },
    onDelete(e, row) {
      e.preventDefault();
      this.$emit("delete", row);
    },
    handleChangePage(page) {
      this.$emit("changePage", page);
    },
    handleSort(key, active) {
      const param = {};

      if (active) {
        param[key] = active;
      }

      this.$emit("sort", param);
    },
  },
};
</script>
    
    <style  lang="scss">
.con-tablex.vs-table--content {
  input.vs-checkbox--input {
    height: 40px;
  }
  .vs-checkbox-primary.vs-checkbox-small.vs-component.con-vs-checkbox {
    height: 40px;
  }
  tr {
    border-top: 1px solid #dfe2e5;
  }
  .con-td-check,
  .td-check {
    width: 50px;
  }
  * {
    font-size: 14px;
  }
  .vs-table-text {
    height: 40px;
  }

  .expand-table {
    tr,
    td {
      border-top: 1px solid #dfe2e5;
      border-bottom: 1px solid #dfe2e5;
    }
    td {
      height: 40px;
    }
  }
  .content-tr-expand {
    padding-left: 75px;
    padding-right: 0px;
  }
  .expand-table--cell {
    padding: 10px;
  }
  .menu-table-buttons {
    justify-content: end;
  }

  td.td-check:not(:has(.vs-checkbox--input))::before {
    content: "";
    display: inline-block;
    width: 20px;
    height: 20px;
    background-image: url("../../assets/images/expand-row.png");
    background-size: contain;
    transition-duration: 0.5s;
    transform: rotate(-90deg);
    margin-right: 10px;
  }
  td.active-expanded.td-check:not(:has(.vs-checkbox--input))::before {
    transform: rotate(0deg);
  }

  .vs-con-tbody.vs-table--tbody {
    &::-webkit-scrollbar {
      width: 6px;
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
}
</style>
    