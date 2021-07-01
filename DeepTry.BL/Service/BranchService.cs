using DeepTry.Common.Model;
using DeepTry.DL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.BL.Service
{
    public class BranchService : BaseService<Branch>
    {
        BranchRepository _branchRepository;
        public BranchService(BranchRepository branchRepository) : base(branchRepository)
        {
            _branchRepository = branchRepository;
        }
    }
}
