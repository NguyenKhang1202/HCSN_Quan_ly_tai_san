/* eslint-disable */
import axios from "axios"
import Enumeration from "./Enumeration.js";
import Resource from "./Resource.js";

// Các hàm dùng chung toàn chương trình
var CommonFn = CommonFn || {};


// Hàm format số tiền
CommonFn.formatMoney = money => {
    if(money && !isNaN(money)){
        return money.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.");
    }else{
        return money;
    }
}

// Format ngày tháng
CommonFn.formatDate = dateSrc => {
    let date = new Date(dateSrc),
        year = date.getFullYear().toString(),
        month = (date.getMonth() + 1).toString().padStart(2, '0'),
        day = date.getDate().toString().padStart(2, '0');

    return `${day}/${month}/${year}`;
}

// Format ngày tháng
CommonFn.convertDate = dateSrc => {
    let date = new Date(dateSrc),
        year = date.getFullYear().toString(),
        month = (date.getMonth() + 1).toString().padStart(2, '0'),
        day = date.getDate().toString().padStart(2, '0');

    return `${year}-${month}-${day}`;
}

// Lấy giá trị của một enum
CommonFn.getValueEnum = (data, enumName) => {
    let enumeration = Enumeration[enumName],
        resource = Resource[enumName];

    for(let prop in enumeration){
        if(enumeration[prop] == data){
            data = resource[prop];
        }
    }
    
    return data;
}

// Kiểm tra xem có phải dạng date không
CommonFn.isDateFormat = (date) => {
    let regex = new RegExp("([0-9]{4}[-](0[1-9]|1[0-2])[-]([0-2]{1}[0-9]{1}|3[0-1]{1})|([0-2]{1}[0-9]{1}|3[0-1]{1})[-](0[1-9]|1[0-2])[-][0-9]{4})");
    
    return regex.test(date);
}

// Kiểm tra xem có phải dạng Email không 
CommonFn.IsEmailFormat = (email) => {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

// Hàm axios gọi lên server lấy dữ liệu
CommonFn.Axios = (method,url,data, fnCallBack, errCallback) => {
    try {
        axios({
            method: method,
            url: url,
            data: data,
            async: true,
        })
        .then(function(response) {
            fnCallBack(response);
        })
        .catch(function(err) {
            errCallback(err);
            console.error(err);
        });
    } catch (error) {
        console.log("Xảy ra lỗi tại Axios");
        console.log(error);
    }
}

export default CommonFn;
