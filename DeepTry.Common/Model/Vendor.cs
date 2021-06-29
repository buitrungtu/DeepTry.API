using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.Common.Model
{
    public class Vendor
    {
        public Guid vendor_id { get; set; }

        public string vendor_code { get; set; }

        public string vendor_name { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public string mail { get; set; }

        public string tax_code { get; set; }

        public string website { get; set; }

        public int? vendor_type { get; set; }

        public Guid? employee_code { get; set; }

        public int? contact_vocative { get; set; }

        public string contact_name { get; set; }

        public string contact_email { get; set; }

        public string contact_phone { get; set; }

        public string contact_legal { get; set; }

        public int? debt_amount { get; set; }

        public int? debt_max_amount { get; set; }

        public int? debt_max_date { get; set; }

        public string description { get; set; }

        public string branch_id { get; set; }

        public DateTime? create_date { get; set; }

        public string create_by { get; set; }

        public DateTime? modify_date { get; set; }

        public string modify_by { get; set; }
    }
}
