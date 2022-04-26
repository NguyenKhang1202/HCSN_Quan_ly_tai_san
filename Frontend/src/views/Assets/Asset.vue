<template>
  <div class="content">
    <!-- header -->
    <div class="content-header">
      <!-- filter -->
      <div class="content-filter">
        <div class="filter-left">
          <div class="search-assets">
            <input
              type="text"
              class="search-box input-search"
              placeholder="Tìm kiếm tài sản"
            />
          </div>
          <Combobox-filter 
            title="Chọn phòng ban"
            api="http://amis.manhnv.net/api/v1/Departments"
            valueOption="DepartmentId"
            nameOption="DepartmentName"
            class="m-combobox-filter"
            />
          <Combobox-filter class="m-combobox-filter" />
        </div>
      </div>
        <div class="content-feature">
          <button
            class="m-btn"
            @click="open"
          >
            + Thêm tài sản
          </button>
          <button
            @click="onClickEdit"
            class="m-btn-content-header m-btn-excel disabled tooltip"
          >
            <span class="tooltiptext">Excel</span>
          </button>
          <button
            @click="onClickDelete"
            class="m-btn-content-header m-btn-delete disabled tooltip"
            v-bind:class="{ able: this.assetSelected.fixed_asset_id != undefined }"
          >
            <span class="tooltiptext">Xóa</span>
          </button>  
        </div>
      </div>


    <!-- start table -->
    <div class="wrap-content">
      <table id="" class="table">
        <thead>
          <tr>
            <th style="padding-right: 0">
              <div ref="checkbox" class="m-checkbox">
                <i class="fas fa-check"></i>
              </div>
            </th>
            <th>STT</th>
            <th fieldName="assetCode">Mã tài sản</th>
            <th fieldName="AssetName" >Tên tài sản</th>
            <th style="width: 50px" fieldName="AssetCategory">Loại tài sản</th>
            <th class="text-align-right" fieldName="">HM/KH lũy kế</th>
            <th fieldName="Quantity" class="align-right">Số lượng</th>
            <th fieldName="Cost" class="align-right">Nguyên giá</th>
            <th fieldName="DepartmentName" >Bộ phận sử dụng</th>
            <th class="text-align-center">Chức năng</th>
          </tr>
        </thead>
        <tbody v-show="!isShowLoading">
            <tr
              @click="onClickRow($event, asset)"
              @dblclick="onDblclickRow()"
              v-bind:class="{
                selectedRow:
                  this.assetSelected.fixed_asset_id == asset.fixed_asset_id,
              }"
              v-for="(asset,index) in fixedAssets"
              :key="asset.fixed_asset_id"
            >
              <td>
                <div ref="checkbox" class="m-checkbox" 
                  v-bind:class="{
                    checked:
                      this.assetSelected.fixed_asset_id == asset.fixed_asset_id,
                  }">
                  <i class="fas fa-check"></i>
                </div>
              </td>
              <td class="text-align-center">{{ index+1 }}</td>
              <td>{{ asset.fixed_asset_code }}</td>
              <td >{{ asset.fixed_asset_name }}</td>
              <td >
                {{ asset.fixed_asset_category_name }}
              </td>
              <td class="align-right">
                {{ 0 }}
              </td>
              <td class="align-right">{{ asset.quantity }}</td>
              <td class="align-right">{{ formatMoney(asset.cost) }}</td>
              <td >{{ asset.department_name }}</td>
              <td class="text-align-center action feature">
                <i
                @click="rowOnClick(asset)"
                style="font-size: 17px; color: #138496; margin-right: 10px"
                class="far fa-edit edit-form-Asset"
              ></i>
              <i
                v-on:click="deleteAsset(asset)"
                style="font-size: 17px; color: red"
                class="text-align-center far fa-trash-alt btnDelete"
              ></i>
              </td>
            </tr>
            <tr class="summary-table"></tr>
        </tbody>
        
      </table>
      <div class="summary">
        <p>Tổng số: <b>{{fixedAssets.length}}</b> bản ghi</p>
        <SelectCustom @bind-ValueSelect="getValueSelect" />
        <div class="pagination">
                <div class="pagination-back"></div>
                <div class="number-page">
                  <a
                    v-for="(page,index) in pages"
                    :key="index"
                    href="#"
                    :class="{'pagination-active': index == this.currentPage}"
                    @click.prevent="handlePagination(index + 1)"
                  >{{index + 1}}</a>
                </div>
                <div class="pagination-next"></div>
                <div class="refresh" @click="loadingData"></div>
              </div>
      </div>
      <TheLoading v-show="isShowLoading" />
    </div>
    <!-- end table -->

    <asset-detail
      :isShowForm="form.isShowForm"
      :formMode="form.formMode"
      :fixedAsset="assetSelected"
      @closeForm="closeForm"
      @handleSave="handleSave"
    />

    <!-- Dialog xác nhận xóa hoặc cảnh báo -->
    <the-dialog
      v-bind:isShowDialog="dialog.isShowDialog"
      v-bind:title="dialog.title"
      v-bind:message="dialog.message"
      v-bind:isShowBtnCancel="dialog.isShowBtnCancel"
      v-bind:assetCode="dialog.assetCode || ``"
      @handleCloseDialog="handleCloseDialog"
      @handleConfirmDialog="handleConfirmDialog"
    />

    <!-- Toast message thông báo thành công -->
    <the-toast-message
      @handleCloseToast="handleCloseToast"
      v-bind:isShowToast="toast.isShowToast"
      v-bind:message="toast.message"
    />
  </div>
