using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interface
{
    public interface IFixedAssetRepo
    {
        //Lấy ra tất cả các bản ghi trong bảng
        public IEnumerable<FixedAsset> Get();
        //Lấy ra một bản ghi theo ID
        public FixedAsset Get(Guid fixedAssetId);
        //Thêm mới một bản ghi
        public int Insert(FixedAsset fixedAsset);
        //Sửa dữ liệu một bản ghi theo ID
        public int Update(FixedAsset fixedAsset, Guid fixedAssetId);
        //Xoá một bản ghi theo ID
        public int Delete(Guid fixedAssetId);
        //Xoá nhiều bản ghi
        public IEnumerable<string> GetNewCode();
    }
}
