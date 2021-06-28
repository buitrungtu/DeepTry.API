using DeepTry.Common.Model;
using DeepTry.DL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.BL.Service
{
    public class EmployeeService : BaseService<Employee>
    {
        EmployeeRepository _employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    }
}
