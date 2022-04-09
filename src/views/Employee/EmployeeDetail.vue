<template>
  <!-- modal -->
  <div
    id="formEmployeeDetail"
    class="dialog formDetail"
    v-bind:class="{ open: isShow }"
  >
    <div class="dialog-content">
      
      <!-- cập nhật ảnh  -->
      <div class="dialog-content-header">THÔNG TIN NHÂN VIÊN</div>
      <div class="dialog-content-left">
        <input type="file" id="file" accept="image/*" />
        <label for="file">
          <div class="icon icon-160 circle-icon input-image-icon"></div>
          <div class="input-image-title">( Vui lòng chọn ảnh có định dạng</div>
          <div class="input-image-title">.jpg, .jpeg, .png. .gif. )</div>
        </label>
      </div>
      <!-- end phần cập nhật ảnh -->

      <!-- phần form bên phải -->
      <div class="dialog-content-between">
        <div class="dialog-content-top">
          <div class="content-title">
            <div class="title-text">A. THÔNG TIN CHUNG:</div>
            <div class="title-decor"></div>
          </div>
          <div class="content-between-element">
            <div class="element">
              <div class="between-element-title">
                Mã nhân viên (<span class="m-label-red">*</span>)
              </div>
              <input
                id="txtEmployeeCode"
                tabindex="1"
                v-model="employeeForm.EmployeeCode"
                @focus="focusItem"
                ref="txtEmployeeCode"
                class="input-dialog-employee"
                FieldName="EmployeeCode"
                autofocus
                Require="true"
                @blur="handleBlur"
              />
            </div>
            <div class="element">
              <div class="between-element-title">
                Họ và tên (<span class="m-label-red">*</span>)
              </div>
              <input
                id="txtFullName"
                tabindex="2"
                v-model="employeeForm.EmployeeName"
                type="text"
                class="input-dialog-employee"
                FieldName="EmployeeName"
                Require="true"
                @blur="handleBlur"
              />  
            </div>
          </div>
          <div class="content-between-element">
            <div class="element">
              <div class="between-element-title">Ngày sinh</div>
              <input
                type="date"
                tabindex="3"
                v-model="employeeForm.DateOfBirth"
                id="dateOfBirth"
                name="birthday"
                FieldName="DateOfBirth"
                class="input-dialog-employee"
                DataType="Date"
                Require="true"
                @blur="handleBlur"
              />
            </div>
            <div class="element">
              <div class="between-element-title">Giới tính</div>
              <div class="between-element-box">
                <!-- items : dữ liệu để build combobox -->
                <!-- employeeForm : truyền toàn bộ dữ liệu form sang combobox để bind combobox -->
                <!-- bindDataForm : sự kiện khi thay đổi lựa chọn trên combobox sẽ gửi lại dữ liệu lên form để gửi lên server -->
                <combobox-component
                  :items="genders"
                  @bindDataForm="bindDataForm"
                  v-bind:employeeForm="employeeForm.Gender"
                  tabindex=""
                />
              </div>
            </div>
          </div>
          <div class="content-between-element">
            <div class="element">
              <div class="between-element-title">
                Số CMND/ Căn cước(<span class="m-label-red">*</span>)
              </div>
              <input id="txtCMND" type="text" class="input-dialog-employee" />
            </div>
            <div class="element">
              <div class="between-element-title">Ngày cấp</div>
              <input
                type="date"
                id="cmt-date"
                name="cmt-date"
                class="input-dialog-employee"
                tabindex=""
              />
            </div>
          </div>
          <div class="content-between-element">
            <div class="element">
              <div class="between-element-title">Nơi cấp</div>
              <input type="text" class="input-dialog-employee" />
            </div>
          </div>
          <div class="content-between-element">
            <div class="element">
              <div class="between-element-title">
                Email (<span class="m-label-red">*</span>)
              </div>
              <input
                id="txtEmail"
                tabindex="4"
                v-model="employeeForm.Email"
                type="email"
                class="input-dialog-employee"
                DataType="Email"
                FieldName="Email"
                Require="true"
                @blur="handleBlur"
              />
            </div>
            <div class="element">
              <div class="between-element-title">
                Số điện thoại (<span class="m-label-red">*</span>)
              </div>
              <input
                id="txtPhoneNumber"
                tabindex=""
                v-model="employeeForm.PhoneNumber"
                type="text"
                DataType="Number"
                FieldName="PhoneNumber"
                Require="true"
                class="input-dialog-employee"
                @blur="handleBlur"
              />
            </div>
          </div>
        </div>
        <div class="dialog-content-bottom">
          <div class="content-title">
            <div class="title-text">B. THÔNG TIN CÔNG VIỆC:</div>
            <div class="title-decor"></div>
          </div>
          <div class="content-between-element">
            <div class="content-between-element">
              <div class="element">
                <div class="between-element-title">Vị trí</div>
                <div class="between-element-box">
                  <!-- items : dữ liệu để build combobox -->
                  <!-- employeeForm : truyền toàn bộ dữ liệu form sang combobox để bind combobox -->
                  <!-- bindDataForm : sự kiện khi thay đổi lựa chọn trên combobox sẽ gửi lại dữ liệu lên form để gửi lên server -->
                  <combobox-component
                    :items="positions"
                    @bindDataForm="bindDataForm"
                    v-bind:employeeForm="employeeForm.PositionId"
                  />
                </div>
              </div>
              <div class="element">
                <div class="between-element-title">Phòng ban</div>
                <div class="between-element-box">
                  <!-- items : dữ liệu để build combobox -->
                  <!-- employeeForm : truyền toàn bộ dữ liệu form sang combobox để bind combobox -->
                  <!-- bindDataForm : sự kiện khi thay đổi lựa chọn trên combobox sẽ gửi lại dữ liệu lên form để gửi lên server -->
                  <combobox-component
                    :items="departments"
                    @bindDataForm="bindDataForm"
                    v-bind:employeeForm="employeeForm.DepartmentId"
                    :Require="true"
                    @handleBlur="handleBlur"
                    tabindex="5"
                  />
                </div>
              </div>
            </div>
          </div>
          <div class="content-between-element">
            <div class="content-between-element">
              <div class="element">
                <div class="between-element-title">Mã số thuế cá nhân</div>
                <input type="text" class="input-dialog-employee" />
              </div>
              <div class="element">
                <div class="between-element-title">Mức lương cơ bản</div>
                <input
                  id="numSalary"
                  type="number"
                  class="input-dialog-employee text-align-right"
                  DataType="Number"
                />
              </div>
            </div>
          </div>
          <div class="content-between-element">
            <div class="content-between-element">
              <div class="element">
                <div class="between-element-title">Ngày gia nhập công ty</div>
                <input
                  type="date"
                  id="date-join-company"
                  name="date-join-company"
                  class="input-dialog-employee"
                />
              </div>
              <div class="element">
                <div class="between-element-title">Tình trạng công việc</div>
                <div class="between-element-box">
                  <combobox-component
                    :items="workStatus"
                    @bindDataForm="bindDataForm"
                    v-bind:employeeForm="employeeForm.WorkStatusId"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- end form -->

      <div class="dialog-content-footer">
        <button
          id="btnSave"
          @click="handleSave"
          type="submit"
          Command="Save"
          class="m-btn m-btn-save btnForm"
        >
          <i class="far fa-save icon-save"></i>Lưu
        </button>
        <button
          id="btnCancel"
          @click="handleCancel"
          Command="Cancel"
          class="m-btn m-btn-destroy btnForm"
        >
          Hủy
        </button>
      </div>
      <!-- </form> -->
    </div>
  </div>
