using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.Common.Model
{
    public  class Company
    {
        public Guid company_id { get; set; }

        public string company_code { get; set; }

        public string company_name { get; set; }

        public DateTime? create_date { get; set; }

        public string create_by { get; set; }

        public DateTime? modify_date { get; set; }

        public string modify_by { get; set; }

    }
}
