using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interface;
using System;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentRepo _departmentRepo;

        public DepartmentsController(IDepartmentRepo _departmentRepoDI)
        {
            _departmentRepo = _departmentRepoDI;
        }

        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                // Lấy dữ liệu
                var departments = _departmentRepo.Get();
                return Ok(departments);
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
        [HttpGet("{departmentId}")]
        public IActionResult GetById([FromRoute] Guid departmentId)
        {
            try
            {
                // Lấy dữ liệu
                var department = _departmentRepo.GetById(departmentId);
                return Ok(department);
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
