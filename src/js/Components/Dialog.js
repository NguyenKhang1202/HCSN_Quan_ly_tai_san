/* eslint-disable */

// Các hàm dùng chung toàn chương trình
var DialogJS = DialogJS || {};

DialogJS.Delete = (assetCode) => {
    return {
        title: "XÓA TÀI SẢN",
        message: `Bạn có chắc chắn muốn xóa tài sản ${assetCode}?`,
        isShowBtnCancel: true,
        isShowDialog: true,
    }
}

DialogJS.Warning = (message) => {
    return {
        title: 'THÔNG BÁO',
        message: message,
        isShowBtnCancel: false,
        isShowDialog: true,
    }
}

export default DialogJS;
