using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI_High.Data.Model
{
    public class fix_transfer
    {
        public DateTime? created_at { get; set; }
        public int? months { get; set; }
        public int? years { get; set; }
        public DateTime? crm_contract_transfer_date { get; set; }
        public DateTime? closed_date { get; set; }
        public string cust_available_dates { get; set; }
        public string nj_id { get; set; }
        public string io_code { get; set; }
        public string fitem_id { get; set; }
        public string fitem_status { get; set; }
        public string fitem_name { get; set; }
        public string proj_code { get; set; }
        public string proj_name { get; set; }
        public string proj_grade_code { get; set; }
        public string proj_grade_name { get; set; }
        public string proj_grade_name_en { get; set; }
        public string emp_code { get; set; }
        public string manager_name { get; set; }
    }
}
