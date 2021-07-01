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
    public class VendorController : BaseController<Vendor>
    {
        private VendorService _vendorService;

        public VendorController(VendorService vendorService) : base(vendorService)
        {
            _vendorService = vendorService;
        }



        

    }
}
