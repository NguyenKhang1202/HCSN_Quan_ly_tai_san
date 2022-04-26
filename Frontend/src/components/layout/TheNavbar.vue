<template>
  <div class="nav-bar" :class="{ toggled: isShrink }">
    <!-- logo -->
    <div class="logo-box">
      <div class="toggle toggle-icon">
      </div>
      <div class="logo-page"
        :class="{'shrink-navbar': isShrink}"
        >MISA QLTS</div>
    </div>

    <!-- menu -->
    <div class="navbar-box" >
      <router-link to="/" class="menu-item">
        <div class="wrap-icon">
          <div class="menu-item-icon menu-icon-dashboard"></div>
        </div>
        <div class="menu-item-text" :class="{'shrink-navbar': isShrink}">Tổng quan</div>
      </router-link>
      <router-link to="/report" class="menu-item">
      <div class="wrap-icon">
        <div class="menu-item-icon menu-icon-report"></div>
      </div>
        <div class="menu-item-text" :class="{'shrink-navbar': isShrink}">Báo cáo</div>
      </router-link>
      <router-link to="/customer" class="menu-item">
      <div class="wrap-icon">
        <div class="menu-item-icon menu-icon-dashboard"></div>
      </div>
        <div class="menu-item-text" :class="{'shrink-navbar': isShrink}">Tài sản</div>
      </router-link>
      <router-link to="/assets" class="menu-item">
        <div class="wrap-icon">
        <div class="menu-item-icon menu-icon-employee"></div>
      </div>
        <div class="menu-item-text" :class="{'shrink-navbar': isShrink}">Tài sản HT-ĐB</div>
      </router-link>
      <router-link to="/setting" class="menu-item">
        <div class="wrap-icon">
          <div class="menu-item-icon menu-icon-setting"></div>
        </div>
        <div class="menu-item-text" :class="{'shrink-navbar': isShrink}">Thiết lập hệ thống</div>
      </router-link>
      <div class="m-collapse-toggle"
        @click="toggleNavbar"
        :class="{ toggled: isShrink}"    
        >
        <i class="fas fa-angle-left"></i>
      </div>
    </div>
  </div>
</template>

<script>
// props : khai báo các thuộc tính sẽ nhận
export default {
  name: "TheNavbar",
  props: ["isShrink"],
  methods: {
      toggleNavbar(){
          let me = this;
          me.$emit('toggleShrinkNavbar');
      },
  }
};
</script>

<style>
.shrink-navbar {
  display: none;
}
</style>

