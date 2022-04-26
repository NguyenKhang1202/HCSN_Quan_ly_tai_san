<template>
    <div id="loading">
        <img src="../../assets/img/loading.gif" alt="Loading..."/>
    </div>
</template>

<script>
export default {
    name: 'TheLoading'
}
</script>

<style scoped>
#loading {
    position: absolute;
    display: flex;
    align-items: center;
    justify-content: center;
    top: 44px;
    z-index: 1000000;
    width: 100%;
    height: calc(100% - 44px);
    background-color: #fff;
    opacity: 0.4;
  }
  
  #loading img {
    width: 80px;
    height: 80px;
    position: absolute;
    z-index: 999999;
  }
/* @import url(../../css/components/loading.css); */
</style>