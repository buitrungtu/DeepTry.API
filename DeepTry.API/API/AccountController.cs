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
    public class AccountController : BaseController<Account>
    {

        private AccountService _accountService;
        public AccountController(AccountService accountService) : base(accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("create_account_company")]
        public ServiceResponse CreateAccountCompany([FromBody] object obj)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var result = _accountService.ExecProc("Proc_CreateAccountCompany", obj, "Write");
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
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("create_account_branch")]
        public ServiceResponse CreateAccountBranch([FromBody] object obj)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var result = _accountService.ExecProc("Proc_CreateAccountBranch", obj, "Write");
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
        /// Đăng nhập
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ServiceResponse Login([FromBody] Account acc)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var result = _accountService.ExecProc("Proc_SignIn", acc, "read");
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
    }
}
