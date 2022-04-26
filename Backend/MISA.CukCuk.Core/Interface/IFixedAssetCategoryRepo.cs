using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interface
{
    public interface IFixedAssetCategoryRepo
    {
        //Lấy ra tất cả các bản ghi trong bảng
        public IEnumerable<object> Get();
        //Lấy ra một bản ghi theo ID
        public IEnumerable<object> GetById(Guid fixedAssetCategoryId);
        //Thêm mới một bản ghi
        public int Insert(FixedAssetCategory fixedAssetCategory);
        //Sửa dữ liệu một bản ghi
        public FixedAssetCategory Update(FixedAssetCategory fixedAssetCategory);
        //Xoá một bản ghi theo ID
        public int Delete(FixedAssetCategory fixedAssetCategory);
    }
}
