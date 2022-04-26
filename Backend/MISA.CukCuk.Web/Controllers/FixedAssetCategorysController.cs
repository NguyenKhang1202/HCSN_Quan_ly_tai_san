using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface;
using System;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FixedAssetCategorysController : ControllerBase
    {
        IFixedAssetCategoryRepo _fixedAssetCategoryRepo;
        public FixedAssetCategorysController(IFixedAssetCategoryRepo fixedAssetCategoryRepoDI)
        {
            _fixedAssetCategoryRepo = fixedAssetCategoryRepoDI;
        }

        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                // Lấy dữ liệu
                var fixedAssets = _fixedAssetCategoryRepo.Get();
                return Ok(fixedAssets);
            }
            catch (Exception ex)
            {
                var serviceResult = new MISAServiceResult
                {
                    UserMsg = "Có lõi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    DevMsg = ex.Message
                };

                return StatusCode(500, serviceResult);
            }
        }
        [HttpGet("{fixedAssetCategoryId}")]
        public IActionResult GET([FromRoute] Guid fixedAssetCategoryId)
        {
            try
            {
                // Lấy dữ liệu
                var fixedAssetCategory = _fixedAssetCategoryRepo.GetById(fixedAssetCategoryId);
                return Ok(fixedAssetCategory);
            }
            catch (Exception ex)
            {
                var serviceResult = new MISAServiceResult
                {
                    UserMsg = "Có lõi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    DevMsg = ex.Message
                };

                return StatusCode(500, serviceResult);
            }
        }
    }
}
