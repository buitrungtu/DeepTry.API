using DeepTry.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.DL.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(DBContext<Employee> databaseContext) : base(databaseContext)
        {

        }
    }
}
