using DeepTry.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.DL.Repository
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(DBContext<Company> databaseContext) : base(databaseContext)
        {

        }
    }
}
