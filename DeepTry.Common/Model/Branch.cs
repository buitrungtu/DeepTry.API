using System;
using System.Collections.Generic;
using System.Text;

namespace DeepTry.Common.Model
{
    public class Branch
    {
        public Guid branch_id { get; set; }

        public string branch_code { get; set; }

        public string branch_name { get; set; }

        public int? is_parent { get; set; }

        public Guid? company_id { get; set; }

        public DateTime? create_date { get; set; }

        public string create_by { get; set; }

        public DateTime? modify_date { get; set; }

        public string modify_by { get; set; }
    }
}
