/* eslint-disable */

// Các hàm dùng chung toàn chương trình
var DialogJS = DialogJS || {};

DialogJS.Delete = (employeeCode) => {
    return {
        title: "XÓA NHÂN VIÊN",
        message: `Bạn có chắc chắn muốn xóa nhân viên ${employeeCode}?`,
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
