using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI_HIGH_RISE_MONTHLY.Data.Model
{
    public class Assessment_Contractor_Construction
    {
        public string proj_code { get; set; }
        public string proj_name { get; set; }
        public DateTime? progress_month { get; set; }
        public int? months { get; set; }
        public int? years { get; set; }
        public string po_no { get; set; }
        public string contractor_code { get; set; }
        public string contractor_full_name_snap { get; set; }
        public string catagory_code { get; set; }
        public string catagory_name { get; set; }
        public string types { get; set; }
        public decimal? score_idx_0 { get; set; }
        public string grade_idx_0 { get; set; }
        public decimal? score_idx_1 { get; set; }
        public string grade_idx_1 { get; set; }
        public decimal? score_idx_2 { get; set; }
        public string grade_idx_2 { get; set; }
        public decimal? score_idx_3 { get; set; }
        public string grade_idx_3 { get; set; }
        public decimal? score_idx_4 { get; set; }
        public string grade_idx_4 { get; set; }
        public decimal? score_idx_5 { get; set; }
        public string grade_idx_5 { get; set; }
        public decimal? score_idx_6 { get; set; }
        public string grade_idx_6 { get; set; }
        public decimal? score_assessment { get; set; }
        public string grade_assessment { get; set; }
        public decimal? avg_proj { get; set; }
    }
}
