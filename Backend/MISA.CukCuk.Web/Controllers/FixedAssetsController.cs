using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface;
using System;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FixedAssetsController : ControllerBase
    {
        IFixedAssetRepo _fixedAssetRepository;

        public FixedAssetsController(IFixedAssetRepo fixedAssetRepositoryDI)
        {
            _fixedAssetRepository = fixedAssetRepositoryDI;
        }

        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                int x;

                x = 2; 
                Console.WriteLine(x);

                Console.WriteLine("debugger");
                // Trả về dữ liệu đã lấy được
                var fixedAssets = _fixedAssetRepository.Get();
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
        [HttpPost]
        public IActionResult POST([FromBody] FixedAsset fixedAsset)
        {
            try
            {
                var res = _fixedAssetRepository.Insert(fixedAsset);
                return StatusCode(201, res);
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
        [HttpDelete("{fixedAsset}")]
        public IActionResult DELETE(Guid fixedAsset)
        {
            try
            {
                var res = _fixedAssetRepository.Delete(fixedAsset);
                return StatusCode(201, res);
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
        /*[HttpDelete("multidelete")]
        public IActionResult DELETE([FromBody] string[] fixedAssets)
        {
            try
            {
                var res = _fixedAssetRepository.DeleteMulti(fixedAssets);
                return StatusCode(201, res);
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
        }*/
        [HttpPut("{fixedAssetId}")]
        public IActionResult PUT([FromBody] FixedAsset fixedAsset,[FromRoute] Guid fixedAssetId)
        {
            try
            {
                var res = _fixedAssetRepository.Update(fixedAsset, fixedAssetId);
                return StatusCode(201, res);
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
        [HttpGet("NewfixedAssetCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                var res = _fixedAssetRepository.GetNewCode();
                return StatusCode(201, res);
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
