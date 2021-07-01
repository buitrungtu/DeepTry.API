using DeepTry.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.DL.Repository
{
    public class BranchRepository : BaseRepository<Branch>
    {
        public BranchRepository(DBContext<Branch> databaseContext) : base(databaseContext)
        {

        }
    }
}
