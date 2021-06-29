using DeepTry.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.DL.Repository
{
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(DBContext<Account> databaseContext) : base(databaseContext)
        {
        }
    }
}
