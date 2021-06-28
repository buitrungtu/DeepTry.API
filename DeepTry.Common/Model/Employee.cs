using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.Common.Model
{
    public class Employee
    {
        public Guid employee_id { get; set; }

        public string employee_code { get; set; }

        public string employee_name { get; set; }

        public DateTime birthday { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public string mail { get; set; }

        public double salary { get; set; }

        public int sex { get; set; }

        public int position { get; set; }

        public int department { get; set; }

        public string tax_code { get; set; }

        public DateTime date_join { get; set; }

        public int status { get; set; }

        public string avatar_link { get; set; }

        public string description { get; set; }

        public Guid branch_id { get; set; }

        public DateTime create_date { get; set; }

        public string create_by { get; set; }

        public DateTime modify_date { get; set; }

        public string modify_by { get; set; }

    }
}
