using System;

namespace BI_HIGH_RISE_MONTHLY.Data.Model
{
    public class Contract_Construction_Date
    {
        public string proj_code { get; set; }
        public string proj_name { get; set; }
        public string po_no { get; set; }
        public string contractor_code { get; set; }
        public string contractor_name { get; set; }
        public DateTime? construction_start_date { get; set; }
        public DateTime? construction_end_date { get; set; }
        public int? work_days { get; set; }
        public DateTime rpt_kpi_proj_start_date { get; set; }
        public DateTime rpt_kpi_proj_end_date { get; set; }
    }
}