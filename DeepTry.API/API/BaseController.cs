﻿using DeepTry.BL.Service;
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

        [HttpGet("get_by_test")]
        public string Test()
        {
            return "test";
        }

        // GET: api/<BaseAPI>
        [HttpGet("get_by_page")]
        public IActionResult GetByPaging(int page, int record)
        {
            var pagingObject = new PagingObject();
            pagingObject.TotalRecord = _baseService.GetFullData().Count();
            pagingObject.TotalPage = Convert.ToInt32(Math.Ceiling((decimal)pagingObject.TotalRecord / (decimal)record));
            pagingObject.Data = _baseService.GetDataByPage(record * (page - 1), record);
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
        public IActionResult GetFullData()
        {
            var data = _baseService.GetFullData();
            if (data != null) return Ok(data);
            else return NoContent();
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
        public IActionResult Delete([FromRoute] Guid objID)
        {
            var serviceResponse = _baseService.Delete(objID);
            var affectRows = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (affectRows > 0)
                return CreatedAtAction("DELETE", affectRows);
            else
            {
                serviceResponse.Message.Add("Không tìm thấy bản ghi này");
                return BadRequest(serviceResponse);
            }
        }
    }
}