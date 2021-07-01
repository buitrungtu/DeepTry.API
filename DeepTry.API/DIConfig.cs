using DeepTry.BL.Service;
using DeepTry.DL;
using DeepTry.DL.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepTry.API
{
    public class DIConfig
    {
        public static void InjectionConfig(IServiceCollection services)
        {
            //config cho service
            services.AddScoped<EmployeeService>();
            services.AddScoped<AccountService>();
            services.AddScoped<VendorService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<BranchService>();
            services.AddScoped<CompanyService>();
            services.AddScoped(typeof(BaseService<>));
            //config cho Repository
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<AccountRepository>();
            services.AddScoped<VendorRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<BranchRepository>();
            services.AddScoped<CompanyRepository>();
            services.AddScoped(typeof(BaseRepository<>));
            //config cho Database
            services.AddScoped(typeof(DBContext<>));
        }
    }
}
