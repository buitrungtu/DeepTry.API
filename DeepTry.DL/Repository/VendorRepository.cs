using DeepTry.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.DL.Repository
{
    public class VendorRepository : BaseRepository<Vendor>
    {
        public VendorRepository(DBContext<Vendor> databaseContext) : base(databaseContext)
        {

        }
    }
}
