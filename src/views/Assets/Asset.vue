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
            v-bind:class="{ able: this.employeeSelected.EmployeeId != undefined }"
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
            <th fieldName="EmployeeCode">Mã tài sản</th>
            <th fieldName="EmployeeName" >Tên tài sản</th>
            <th style="width: 50px" fieldName="Gender">Loại tài sản</th>
            <th class="text-align-center" fieldName="DateOfBirth">HM/KH lũy kế</th>
            <th fieldName="PhoneNumber">Số lượng</th>
            <th fieldName="Email" >Nguyên giá</th>
            <th fieldName="DepartmentName" >Bộ phận sử dụng</th>
            <th class="text-align-right" fieldName="Salary">
              Giá trị còn lại
            </th>
            <th class="text-align-center">Chức năng</th>
          </tr>
        </thead>
        <tbody v-show="!isShowLoading">
            <tr
              @click="onClickRow($event, employee)"
              @dblclick="onDblclickRow()"
              v-bind:class="{
                selectedRow:
                  this.employeeSelected.EmployeeId == employee.EmployeeId,
              }"
              v-for="(employee,index) in employees"
              :key="employee.EmployeeId"
            >
              <!-- <td><input type="checkbox" value="" /></td> -->
              <td>
                <div ref="checkbox" class="m-checkbox" 
                  v-bind:class="{
                    checked:
                      this.employeeSelected.EmployeeId == employee.EmployeeId,
                  }">
                  <i class="fas fa-check"></i>
                </div>
              </td>
              <td>{{ index+1 }}</td>
              <td>{{ employee.EmployeeCode }}</td>
              <td >{{ employee.EmployeeName }}</td>
              <td style="width: 50px">
                {{ getValueEnum(employee.Gender, "Gender") }}
              </td>
              <td class="align-center">
                {{ formatDate(employee.DateOfBirth) }}
              </td>
              <td>{{ employee.PhoneNumber }}</td>
              <td >{{ employee.Email }}</td>
              <!-- <td></td> -->
              <td >{{ employee.DepartmentName }}</td>
              <td class="align-right">{{ formatMoney(1000000) }}</td>
              <td class="text-align-center action feature">
                <i
                @click="rowOnClick(emp)"
                style="font-size: 17px; color: #138496; margin-right: 10px"
                class="far fa-edit edit-form-employee"
              ></i>
              <i
                v-on:click="deleteEmployee(emp)"
                style="font-size: 17px; color: red"
                class="text-align-center far fa-trash-alt btnDelete"
              ></i>
              </td>
            </tr>
        </tbody>
        
      </table>
      <div class="summary">
        <p>Tổng số: <b>{{employees.length}}</b> bản ghi</p>
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
      :isShow="form.isShowForm"
      @closeForm="closeForm"
      >
    </asset-detail>


    <!-- Dialog xác nhận xóa hoặc cảnh báo -->
    <the-dialog
      v-bind:isShowDialog="dialog.isShowDialog"
      v-bind:title="dialog.title"
      v-bind:message="dialog.message"
      v-bind:isShowBtnCancel="dialog.isShowBtnCancel"
      v-bind:employeeCode="dialog.employeeCode || ``"
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
import EmployeeDetail from "./EmployeeDetail.vue";
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

import $ from 'jquery'

export default {
  name: "TheEmployee",
  components: {
    EmployeeDetail,
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
      employees: { type: Object, default: {} },
      employeeSelected: {},
      isShowLoading: { type: Boolean, default: false },

      // Phục vụ cho Form nhân viên
      form: {
        isShowForm: false,
        formMode: { type: Number, default: 0 },
      },

      // Phục vụ cho Dialog
      dialog: {
        isShowDialog: false,
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
      departments: Combobox.getDepartment("Employee"),
      positions: Combobox.getPosition("Employee"),
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
      me.employee = {};
    },

    // Đóng form detail
    closeForm() {
      let me = this;
      me.form = {
        isShowForm: false,
        formMode: 0,
      };
    },

    // Sự kiện select row
    onClickRow(event, employeeSelected) {
      let me = this;
      me.employeeSelected = employeeSelected;
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
      if (me.employeeSelected.EmployeeCode != undefined) {
        me.dialog = DialogJS.Delete(me.employeeSelected.EmployeeCode);
      } else {
        console.log("Chưa chọn employee nào");
      }
    },

    // Sự kiện click vào button Edit
    onClickEdit() {
      let me = this;
      if (me.employeeSelected.EmployeeCode != undefined) {
        me.onDblclickRow();
      } else {
        console.log("Chưa chọn employee nào");
      }
    },

    // Lưu dữ liệu
    handleSave(employeeForm) {
      var me = this,
        method = null,
        url = Constant.urlEmployee,
        data = employeeForm,
        message = "";

      switch (me.form.formMode) {
        case Enumeration.FormMode.Add:
          method = Resource.Method.Post;
          message = Resource.Toast.Add;
          break;
        case Enumeration.FormMode.Edit:
          method = Resource.Method.Put;
          message = Resource.Toast.Edit;
          url = `${url}/${employeeForm.EmployeeId}`;
          break;
      }
      // call axios
      CommonFn.Axios(method, url, data, function (response) {
        if (response != null) {
          // Load lại dữ liệu table
          me.loadingEmployees();

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
        url = `${Constant.urlEmployee}/${me.employeeSelected.EmployeeId}`;
        // call axios delete
        CommonFn.Axios(Resource.Method.Delete, url, {}, function (response) {
          console.log(response);
          me.loadingEmployees();
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
        //employeeCode: null,
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
    loadingEmployees() {
      let me = this,
        method = Resource.Method.Get,
        url = Constant.urlEmployee,
        data = {};

      // hiện image loading
      me.isShowLoading = true;

      // call axios lấy dữ liệu
      CommonFn.Axios(method, url, data, function (response) {
        // load dữ liệu vào bảng
        me.employees = response.data;
      });

      // Reset lại item được chọn
      me.employeeSelected = {};
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
    me.loadingEmployees();
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
