using System;

namespace BI_HIGH_RISE_MONTHLY.Data.Model
{
    public class Po_Retenion_Warranty_Expired
    { 
        public string proj_code { get; set; }
        public string proj_name { get; set; }
        public string cat_code { get; set; }
        public string sub_cat_code { get; set; }
        public string po_type { get; set; }
        public string po_status { get; set; }
        public string po_no { get; set; }
        public string contractor_code { get; set; }
        public string contractor_name { get; set; }
        public DateTime? contract_start_date { get; set; }
        public DateTime? contract_end_date { get; set; }
        public int? contract_end_day_count { get; set; }
        public decimal? amount { get; set; }
        public DateTime? posting_date { get; set; }
    }
}