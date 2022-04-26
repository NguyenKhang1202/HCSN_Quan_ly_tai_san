using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interface
{
    public interface IDepartmentRepo
    {
        //Lấy ra tất cả các bản ghi trong bảng
        public IEnumerable<object> Get();
        //Lấy ra một bản ghi theo ID
        public IEnumerable<object> GetById(Guid departmentId);
        //Thêm mới một bản ghi
        public int Insert(object department);
        //Sửa dữ liệu một bản ghi theo ID
        public Department Update(Department department);
        //Xoá một bản ghi theo ID
        public int Delete(Department department);
    }
}
