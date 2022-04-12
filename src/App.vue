<template>
  <div>
    <the-navbar 
      @toggleShrinkNavbar="toggleShrinkNavbar"
      :isShrink="isShrinkNavbar"
      />
    <the-header 
      :isShrink="isShrinkNavbar"
      />
    <the-content 
      :isShrink="isShrinkNavbar"
      />
  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue'
import TheContent from './components/layout/TheContent.vue'
import TheNavbar from './components/layout/TheNavbar.vue'
export default {
  name: "App",
  components: {
      TheHeader,
      TheContent,
      TheNavbar,
  },
  data(){
    return {
      isShrinkNavbar: false,
    }
  },
  watch() {
  },
  methods: {
    toggleShrinkNavbar(){
      let me = this;
      me.isShrinkNavbar = !me.isShrinkNavbar;
    }
  }
};
</script>

<style>
@import url('./css/common/grid.css');
@import url('./css/common/main.css');
@import url('./css/common/header.css');
@import url('./css/common/navbar.css');
@import url('./css/common/content.css');
@import url('./css/page/employee.css');
.shrink {
  width: calc(100% - 67px);
}
</style>
