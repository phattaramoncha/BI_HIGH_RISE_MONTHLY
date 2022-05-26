using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI_HIGH_RISE_MONTHLY.Data.Model
{ 
    public class Progress
    {
        public string proj_code { get; set; }
        public string proj_name { get; set; }
        public string po_no { get; set; }
        public int? rev { get; set; }
        public int? months { get; set; }
        public DateTime? beginning_period { get; set; }
        public string work_period { get; set; }
        public string cat_code { get; set; }
        public string cat_name { get; set; }
        public string sub_cat_code { get; set; }
        public string sub_cat_name { get; set; }
        public string contractor_code { get; set; }
        public string contractor_name { get; set; }
        public int? work_days { get; set; }
        public DateTime? monthly { get; set; }
        public int? period { get; set; } 
        public decimal? master_of_category { get; set; }
        public decimal? adjust_of_category { get; set; }
        public decimal? master_of_month { get; set; }
        public decimal? adjust_of_month { get; set; }
        public decimal? progress_of_month { get; set; }
        public decimal? cashflow_of_month { get; set; }
    }
    public class ProjHighRise
    {
        public Guid proj_id { get; set; }
        public string proj_code { get; set; }
        public string proj_name { get; set; }
    }
}
