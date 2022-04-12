<template>
  <!-- <the-employee></the-employee> -->
  <router-view 
    :class="{ shrinkContent: isShrink}"
    />
</template>

<style>
@import url(../../css/common/content.css);
</style>>


<script>
/* eslint-disable */
import TheAsset from '../../views/Assets/Asset.vue'

export default {
    name: "TheContent",
    components: {
      TheAsset
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

