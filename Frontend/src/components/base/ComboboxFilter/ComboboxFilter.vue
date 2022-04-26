<template>
  <div class="m-combobox-icon">
    <div class="m-combobox-icon-title"
      @keydown.up="handleMoveUp"
      @keydown.down="handleMoveDown"
      @click="displayOptions">
      <input
      type="text"
      class="m-combobox-icon-input"
      :placeholder="titleInput"
      :value="currentSelected[`${this.name}`]"
      @click="handleCheck"
      @keyup.enter="handlePressEnter"
      ref="txtComboboxIcon"
      />
    </div>
    <div class="m-combobox-icon-data" v-show="isShow">
      <div
        v-for="(item,index) in data"
        :key="item[`${this.value}`]"
        :value="item[`${this.name}`]"
        class="m-combobox-icon-item"
        :class="[
        {'m-combobox-icon-selected': currentSelected[`${this.value}`] == item[`${this.value}`]},
        {'m-combobox-icon-focus': index == currentFocus}
        ]"
        @click="(e) => selectOption(e, item, index)"
        ref="option"
      >{{item[`${this.name}`]}}</div>
    </div>
  </div>
</template>

<script>
const axios = require("axios");
export default {
  name: "Combobox-filter",
  props: ["title", "api", "valueOption", "nameOption"],
  data() {
    return {
      isShow: false,
      titleInput: this.title,
      currentFocus: -1,
      currentSelected: {},
      value: this.valueOption,
      name: this.nameOption,
      data: []
    };
  },
  methods: {
    displayOptions() {
      let me = this;
      try {
        me.isShow = !me.isShow;
      } catch (error) {
        console.log(error);
      }
    },
    selectOption(e, el, index) {
      let me = this;
      try {
        me.currentSelected = el;
        me.currentFocus = index;
        console.log(me.currentSelected);
        console.log(me.currentSelected[`${me.value}`]);
        // console.log(me.$refs.txtCombobox.value);
        // console.log(el[`${me.value}`]);
        me.displayOptions();
      } catch (error) {
        console.log(error);
      }
    },
    handleMoveDown: function() {
      let me = this
        console.log("down");
      if (me.currentFocus >= me.data.length - 1) {
        me.currentFocus = 0;
      } else me.currentFocus += 1;
    },
    handleMoveUp: function() {
      let me = this
      if (me.currentFocus <= 0) {
        me.currentFocus = me.data.length - 1;
      } else me.currentFocus -= 1;
    },
    handleCheck() {
      let me = this
      if(!me.$refs.txtComboboxIcon.value){
        me.currentSelected = {}
        me.currentFocus = -1
      }
    },
    handlePressEnter() {
      let me = this;
      try {
        if (me.currentFocus != -1 && me.$refs.txtComboboxIcon.value) {
          me.displayOptions()
          me.$refs.option[me.currentFocus].click();
        }if(!me.$refs.txtComboboxIcon.value){
          me.$refs.option[me.currentFocus].click();
          me.isShow= false
        }if(me.$refs.txtComboboxIcon.value){
        let keyword = me.$refs.txtComboboxIcon.value
        me.currentSelected = me.data.find((option) => {
            return option[`${this.name}`].toLowerCase().includes(keyword.toLowerCase());
        });
          me.currentFocus = me.data.indexOf(me.currentSelected)
          me.$refs.option[me.currentFocus].click();
          me.displayOptions()
        }
      } catch (error) {
        console.log(error);
      }
    }
  },
  created() {
    let me = this;
    try {
      if(me.api){      
        //gọi API lấy dữ liệu
        axios
          .get(me.api)
          .then(function(response) {
            //gán vào biến đã được khỏi tạo từ đầu
            me.data = response.data;
          })
          .catch(function(error) {
            // xử lý khi bị lỗi
            console.log(error);
          })
          .then(function() {
            // luôn luôn được thực thi
          });
      }
      else{
        me.titleInput = ""
        me.value = 'value'
        me.name = 'name'
        me.data = [{
          value: 0,
          name: 'Không có dữ liệu'
        }]
      }
    } catch (error) {
      console.log(error);
    }
  },
  updated() {
    if(!this.api){
      this.$refs.txtComboboxIcon.disable
    }
  },
  mounted() {
    const me = this;
    document.addEventListener("click", function(event) {
      if (!me.$el.contains(event.target)) {
        me.isShow = false;
      }
    });
  }
};
</script>

<style scoped>
@import url(./m-combobox-icon.css);
</style>