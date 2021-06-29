using DeepTry.Common.Model;
using DeepTry.DL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.BL.Service
{
    public class AccountService : BaseService<Account>
    {
        AccountRepository _accountRepository;
        public AccountService(AccountRepository accountRepository) : base(accountRepository)
        {
            _accountRepository = accountRepository;
        }
    }
}
