using DeepTry.Common.Model;
using DeepTry.DL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.BL.Service
{
    public class VendorService : BaseService<Vendor>
    {
        VendorRepository _vendorRepository;
        public VendorService(VendorRepository vendorRepository) : base(vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
    }
}
