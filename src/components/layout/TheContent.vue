<template>
  <router-view 
    :class="{ shrinkContent: isShrink}"
    />
</template>

<style>
@import url(../../css/common/content.css);
</style>>


<script>
/* eslint-disable */

export default {
    name: "TheContent",
    components: {
    },

    data(){
      return {
      }
    },    
    methods: {
    },
    props: ["isShrink"]
}
</script>

<style>
.shrinkContent {
  left: 67px;
  width: calc(100% - 67px);
}
</style>

