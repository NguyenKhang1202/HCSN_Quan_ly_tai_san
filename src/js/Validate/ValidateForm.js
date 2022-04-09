/* eslint-disable */
// Các hàm dùng chung toàn chương trình
var ValidateForm = ValidateForm || {};

ValidateForm.isDateFormat = (date) => {
        let regex = new RegExp("([0-9]{4}[-](0[1-9]|1[0-2])[-]([0-2]{1}[0-9]{1}|3[0-1]{1})|([0-2]{1}[0-9]{1}|3[0-1]{1})[-](0[1-9]|1[0-2])[-][0-9]{4})");
    return regex.test(date);
    },

ValidateForm.IsEmailFormat = (email) => {
        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (!regex.test(email)) {
            return false;
        } else {
            return true;
        }
    },

    // Validate form

    // Validate các trường bắt buộc
ValidateForm.validateRequire = () => {
    let isValid = true;

    // Duyệt hết các trường require xem có trường nào bắt buộc mà ko có value ko
    let elements = document.querySelectorAll("[Require='true']");
        elements.forEach(element => {
            let value = element.value;

            if(!value){
                isValid = false;
                element.classList.add("notValidControl");
                // CommonFn.showDialogMsg("Vui lòng không được để trống!");
                // element.attr("title", "Vui lòng không được để trống!");
            }else{
                element.classList.remove("notValidControl");
            }
        })
    return isValid;
},

    // Validate các trường Number
    ValidateForm.validateFieldNumber = () => {
        let isValid = true;

        let elements = document.querySelectorAll("[DataType=Number]");
            elements.forEach(element => {
                let value = element.value;

                if(isNaN(value)){
                    isValid = false;
                    element.classList.add("notValidControl");
                    // CommonFn.showDialogMsg("Vui lòng không được để trống!");
                    element.setAttribute("title", "Vui lòng nhập đúng định dạng!");
                }else{
                    element.classList.remove("notValidControl");
                }
            })
        return isValid;
    },

    // Validate các trường ngày tháng
    ValidateForm.validateFieldDate = () => {
        let isValid = true;

        let elements = document.querySelectorAll("[DataType=Date]");
            elements.forEach(element => {
                let value = element.value;
                if(!ValidateForm.isDateFormat(value)){
                    isValid = false;
                    element.classList.add("notValidControl");
                    // CommonFn.showDialogMsg("Vui lòng không được để trống!");
                    element.setAttribute("title", "Vui lòng nhập đúng định dạng!");
                }else{
                    element.classList.remove("notValidControl");
                }
            })
            return isValid;
    },

    // Validate các trường email
    ValidateForm.validateEmail = () => {
        let isValid = true;
        // Duyệt hết các trường require xem có trường nào bắt buộc mà ko có value ko
        let elements = document.querySelectorAll("[DataType=Email]");

        elements.forEach(element => {
            let value = element.value;
            console.log(value);
            // is not email
            if(ValidateForm.IsEmailFormat(value) == false) {
                isValid = false;
                element.classList.add("notValidControl");
                // CommonFn.showDialogMsg("Vui lòng nhập đúng định dạng Email !");
                element.setAttribute("title", "Vui lòng nhập đúng định dạng Email!");
            }else{
                element.classList.remove("notValidControl");
            }
        });
        return isValid;
    },

    // Hàm dùng cho các màn override lại: validate Trùng mã nhân viên hoặc các kiểu validate khác
    ValidateForm.validateCustom = () => {
        return true;
    }

    ValidateForm.Message = {
        errFormatEmail: "Vui lòng nhập đúng định dạng email !",
        errFormatDate: "Vui lòng nhập đúng định dạng ngày tháng!",
        errFormatNumber: "Vui lòng nhập đúng định dạng số!",
        notEmpty: "Vui lòng không được để trống!",
    }

export default ValidateForm;
