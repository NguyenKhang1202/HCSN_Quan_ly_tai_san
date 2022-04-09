<template>
  <div class="nav-bar">
    <!-- logo -->
    <div class="logo-box">
      <div class="toggle toggle-icon">
      </div>
      <div class="logo-page">MISA QLTS</div>
    </div>

    <!-- menu -->
    <div class="navbar-box" :class="{ toggle: isToggle }">
      <router-link to="/" class="menu-item">
        <div class="wrap-icon">
          <div class="menu-item-icon menu-icon-dashboard"></div>
        </div>
        <div class="menu-item-text">Tổng quan</div>
      </router-link>
      <router-link to="/report" class="menu-item">
      <div class="wrap-icon">

        <div class="menu-item-icon menu-icon-report"></div>
      </div>
        <div class="menu-item-text">Báo cáo</div>
      </router-link>

      <router-link to="/customer" class="menu-item">
      <div class="wrap-icon">

        <div class="menu-item-icon menu-icon-dashboard"></div>
      </div>
        <div class="menu-item-text">Danh sách khách hàng</div>
      </router-link>
      <router-link to="/employee" class="menu-item">
        <div class="wrap-icon">

        <div class="menu-item-icon menu-icon-employee"></div>
      </div>
        <div class="menu-item-text">Danh mục nhân viên</div>
      </router-link>
      <router-link to="/setting" class="menu-item">
        <div class="wrap-icon">
          <div class="menu-item-icon menu-icon-setting"></div>
        </div>
        <div class="menu-item-text">Thiết lập hệ thống</div>
      </router-link>
      <!-- <div class="m-collapse-toggle"
        @click="toggleNavbar"
        :class="{ toggled: isToggle}"    
        >
        <i class="fas fa-angle-left"></i>
      </div> -->
    </div>
  </div>
</template>

<script>
// props : khai báo các thuộc tính sẽ nhận
export default {
  name: "TheNavbar",
  data() {
      return {
          isToggle: false,
      }
  },
  props: [],
  methods: {
      toggleNavbar(){
          let me = this;
            me.isToggle = !me.isToggle;
      },
  }
};
</script>

<style></style>
>