</template>

<script>
/* eslint-disable */
import SelectCustom from "../../components/base/SelectCustom/SelectCustom.vue";
import TheLoading from "../../components/base/TheLoading.vue";
import TheDialog from "../../components/base/TheDialog.vue";
import TheToastMessage from "../../components/base/ToastMessage.vue";
import CommonFn from "../../js/Common/Common.js";
import Combobox from "../../js/Components/Combobox.js";
import DialogJS from "../../js/Components/Dialog.js";
import Resource from "../../js/Common/Resource";
import Constant from "../../js/Common/Constant";
import Enumeration from "../../js/Common/Enumeration";
import ComboboxFilter from "../../components/base/ComboboxFilter/ComboboxFilter";
import AssetDetail from "./AssetDetail.vue";
// import $ from 'jquery'

export default {
  name: "TheAsset",
  components: {
    TheDialog,
    TheToastMessage,
    TheLoading,
    ComboboxFilter,
    SelectCustom,
    AssetDetail,
  },
  props: [],
  data() {
    return {
      /*
        Phục vụ chung
        CreateBy : Nguyễn Văn Khang 30/3/2022
      */
      fixedAssets: { type: Object, default: {} },
      assetSelected: {},
      isShowLoading: { type: Boolean, default: false },

      // Phục vụ cho Form asset
      form: {
        isShowForm: false,
        formMode: { type: Number, default: 0 },
      },

      // Phục vụ cho Dialog
      dialog: {
        isShowDialog: false,
        assetCode: "",
        title: "",
        message: "",
        isShowBtnCancel: false,
      },

      // Phục vụ cho Toast message
      toast: {
        isShowToast: false,
        message: { type: String, default: "" },
      },

      // Lấy dữ liệu từ server và build combobox
      departments: Combobox.getDepartment("Asset"),
      positions: Combobox.getPosition("Asset"),
    };
  },
  
  methods: {
    // Các hàm format 
    formatDate: CommonFn.formatDate,
    convertDate: CommonFn.convertDate,
    getValueEnum: CommonFn.getValueEnum,
    formatMoney: CommonFn.formatMoney,

    // mở form detail
    open() {
      let me = this;
      me.form = {
        isShowForm: true,
        formMode: Enumeration.FormMode.Add,
      };
      me.Asset = {};
    },

    // Đóng form detail
    closeForm() {
      let me = this;
      me.form = {
        isShowForm: false,
        formMode: 0,
      };
    },

    // Sự kiện click btn Delete trên từng hàng
    deleteAsset(Asset) {
      let me = this;
      me.assetSelected = Asset;
      me.onClickDelete();
    },
    // Sự kiện select row
    onClickRow(event, assetSelected) {
      let me = this;
      me.assetSelected = assetSelected;
    },

    // Sự kiện double select row
    onDblclickRow() {
      let me = this;
      me.form = {
        isShowForm: true,
        formMode: Enumeration.FormMode.Edit,
      };
    },

    // Sự kiện click button Delete
    onClickDelete() {
      let me = this;
      if (me.assetSelected.fixed_asset_code != undefined) {
        me.dialog = DialogJS.Delete(me.assetSelected.fixed_asset_code);
      } else {
        console.log("Chưa chọn Asset nào");
      }
    },

    // Sự kiện click vào button Edit
    onClickEdit() {
      let me = this;
      if (me.assetSelected.fixed_asset_code != undefined) {
        me.onDblclickRow();
      } else {
        console.log("Chưa chọn Asset nào");
      }
    },

    // Lưu dữ liệu
    handleSave(assetsForm) {
      var me = this,
        method = null,
        url = Constant.urlAssets,
        data = assetsForm,
        message = "";

      switch (me.form.formMode) {
        case Enumeration.FormMode.Add:
          method = Resource.Method.Post;
          message = Resource.Toast.Add;
          break;
        case Enumeration.FormMode.Edit:
          method = Resource.Method.Put;
          message = Resource.Toast.Edit;
          url = `${url}/${assetsForm.fixed_asset_id}`;
          break;
      }
      // call axios
      CommonFn.Axios(method, url, data, function (response) {
        if (response != null) {
          // Load lại dữ liệu table
          me.loadingAssets();

          // Đóng Form
          me.closeForm();

          // Hiển thị Toast message
          me.showToast(message);
        }
      }, function (error){
        // hiển thị dialog thông báo lỗi đc gửi từ server
        me.dialog = DialogJS.Warning(error.response.data.devMsg);
      });
    },

    // Hiển thị thông báo lỗi
    validateForm(message) {
      let me = this;
      me.dialog = DialogJS.Warning(message);
    },

    // Hàm xử lý sự kiện click CONFIRM DELETE button
    handleConfirmDialog() {
      let me = this,
        url = "";
      if (me.dialog.isShowBtnCancel == false) {
        me.handleCloseDialog();
      } else {
        url = `${Constant.urlAssets}/${me.assetSelected.fixed_asset_id}`;
        // call axios delete
        CommonFn.Axios(Resource.Method.Delete, url, {}, function (response) {
          console.log(response);
          me.loadingAssets();
          me.showToast(Resource.Toast.Delete);
        });
      }
      // Đóng dialog delete và reset
      me.handleCloseDialog();
    },

    // Hàm xử lý sự kiện click CANCEL DELETE button
    handleCloseDialog() {
      let me = this;
      me.dialog = {
        isShowDialog: false,
        isShowBtnCancel: false,
        title: "",
        message: "",
      };
    },

    // Đóng toast message
    handleCloseToast() {
      let me = this;
      me.toast = {
        isShowToast: false,
      };
    },

    // Hiển thị toast message
    showToast(message) {
      let me = this;
      (me.toast = {
        isShowToast: true,
        message,
      }),
        setTimeout(() => {
          me.toast = {
            isShowToast: false,
          };
        }, 3000);
    },

    // Hàm load lại dữ liệu trên table
    loadingAssets() {
      let me = this,
        method = Resource.Method.Get,
        url = Constant.urlAssets,
        data = {};

      // hiện image loading
      me.isShowLoading = true;

      // call axios lấy dữ liệu
      CommonFn.Axios(method, url, data, function (response) {
        // load dữ liệu vào bảng
        me.fixedAssets = response.data;
      });

      // Reset lại item được chọn
      me.assetSelected = {};
      setTimeout(() => {
        me.isShowLoading = false;
      }, 300);
    },

    // Sự kiện click vào checkbox
    checkboxOnClick(trSelected){
      let tr = $('tbody tr .m-checkbox');
      $.each(tr, (item) => {
        if($(item).hasClass('checked')){
          $(item).removeClass('checked');
        }
      })
      $(trSelected).addClass('checked');
    },
  },

  /* 
    2. created
  */
  created() {
    console.log("Created");
    let me = this;
    // Tải dữ liệu lên bảng
    me.loadingAssets();
  },
};
</script>

<style>
.align-center {
  text-align: center;
}
.align-right {
  text-align: right;
}

.disabled:hover {
  cursor: context-menu !important;
}

#btnDelete.able,
#btnEdit.able {
  background-color: white;
  cursor: pointer;
}

#btnDelete.able:hover,
#btnEdit.able:hover {
  background-color: #eeeeee;
}
#btnDelete,
#btnEdit {
  position: relative;
}

.refresh-text {
  margin-left: -100px;
}


</style>
