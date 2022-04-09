<template>
  <div
    class="m-combobox"
    mcombobox
    :FieldName="items.FieldName"
    :Parent="items.Parent"
  >
    <input type="text" class="m-input" 
      :placeholder="items.placeholder" 
      v-model="value" 
      :Require="Require"
      :tabindex="tabindex"
      @blur="handleBlur"
      />
    <button class="m-combobox-button"
        @click="onClickArrow"
        ></button>
    <div class="m-combobox-data" v-show="isShowItem"> 
        <div class="m-combobox-item"
        v-bind:class="{'m-combobox-selected': this.itemSelected.id == item.id}" 
        @click="onClickItem($event, item)"
        v-for="item in items.data" :key="item.id"
        :value="item.id"
        >{{item.name}}</div>
    </div>
  </div>
</template>

<script>
/* eslint-disable */
export default {
  name: "ComboboxComponent",
  // items : dữ liệu để xây dựng lên combobox, VD : departments, genders,...
  // employeeForm : là dữ liệu nhận được từ form (giá trị id)
  props: ["items", "employeeForm","Require","tabindex"],
  data() {
    return {
      itemSelected: {},
      isShowItem: false,
      value: "",
    };
  },
  methods: {
      // Sự kiện click button  
      onClickArrow(){
        let me = this;
        me.isShowItem = !me.isShowItem;
      },

      // Sự kiện click item, gửi dữ liệu lên form 
      // => để gửi phải có itemSelected
      onClickItem(event, itemSelected){
        let me = this;
        // gán itemSelected
        me.itemSelected = itemSelected;
        // ẩn list item
        me.isShowItem = !me.isShowItem;
        
        let data = {
          fieldName: me.items.FieldName,
          item: me.itemSelected,
        }
        me.$emit('bindDataForm',data);
      },

      // item là 1 object có dạng : { id: "...", name: "..."}
      createItem(id){
        let me = this,
            nameItem = "";
        
        // duyệt tất cả các item có trên server
        me.items.data.forEach((item) => {
          if(item.id == id){
            nameItem = item.name;
          }
        });
        return {
          id: id,
          name: nameItem,
        }
      },

      // Lấy name dựa trên id
      getNameById(id){
        let me = this;
        me.items.data.forEach((item) => {
          if(item.id == id){
            return item.name;
          }
        });
        return "";
      },

      handleBlur(e){
        this.$emit("handleBlur",e);
      }
  },
  watch: { 
    // Mỗi khi selected item khác thì đặt lại value và title cho input
    itemSelected: function(){
      let me = this;
      // Tìm combobox được click
      let comboboxs = document.querySelectorAll(`[Parent=${me.items.Parent}]`);

      comboboxs.forEach((item) => {
        if(item.getAttribute("FieldName") == me.items.FieldName){
          // đặt giá trị cho input
          me.value = me.itemSelected.name;
          // đặt giá trị title cho input
          item.children[0].setAttribute('title', me.itemSelected.name);
        }
      })
    },

    // Cập nhật giá trị trên combobox mỗi khi edit mới
    employeeForm: function(){
      let me = this;
      let comboboxs = document.querySelectorAll(`[Parent=EmployeeDetail]`);
      comboboxs.forEach((combobox) => {
          if(combobox.getAttribute("FieldName") == me.items.FieldName){
            let idItem = me.employeeForm,  // lấy giá trị Id tương ứng trong Form
                nameItem = me.getNameById(idItem); // lấy tên để gán lên input
            // gán itemSelected và data lên input
            me.itemSelected = me.createItem(idItem, nameItem);
            me.value = nameItem;
          }
      })
    }
  },

};
</script>

<style>
</style>
