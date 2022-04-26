using Dapper;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class FixedAssetRepo : IFixedAssetRepo
    {
        public IEnumerable<FixedAsset> Get()
        {
            //Khai báo thông tin chuỗi kết nối
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Khai báo câu lệnh truy vấn
            var sqlCommand = $"SELECT * FROM FixedAsset ORDER BY created_date DESC";
            //Lấy dữ liệu từ db
            var data = sqlConnection.Query<FixedAsset>(sqlCommand);
            //Trả về kết quả
            return data;
        }

        public int Delete(Guid fixedAssetId)
        {
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Khai báo câu lệnh truy vấn
            var sqlCommand = $"DELETE FROM FixedAsset WHERE fixed_asset_id = @m_fixed_asset_id ";
            //Xử lý param cho lệnh sql tránh các lỗi sql injection
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add("@m_fixed_asset_id", fixedAssetId);
            //Thêm mới dữ liệu từ db
            var res = sqlConnection.Execute(sql: sqlCommand, param: dynamicParam, commandType: System.Data.CommandType.Text);
            //Trả về kết quả
            return res;
        }

        public FixedAsset Get(Guid fixedAssetId)
        {
            throw new NotImplementedException();
        }

        public int Insert(FixedAsset fixedAsset)
        {
            //Khai báo thông tin chuỗi kết nối
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Khai báo câu lệnh truy vấn
            var sqlCommand = $"Proc_InsertFixedAsset";
            //Xử lý param cho lệnh sql tránh các lỗi sql injection
            var dynamicParam = new DynamicParameters();
            var newFixedAssetId = Guid.NewGuid();
            DateTime currentTime = DateTime.Now;
            dynamicParam.Add("@m_fixed_asset_id", newFixedAssetId);
            dynamicParam.Add("@m_fixed_asset_code", fixedAsset.fixed_asset_code);
            dynamicParam.Add("@m_fixed_asset_name", fixedAsset.fixed_asset_name);
            dynamicParam.Add("@m_quantity", fixedAsset.quantity);
            dynamicParam.Add("@m_cost", fixedAsset.cost);
            dynamicParam.Add("@m_life_time", fixedAsset.life_time);
            dynamicParam.Add("@m_depreciation_rate", fixedAsset.depreciation_rate);
            dynamicParam.Add("@m_depreciation_value", fixedAsset.depreciation_value);
            dynamicParam.Add("@m_tracked_year", fixedAsset.tracked_year);
            dynamicParam.Add("@m_purchase_date", fixedAsset.purchase_date);
            dynamicParam.Add("@m_production_date", fixedAsset.production_date);
            dynamicParam.Add("@m_fixed_asset_category_code", fixedAsset.fixed_asset_category_code);
            dynamicParam.Add("@m_department_code", fixedAsset.department_code);
            dynamicParam.Add("@m_fixed_asset_category_name", fixedAsset.fixed_asset_category_name);
            dynamicParam.Add("@m_department_name", fixedAsset.department_name);
            dynamicParam.Add("@m_created_date", currentTime);
            //Thêm mới dữ liệu từ db
            var res = sqlConnection.Execute(sql: sqlCommand, param: dynamicParam, commandType: System.Data.CommandType.StoredProcedure);
            //Trả về kết quả
            return res;
        }

        public int Update(FixedAsset fixedAsset, Guid fixedAssetId)
        {
            //Khai báo thông tin chuỗi kết nối
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Khai báo câu lệnh truy vấn
            var sqlCommand = $"Proc_UpdateFixedAsset";
            //Xử lý param cho lệnh sql tránh các lỗi sql injection
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add("@fixedAssetId", fixedAssetId);
            dynamicParam.Add("@m_fixed_asset_id", fixedAsset.fixed_asset_id);
            dynamicParam.Add("@m_fixed_asset_code", fixedAsset.fixed_asset_code);
            dynamicParam.Add("@m_fixed_asset_name", fixedAsset.fixed_asset_name);
            dynamicParam.Add("@m_quantity", fixedAsset.quantity);
            dynamicParam.Add("@m_cost", fixedAsset.cost);
            dynamicParam.Add("@m_life_time", fixedAsset.life_time);
            dynamicParam.Add("@m_depreciation_rate", fixedAsset.depreciation_rate);
            dynamicParam.Add("@m_depreciation_value", fixedAsset.depreciation_value);
            dynamicParam.Add("@m_tracked_year", fixedAsset.tracked_year);
            dynamicParam.Add("@m_purchase_date", fixedAsset.purchase_date);
            dynamicParam.Add("@m_production_date", fixedAsset.production_date);
            dynamicParam.Add("@m_fixed_asset_category_code", fixedAsset.fixed_asset_category_code);
            dynamicParam.Add("@m_department_code", fixedAsset.department_code);
            dynamicParam.Add("@m_fixed_asset_category_name", fixedAsset.fixed_asset_category_name);
            dynamicParam.Add("@m_department_name", fixedAsset.department_name);
            //Thêm mới dữ liệu từ db
            var res = sqlConnection.Execute(sql: sqlCommand, param: dynamicParam, commandType: System.Data.CommandType.StoredProcedure);
            //Trả về kết quả
            return res;
        }

        public IEnumerable<string> GetNewCode()
        {
            //Khai báo thông tin chuỗi kết nối
            var connectionString = "Host=3.0.89.182;Port=3306;Database=MISA.QLTS.NVKHANG;User Id=dev;Password=12345678";
            //Khởi tạo kết nối
            var sqlConnection = new MySqlConnection(connectionString);
            //Khai báo câu lệnh truy vấn
            var sqlCommand = $"SELECT MAX(fixed_asset_code) FROM FixedAsset";
            //Lấy dữ liệu từ db
            var data = sqlConnection.Query<string>(sqlCommand);
            //Trả về kết quả
            return data;
        }
    }
}
