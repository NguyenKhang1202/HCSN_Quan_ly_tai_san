<template>
    <div class="header" :class="{ shrink: isShrink}">
        <div class="header-left">
            <div class="header-title">Danh sách tài sản</div>
        </div>
        <div class="header-right">
            <p>Sở tài chính</p>
            <Select />
            <button class="m-btn-header m-btn-notify"></button>
            <button class="m-btn-header m-btn-menu"></button>
            <button class="m-btn-header m-btn-help"></button>
            <div class="header-account">
                <button class="m-btn-header m-btn-user"></button>
            </div>
        </div>
    </div>
</template>

<script>
import Select from '../base/Select/Select.vue'

export default {
    name: "TheHeader",
    components: {
        Select,
    },
    props: ["isShrink"],
}
</script>

<style scoped>
   
</style>