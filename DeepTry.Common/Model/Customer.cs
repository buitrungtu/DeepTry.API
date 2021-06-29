using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.Common.Model
{
    public class Customer
    {
        public Guid customer_id { get; set; }

        public string customer_code { get; set; }

        public string customer_name { get; set; }

        public DateTime? birthday { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public string mail { get; set; }

        public int? sex { get; set; }

        public int? customer_type { get; set; }

        public int? debt_amount { get; set; }

        public int? quanlity_buy { get; set; }

        public string description { get; set; }

        public Guid? branch_id { get; set; }

        public DateTime? create_date { get; set; }

        public string create_by { get; set; }

        public DateTime? modify_date { get; set; }

        public string modify_by { get; set; }


    }
}
