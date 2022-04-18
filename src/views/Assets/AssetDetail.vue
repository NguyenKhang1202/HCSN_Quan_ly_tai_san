<template>
  <div id="formAssetDetail" class="wrap-modal"
    v-bind:class="{ open: isShowForm }"
    >
    <div class="modal-content">
        <div class="content-top">
            <p class="form-title">Thêm tài sản</p>
            <div class="close-form" @click="closeForm"></div>
        </div>
        <div class="content-middle">
            <div class="row">
                <div>
                    <label for="AssetCode">Mã tài sản <span class="m-label-red">*</span></label>
                    <input id="txtAssetCode" type="text" class="m-input width-small" name="AssetCode"
                        tabindex="1"
                        v-model="assetForm.fixed_asset_code"
                        @focus="focusItem"
                        ref="txtAssetCode"
                        FieldName="AssetCode"
                        autofocus
                        Require="true"
                        />
                </div>
                <div>
                    <label for="AssetName">Tên tài sản <span class="m-label-red">*</span></label>
                    <input type="text" class="m-input width-big" name="AssetName"
                        v-model="assetForm.fixed_asset_name"
                        Require="true"
                        />
                </div>
            </div>
            <div class="row">
                <div>
                    <label for="">Mã bộ phận sử dụng <span class="m-label-red">*</span></label>
                    <combobox-component
                        :items="departments"
                        @bindDataForm="bindDataForm"
                        v-bind:assetForm="assetForm.DepartmentId"
                        :Require="true"
                        tabindex="5"
                    />
                </div>
                <div>
                    <label for="DepartmentName">Tên bộ phận sử dụng </label>
                    <input type="text" class="m-input width-big" name="DepartmentName" disabled/>
                </div>
            </div>
            <div class="row">
                <div>
                    <label for="">Mã loại tài sản <span class="m-label-red">*</span></label>
                    <combobox-component
                        :items="departments"
                        @bindDataForm="bindDataForm"
                        :Require="true"
                        tabindex="5"
                    />
                </div>
                <div>
                    <label for="AssetTypeName">Tên loại tài sản</label>
                    <input type="text" class="m-input width-big" name="AssetTypeName" disabled/>
                </div>
            </div>
            <div class="row">
                <div>
                    <label for="">Số lượng <span class="m-label-red">*</span></label>
                    <input type="number" name="" id="">
                </div>
                <div>
                    <label for="">Nguyên giá <span class="m-label-red">*</span></label>
                    <input type="text" class="m-input width-small" name=""/>
                </div>
                <div>
                    <label for="">Số năm sử dụng <span class="m-label-red">*</span></label>
                    <input type="text" class="m-input width-small" name=""/>
                </div>
            </div>
            <div class="row">
                <div>
                    <label for="">Tỷ lệ hao mòn (%) <span class="m-label-red">*</span></label>
                    <input type="number" name="" id="">
                </div>
                <div>
                    <label for="">Giá trị hao mòn năm <span class="m-label-red">*</span></label>
                    <input type="text" class="m-input width-small" name=""/>
                </div>
                <div>
                    <label for="">Năm theo dõi</label>
                    <input type="text" class="m-input width-small" name="" disabled/>
                </div>
            </div>
            <div class="row justify-content-left">
                <div>
                    <label for="">Ngày mua <span class="m-label-red">*</span></label>
                    <input type="date" class="m-input width-small" name=""/>
                </div>
                <div>
                    <label for="">Ngày bắt đầu sử dụng <span class="m-label-red">*</span></label>
                    <input type="date" class="m-input width-small" name=""/>
                </div>
            </div>
        </div>
        <div class="content-bottom">
            <button class="m-btn m-btn-cancel" @click="closeForm">Hủy</button>
            <button class="m-btn m-btn-save">Lưu</button>
        </div>
    </div>
  </div>
</template>

<script>
/* eslint-disable */
import ComboboxComponent from "../../components/base/Combobox.vue";
import CommonFn from "../../js/Common/Common.js";
import Resource from "../../js/Common/Resource";
import Constant from "../../js/Common/Constant";
import Combobox from "../../js/Components/Combobox";
import ValidateForm from "../../js/Validate/ValidateForm";
import Enumeration from "../../js/Common/Enumeration";

export default {
  name: "AssetDetail",

  components: {
    ComboboxComponent,
  },

  data(){
      return {
          // Là dữ liệu trên Form
          assetForm: { type: Object, default: {} },

          departments: Combobox.getDepartment("EmployeeDetail"),
      }
  },
  props: {
      /*  
        Add : 1 
        Edit : 2 
      */
      formMode: Number,

      isShowForm: {
        type: Boolean,
        default: false,
      },
      fixedAsset: {
          type: Object,
      }

  },
  
  methods: {
    closeForm(){
        this.$emit('closeForm');
    },

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
          me.assetForm.DepartmentId = item.id;
          break;
        case "Gender":
          me.assetForm.Gender = item.id;
          break;
        case "Position":
          me.assetForm.PositionId = item.id;
          break;
      }
    },
  },
  watch: {
    fixedAsset: function(assetEdit) {
        let me = this;
        me.assetForm = assetEdit;
    }, 

    isShowForm: function () {
        let me = this;
        if (me.isShowForm == true && me.formMode == Enumeration.FormMode.Add) {
            let url = Constant.urlNewAssetCode,
                method = Resource.Method.Get,
                data = {};
            // reset form
            me.assetForm = {};
            console.log("them tai san")
            try {
                CommonFn.Axios(method, url, data, function (response) {
                    // gán AssetCode lên form (khi thêm mới)
                    console.log(response)
                    me.assetForm.fixed_asset_code = (response.data)[0];
                    // me.$refs.txtEmployeeCode.focus();
                }, function (error) {
                    me.$emit("validateForm", error.response.data.devMsg);
                });
            } catch (error) {
                console.log(error);
            }
        }
        console.log(me.assetForm.fixed_asset_code);
        me.$refs.txtAssetCode.focus();
        },
  }
};
</script>

<style scoped>
@import url(./css/AssetDetail.css);
</style>
