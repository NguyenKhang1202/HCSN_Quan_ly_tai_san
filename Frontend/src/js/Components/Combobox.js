/* eslint-disable */
import CommonFn from "../Common/Common";
import Resource from "../Common/Resource";

// Các hàm dùng chung toàn chương trình
var Combobox = Combobox || {};

// Combobox.getData = function(url){
//     var method = Resource.Method.Get,
//         data = [];

//     CommonFn.Axios(method, url, {}, function(response){
//         if(response){
//             var data = response.data;
//         }else {
//             console.log("Error get Department");
//         }
//     });
//     console.log('data');
//     console.log(data);

//     return data;
// }

Combobox.getDepartment = function(Parent){
    // items = Combobox.getData("http://amis.manhnv.net/api/v1/Departments"),
    // items.forEach(function(item, index) {
    //     data[index] = {
    //         id: item.DepartmentId,
    //         name: item.DepartmentName,
    //     }
    // });
    let data = [
            { id: "11452b0c-768e-5ff7-0d63-eeb1d8ed8cef", name: "Phòng Công nghệ thông tin"  },
            { id: "142cb08f-7c31-21fa-8e90-67245e8b283e", name: "Phòng Sản xuất" },
            { id: "17120d02-6ab5-3e43-18cb-66948daf6128", name: "Phòng Đào tạo" },
            { id: "469b3ece-744a-45d5-957d-e8c757976496", name: "Phòng Nhân sự" },
            { id: "4e272fc4-7875-78d6-7d32-6a1673ffca7c", name: "Phòng Tuyển dụng"  },
            ],
        placeholder = "Tất cả phòng ban",
        FieldName = "Department",
        NameId = "DepartmentId";

    return {
        data,
        placeholder,
        FieldName,
        NameId,
        Parent,
    }
}

Combobox.getGender = function(Parent){
    // let items = Combobox.getData("http://amis.manhnv.net/api/v1/Genders"),
        // items.forEach(function(item, index) {
        //     data[index] = {
        //         id: item.DepartmentId,
        //         name: item.DepartmentName,
        //     }
        // });
    let data = [
        { id: "0",name: "Nữ" },
        { id: "1", name: "Nam" },
        { id: "2", name: "Khác"  },
    ],
        placeholder = "Giới tính",
        FieldName = "Gender",
        NameId = "Gender";

    return {
        data,
        placeholder,
        FieldName,
        NameId,
        Parent,
    }
}

Combobox.getPosition = function(Parent){
    // let items = Combobox.getData("http://amis.manhnv.net/api/v1/Positions"),
        // items.forEach(function(item, index) {
        //     data[index] = {
        //         id: item.DepartmentId,
        //         name: item.DepartmentName,
        //     }
        // });
    let data = [
        { id: "0",name: "Nhân viên" },
        { id: "1", name: "Giám đốc" },
        { id: "2", name: "Khác"  },
    ],
        placeholder = "Tất cả vị trí",
        FieldName = "Position",
        NameId = "PositionId";
        
    return {
        data,
        placeholder,
        FieldName,
        NameId,
        Parent,
    }
}

Combobox.getWorkStatus = function(Parent){
    // let items = Combobox.getData("http://amis.manhnv.net/api/v1/Positions"),
        // items.forEach(function(item, index) {
        //     data[index] = {
        //         id: item.DepartmentId,
        //         name: item.DepartmentName,
        //     }
        // });
    let data = [
        // { id: "0",name: "Đang làm việc" },
        // { id: "1", name: "Đã nghỉ hưu" },
        // { id: "2", name: "Khác"  },
    ],
        placeholder = "Tất cả trạng thái",
        FieldName = "WorkStatus",
        NameId = "WorkStatusId";
        
    return {
        data,
        placeholder,
        FieldName,
        NameId,
        Parent,
    }
}
export default Combobox;