</template>

<script>
/* eslint-disable */
import CommonFn from "../../js/Common/Common.js";
import Resource from "../../js/Common/Resource";
import Constant from "../../js/Common/Constant";
import Combobox from "../../js/Components/Combobox";
import ValidateForm from "../../js/Validate/ValidateForm";
import Enumeration from "../../js/Common/Enumeration";
import ComboboxComponent from "../../components/base/Combobox.vue";

export default {
  name: "EmployeeDetail",
  components: {
    ComboboxComponent,
  },

  // Là các giá trị nhận được từ Employee
  props: {
    // ẩn hiện form
    isShow: {
      type: Boolean,
      default: false,
    },

    // là dữ liệu nhận được khi FormMode là Edit
    employee: {
      type: Object,
    },

    /*  
        Add : 1 
        Edit : 2 
    */
    formMode: Number,
  },

  // Các giá trị của chính EmployeeDetail
  data() {
    return {
      // Là dữ liệu trên Form
      employeeForm: { type: Object, default: {} },

      // Kết quả validate
      isValid: true,

      // Lấy dữ liệu từ server và build combobox
      departments: Combobox.getDepartment("EmployeeDetail"),

      positions: Combobox.getPosition("EmployeeDetail"),

      genders: Combobox.getGender("EmployeeDetail"),

      workStatus: "",
    };
  },

  // Theo dõi sự thay đổi và reload
  watch: {
    /* 
        Mỗi khi thực hiện edit sẽ đặt lại employeeForm
        Đồng thời convert để bind Date 
    */
    employee: function (employeeEdit) {
      let me = this;
      me.employeeForm = employeeEdit;
      me.employeeForm.DateOfBirth = CommonFn.convertDate(employeeEdit.DateOfBirth);
    },

    /* 
        Mỗi khi Form show sẽ nhận EmployeeCode từ server 
    */
    isShow: function () {
      let me = this;
      if (me.isShow == true && me.formMode == Enumeration.FormMode.Add) {
        let url = Constant.urlNewEmployeeCode,
          method = Resource.Method.Get,
          data = {};
        // reset form
        me.employeeForm = {};
        try {
          CommonFn.Axios(method, url, data, function (response) {
            // gán EmployeeCode lên form (khi thêm mới)
            me.employeeForm.EmployeeCode = response.data;
            me.$refs.txtEmployeeCode.focus();
          }, function (error) {
            me.$emit("validateForm", error.response.data.devMsg);
          });
        } catch (error) {
          console.log(error);
        }
      }
      me.$refs.txtEmployeeCode.focus();
    },
  },

  methods: {
    /* 
        Sự kiện click Cancel button
        CreateBy: Nguyễn Văn Khang 30/03/2022
    */
    handleCancel() {
      let me = this;
      // me.resetForm();
      me.$emit("closeForm");
    },
    /* 
        Sự kiện click Save button
    */
    handleSave() {
      let me = this;
      if (me.validateForm() == true) {
        me.$emit("handleSave", me.employeeForm);
      } else {
        console.log("Xảy ra lỗi khi validate form");
      }
    },

    // Lấy dữ liệu combobox 
    bindDataForm({ fieldName, item }) {
      let me = this;
      switch (fieldName) {
        case "Department":
          me.employeeForm.DepartmentId = item.id;
          break;
        case "Gender":
          me.employeeForm.Gender = item.id;
          break;
        case "Position":
          me.employeeForm.PositionId = item.id;
          break;
      }
    },

    // Reset dữ liệu form
    resetForm() {
      
    },

    // Sự kiện blur trên input
    handleBlur(e){
      let element = e.target;
      console.log(element)
      if(element.value == "") {
        element.classList.add("notValidControl");
        element.title = "Vui lòng không được để trống"
      }else {
        element.classList.remove("notValidControl");
      }
    },

    // validate form
    validateForm() {
      let me = this,
        isValid = me.validateRequire(); // Validate các trường bắt buộc nhập

      if (isValid) {
        isValid = me.validateFieldNumber(); // Validate các trường nhập  số
      }
      if (isValid) {
        isValid = me.validateFieldDate(); // Validate các trường ngày tháng
      }
      if (isValid) {
        isValid = me.validateEmail(); // Validate trường email
      }
      if (isValid) {
        isValid = me.validateCustom(); // Validate các trường hợp đặc biệt khác
      }
      return isValid;
    },

    // Validate các trường bắt buộc
    validateRequire() {
      let me = this,
        isValid = true;
      let elements = document.querySelectorAll("[Require='true']");
      elements.forEach((element) => {
        let value = element.value;
        if (!value) {
          isValid = false;
          element.classList.add("notValidControl");

          // Hiển thị dialog thông báo
          me.$emit("validateForm", ValidateForm.Message.notEmpty);
        } else {
          element.classList.remove("notValidControl");
        }
      });
      return isValid;
    },

    // Validate các trường Number
    validateFieldNumber() {
      let me = this,
        isValid = true;
      let elements = document.querySelectorAll("[DataType='Number']");
      elements.forEach((element) => {
        let value = element.value;
        if (isNaN(value)) {
          isValid = false;
          element.classList.add("notValidControl");
          element.setAttribute("title", ValidateForm.Message.errFormatNumber);

          // Hiển thị dialog thông báo
          me.$emit("validateForm", ValidateForm.Message.errFormatNumber);
        } else {
          element.classList.remove("notValidControl");
        }
      });
      return isValid;
    },

    // Validate các trường ngày tháng
    validateFieldDate() {
      let me = this,
        isValid = true;
      let elements = document.querySelectorAll("[DataType='Date']");
      elements.forEach((element) => {
        let value = element.value;
        if (!ValidateForm.isDateFormat(value)) {
          isValid = false;
          element.classList.add("notValidControl");
          element.setAttribute("title", ValidateForm.Message.errFormatDate);

          // Hiển thị dialog thông báo
          me.$emit("validateForm", ValidateForm.Message.errFormatDate);
        } else {
          element.classList.remove("notValidControl");
        }
      });
      return isValid;
    },

    // Validate các trường email
    validateEmail() {
      let me = this,
        isValid = true;
      let elements = document.querySelectorAll("[DataType='Email']");
      elements.forEach((element) => {
        let value = element.value;
        if (!ValidateForm.IsEmailFormat(value)) {
          isValid = false;
          element.classList.add("notValidControl");
          element.setAttribute("title", ValidateForm.Message.errFormatEmail);

          // Hiển thị dialog thông báo
          me.$emit("validateForm", ValidateForm.Message.errFormatEmail);
        } else {
          element.classList.remove("notValidControl");
        }
      });
      return isValid;
    },

    // Hàm dùng cho các màn override lại: validate Trùng mã nhân viên hoặc các kiểu validate khác
    validateCustom() {
      return true;
    },
  },

  mounted(){
    this.$refs.txtEmployeeCode.focus()
  }
};
</script>

<style>
</style>
