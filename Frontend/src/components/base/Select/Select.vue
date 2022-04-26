<template>
  <div class="m-select">
    <div class="m-select-title" @click="displayOptions">
        {{currentSelected.name}}<span class="m-select-name">{{`${currentSelected.value}`}}</span>
    </div>
    <ul class="m-select-data" v-show="isShow">
      <li v-for="item in data" :key="item.value" 
        class="m-select-item" 
        :class="{'m-select-selected' :currentSelected.value == item.value}" 
        :value="item.value" 
        @click="selectOption($event, item)"
        >
      {{`${item.name}  ${item.value}`}}</li>
    </ul>
  </div>
</template>

<script>
/* eslint-disable */
import { computed } from 'vue';
import CommonFn from "../../../js/Common/Common.js";

export default {
  name: "m-custom-select",
  props: ["api", "valueOption", "nameOption"],
  data() {
    return {
      isShow: false,
      currentFocus: -1,
      currentSelected: {
          value: 2022,
          name: 'Năm'
      },
      value: "",
      name: "",
      data: [
        {
          value: 2023,
          name: 'Năm'
        },
        {
          value: 2024,
          name: 'Năm'
        },
        {
          value: 2025,
          name: 'Năm'
        },
      ]
    };
  },
  methods: {
    // hiển thị hoặc ẩn list data
    displayOptions() {
      let me = this;
      try {
        me.isShow = !me.isShow;
      } catch (error) {
        console.log(error);
      }
    },

    // chọn 1 item trong list data
    selectOption(e, item) {
      let me = this;
      try {
        me.currentSelected.value = item.value;
        me.currentSelected.name = item.name;
        me.displayOptions();
      } catch (error) {
        console.log(error);
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
              me.data = response.data;
            })
            .catch(function(error) {
              console.log(error);
            });
        }
        else{
          me.value = ''
          me.name = ''
          me.data = [{
            value: 0,
            name: 'Không có dữ liệu'
          }]
        }
      } catch (error) {
        console.log(error);
      }
  },
  }
};
</script>

<style scoped>
@import url(./m-select.css);
</style>