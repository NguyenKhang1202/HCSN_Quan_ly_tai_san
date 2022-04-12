<template>
  <div id="formAssetDetail" class="wrap-modal"
    v-bind:class="{ open: isShow }"
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
                    <input type="text" class="m-input width-small" name="AssetCode"/>
                </div>
                <div>
                    <label for="AssetName">Tên tài sản <span class="m-label-red">*</span></label>
                    <input type="text" class="m-input width-big" name="AssetName"/>
                </div>
            </div>
            <div class="row">
                <div>
                    <label for="">Mã bộ phận sử dụng <span class="m-label-red">*</span></label>
                    <combobox-component
                    :items="departments"
                    @bindDataForm="bindDataForm"
                    :Require="true"
                    @handleBlur="handleBlur"
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
                    @handleBlur="handleBlur"
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
            <button class="m-btn m-btn-cancel">Hủy</button>
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
          departments: Combobox.getDepartment("EmployeeDetail"),
      }
  },
  props: {
      isShow: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
      closeForm(){
          this.$emit('closeForm');
      }
  }
};
</script>

<style scoped>
@import url(./css/AssetDetail.css);
</style>
