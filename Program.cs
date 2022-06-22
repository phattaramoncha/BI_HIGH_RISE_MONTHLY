using System;
using BI_HIGH_RISE_MONTHLY.Data.CLS;

namespace BI_HIGH_RISE_MONTHLY
{
    class Program
    {
        static void Main(string[] args)
        { 
            DateTime dt_prev = DateTime.Now.AddMonths(-1); 

            //Set First Day of Month
            dt_prev = new DateTime(dt_prev.Year, dt_prev.Month, 1); 

            #region progress

            var progress = new PROGRESS();
            progress.exec();

            #endregion

            #region  Assessment_Contractor_Construction ประเมินผู้รับเหมา งานก่อนสร้าง

            var assessmentContractorConstruction = new ASSESSMENT_CONTRACTOR_CONSTRUCTION();
            assessmentContractorConstruction.exec(dt_prev);

            #endregion

            #region PO_RETENTION_WARRANTY_EXPIRED หมดรับประกันผลงาน

            var poRetentionWarrantyExpired = new PO_RETENTION_WARRANTY_EXPIRED();
            poRetentionWarrantyExpired.exec(dt_prev);

            #endregion
        }
 
    }
}
