using DeepTry.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.DL.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(DBContext<Customer> databaseContext) : base(databaseContext)
        {

        }
    }
}
