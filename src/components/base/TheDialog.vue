<template>
    <div id="dialogConfirmDelete" MISADialog class="m-dialog-box" v-bind:class="{ visible: isShowDialog }">
        <div class="m-dialog">
            <div class="m-dialog-close"></div>
            <div class="m-dialog-header">{{title}}</div>
            <div class="m-dialog-body">
                {{message}}{{assetCode}}
            </div>
            <div class="m-dialog-footer">
                <button v-show="isShowBtnCancel" @click="handleCancel" class="m-btn m-btn-cancel">Hủy bỏ</button>
                <button @click="handleConfirm" class="m-btn m-btn-ok" :class="{'style-delete': isShowBtnCancel,hidden: !isShowDialog}">Đồng ý</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "TheDialog",
    props: ["isShowDialog","assetCode","message","title","isShowBtnCancel"],
    data(){
        return{
        }
    },

    watch: {

    },

    methods: {
        handleCancel(){
            this.$emit('handleCloseDialog')
        },
        handleConfirm(){
            this.$emit('handleConfirmDialog')
        }
    }
}
</script>

<style>
.style-delete {
    background-color:#dc3545 !important;
    opacity: 1;
}
.style-delete:hover {
    opacity: .7;
}
.hidden {
    opacity: 0;
}
</style>