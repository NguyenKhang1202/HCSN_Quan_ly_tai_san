using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interface
{
    public interface IFixedAssetService
    {
        //Các nghiệp vụ khi thực hiện thêm dữ liệu vào DB
        public int InsertService(FixedAsset fixedAsset);

        //Các nghiệp vụ khi thực hiện sửa dữ liệu trong DB
        public int UpdateService(FixedAsset fixedAsset);
        //Các nghiệp vụ khi thực hiện xoá dữ liệu trong DB
        public FixedAsset DeleteService(FixedAsset fixedAsset);
    }
}
