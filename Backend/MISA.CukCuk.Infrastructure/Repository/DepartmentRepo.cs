using Dapper;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class DepartmentRepo : IDepartmentRepo
    {
        public IEnumerable<object> Get()
        {
            //Khai báo thông tin chuỗi kết nối
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Lấy dữ liệu từ db
            var data = sqlConnection.Query<object>("SELECT * FROM Department");
            //Trả về kết quả
            return data;
        }

        public int Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetById(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public int Insert(object department)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
