using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Services
{
    public class FixedAssetService : IFixedAssetService
    {
        private IFixedAssetRepo _fixedAssetRepository;
        public FixedAssetService(IFixedAssetRepo assetRepo)
        {
            _fixedAssetRepository = assetRepo;
        }
        public int InsertService(FixedAsset fixedAsset)
        {
            var res = _fixedAssetRepository.Insert(fixedAsset);

            return res;
        }

        public FixedAsset DeleteService(FixedAsset fixedAsset)
        {
            return fixedAsset;
        }


        public int UpdateService(FixedAsset fixedAsset)
        {
            return 0;
        }
    }
}
