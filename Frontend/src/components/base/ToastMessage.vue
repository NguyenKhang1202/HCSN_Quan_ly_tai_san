<template>
    <div id="toastBox" class="toast-box toast-success" v-show="isShowToast">
            <div class="toast-msg-item">
                <div class="toast-icon"><i class="fas fa-check-circle"></i></div>
                <div class="toast-text">{{ message }}</div>
                <div class="toast-close" @click="handleCloseToast"><i class="fas fa-times"></i></div>
            </div>
        </div>
</template>

<script>
export default {
    name: "TheToastMessage",
    props: ["isShowToast","message"],
    data(){
        return{
            
        }
    },
    methods: {
        handleCloseToast(){
            this.$emit('handleCloseToast');
        }
    }
}
</script>

<style scoped>
.toast-box {
    position: fixed;
    right: 16px;
    bottom: 16px;
}

.toast-box .toast-msg-item {
    display: flex;
    align-items: center;
    padding: 0 12px 0 16px;
    height: 48px;
    border-radius: 4px;
    box-shadow: 0 3px 6px;
    background-color: white;
}
.toast-box .toast-msg-item .toast-icon {
    width: 24px;
    height: 24px;
    font-size: 24px;
}

.toast-msg-item .toast-text {
    margin-left: 12px;
    margin-right: 24px;

}
.toast-msg-item .toast-close {
    width: 24px;
    height: 24px;
    font-size: 24px;
    opacity: 0.7;
}
.toast-close:hover {
    opacity: 1;
    cursor: pointer;
}

.toast-error .toast-icon, 
.toast-error .toast-close {
    color: #EB5757;
}

.toast-warning .toast-icon, 
.toast-warning .toast-close {
    color: #F1C04E;
}

.toast-success .toast-icon, 
.toast-success .toast-close {
    color: #01B075;
}

.toast-info .toast-icon, 
.toast-info .toast-close {
    color: #4388D9;
}
</style>