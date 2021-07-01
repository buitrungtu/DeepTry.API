using DeepTry.Common.Model;
using DeepTry.DL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.BL.Service
{
    public class CompanyService : BaseService<Company>
    {
        CompanyRepository _companyRepository;
        public CompanyService(CompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }
    }
}
