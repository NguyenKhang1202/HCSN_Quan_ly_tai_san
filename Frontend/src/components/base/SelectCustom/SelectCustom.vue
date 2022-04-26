<template>
  <div class="m-select-custom">
    <div class="m-select-custom-title" @click="displayOptions">
      <span
        style="font-weight: 700; padding-left: 10px; font-family: MISA GoogleSans"
      >{{`${currentSelected.value}`}}</span>
    </div>
    <ul class="m-select-custom-data" v-show="isOpenSelect">
      <option
        v-for="el in data"
        :key="el.value"
        class="m-select-custom-item"
        :class="[{'m-select-custom-selected': currentSelected.value == el.value}]"
        :value="el.value"
        @click="selectOption(el)"
      >{{`${el.value}`}}</option>
    </ul>
  </div>
</template>

<script>
export default {
  name: "m-select-custom",
  props: ["optionValue"],
  data() {
    return {
      isOpenSelect: false,
      currentSelected: {
        value: "20",
        name: "Trang"
      },
      data: [
        {
          value: "100",
          name: "Trang"
        },
        {
          value: "80",
          name: "Trang"
        },
        {
          value: "60",
          name: "Trang"
        },
        {
          value: "40",
          name: "Trang"
        },
        {
          value: "20",
          name: "Trang"
        }
      ]
    };
  },
  methods: {
    displayOptions() {
      let me = this;
      try {
        me.isOpenSelect = !me.isOpenSelect;
      } catch (error) {
        console.log(error);
      }
    },
    selectOption(el) {
      let me = this;
      try {
        me.currentSelected = el;
        me.$emit('bind-ValueSelect', me.currentSelected.value);
        me.displayOptions();
      } catch (error) {
        console.log(error);
      }
    },
    mounted() {
      let me = this;
      document.addEventListener("click", function(event) {
        if (!me.$el.contains(event.target)) {
          me.isOpen = false;
        }
      });
    }
  }
};
</script>

<style scoped>
@import url(./m-select-custom.css);
</style>