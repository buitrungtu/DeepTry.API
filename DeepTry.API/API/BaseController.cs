using DeepTry.BL.Service;
using DeepTry.Common.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeepTry.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        BaseService<T> _baseService;

        public BaseController(BaseService<T> baseService)
        {
            _baseService = baseService;
        }


        // GET: api/<BaseAPI>
        [HttpGet("get_by_page")]
        public IActionResult GetByPaging(int page, int record, Guid branchId)
        {
            var pagingObject = new PagingObject();
            pagingObject.TotalRecord = _baseService.GetFullData(branchId).Count();
            pagingObject.TotalPage = Convert.ToInt32(Math.Ceiling((decimal)pagingObject.TotalRecord / (decimal)record));
            pagingObject.Data = _baseService.GetDataByPage(record * (page - 1), record, branchId);
            if (pagingObject.Data != null)
                return Ok(pagingObject);
            else
                return NoContent();
        }

        [HttpGet("get_by_id")]
        public IActionResult GetById([FromRoute] Guid objID)
        {
            //TODO: Sửa db phần lấy thông tin
            var obj = _baseService.GetById(objID);
            if (obj != null)
                return Ok(obj);
            else
                return NoContent();
        }

        [HttpGet("get_full_data")]
        public ServiceResponse GetFullData(Guid branchId)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var data = _baseService.GetFullData(branchId);
            if (data != null) {
                serviceResponse.Success = true;
                serviceResponse.Data = data;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }
            return serviceResponse;
        }

        [HttpPost("insert")]  
        public IActionResult Post([FromBody] T obj)
        {
            var serviceResponse = _baseService.Insert(obj);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("POST", affectRows);
            else
                return BadRequest(serviceResponse);
        }

        [HttpPut("update")]
        public IActionResult Put([FromBody] T obj)
        {
            var serviceResponse = _baseService.Update(obj);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("PUT", affectRows);
            else
                return BadRequest(serviceResponse);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Guid id)
        {
            var serviceResponse = _baseService.Delete(id);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("DELETE", affectRows);
            else
            {
                serviceResponse.Message.Add("Không tìm thấy bản ghi này");
                return BadRequest(serviceResponse);
            }
        }


        /// <summary>
        /// Gọi API thực thi 1 proc trong db
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("execute_proc")]
        public ServiceResponse ExcuteProc([FromBody] DBAction obj)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var result = _baseService.ExecProc(obj.StringQuery, obj.Parameter, obj.Action);
            if (result != null)
            {
                serviceResponse.Success = true;
                serviceResponse.Data = result;
                return serviceResponse;
            }
            else
            {
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        /// <summary>
        /// Thực thi 1 câu lệnh nào đó
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("excute_query")]
        public ServiceResponse GetDataByQuery([FromBody] DBAction obj)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            obj.StringQuery = obj.StringQuery.ToLower();
            if(obj.StringQuery.Contains("update") || obj.StringQuery.Contains("delete") || obj.StringQuery.Contains("database"))
            {
                serviceResponse.Success = false;
                serviceResponse.Message.Add("Trong câu query chứa từ khóa cấm. Chức năng này chỉ được sử dụng để kiểm tra dữ liệu");
                serviceResponse.Data = null;
                return serviceResponse; 
            }
            var data = _baseService.ExecuteQuery(obj.StringQuery, "read");
            if (data != null)
            {
                serviceResponse.Success = true;
                serviceResponse.Data = data;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Data = null;
            }
            return serviceResponse;
        }
    }
}
