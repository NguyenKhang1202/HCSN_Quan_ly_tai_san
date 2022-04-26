using Dapper;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class FixedAssetCategoryRepo : IFixedAssetCategoryRepo
    {
        public int Delete(FixedAssetCategory fixedAssetCategory)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> Get()
        {
            //Khai báo thông tin chuỗi kết nối
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Lấy dữ liệu từ db
            var data = sqlConnection.Query<object>("SELECT * FROM FixedAssetCategory");
            //Trả về kết quả
            return data;
        }

        public IEnumerable<object> GetById(Guid fixedAssetCategoryId)
        {
            //Khai báo thông tin chuỗi kết nối
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Khai báo câu lệnh truy vấn
            var sqlCommand = $"SELECT * FROM FixedAssetCategory fac WHERE fac.fixed_asset_category_id = @m_fixed_asset_category_id";
            //Xử lý param cho lệnh sql tránh các lỗi sql injection
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add("@m_fixed_asset_category_id", fixedAssetCategoryId);
            //Thêm mới dữ liệu từ db
            var res = sqlConnection.Query(sql: sqlCommand, param: dynamicParam, commandType: System.Data.CommandType.Text);
            //Trả về kết quả
            return res;
        }

        public int Insert(FixedAssetCategory fixedAssetCategory)
        {
            throw new NotImplementedException();
        }

        public FixedAssetCategory Update(FixedAssetCategory fixedAssetCategory)
        {
            throw new NotImplementedException();
        }
    }
}
