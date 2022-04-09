<template>
  <div>
    <the-navbar />
    <the-header />
    <the-content />
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
};
</script>

<style>
@import url('./css/common/grid.css');
@import url('./css/common/main.css');
@import url('./css/common/header.css');
@import url('./css/common/navbar.css');
@import url('./css/common/content.css');
@import url('./css/page/employee.css');
</style>
