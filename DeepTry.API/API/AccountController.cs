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

        [HttpPost("insert_account")]
        public IActionResult InsertAccount([FromBody] Account acc)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            int affectRows = (int)_accountService.ExecProc("Proc_InsertAccount", new
            {
                account_name = acc.account_name,
                password = acc.password,
                is_admin = acc.is_admin,
                company_id = acc.company_id,
                branch_id = acc.branch_id
            }, 0);
            if (affectRows > 0)
                return CreatedAtAction("POST", affectRows);
            else
                return BadRequest(serviceResponse);
        }
    }
}
