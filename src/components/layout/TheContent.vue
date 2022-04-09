<template>
  <!-- <the-employee></the-employee> -->
  <router-view />
</template>

<style>
@import url(../../css/common/content.css);
</style>>


<script>
/* eslint-disable */
import TheEmployee from '../../views/Employee/Employee.vue'

export default {
    name: "TheContent",
    components: {
      TheEmployee
    },

    data(){
      return {
      }
    },    
    methods: {
      
    }
}
</script>>