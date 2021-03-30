using BI_HIGH_RISE_MONTHLY.Data.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BI_HIGH_RISE_MONTHLY
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt_prev = DateTime.Now.AddMonths(-1);
            //DateTime dt_now = DateTime.Now;

            //DateTime dt = DateTime.Now.AddDays(-1);

            //Set First Day of Month
            dt_prev = new DateTime(dt_prev.Year, dt_prev.Month, 1);
            //dt_now = new DateTime(dt_now.Year, dt_now.Month, 1);

            #region progress

            var PROGRESS = new PROGRESS();
            PROGRESS.exc();

            #endregion

            #region  Assessment_Contractor_Construction ประเมินผู้รับเหมา งานก่อนสร้าง

            var ASSESSMENT_CONTRACTOR_CONSTRUCTION = new ASSESSMENT_CONTRACTOR_CONSTRUCTION();
            ASSESSMENT_CONTRACTOR_CONSTRUCTION.exc(dt_prev);

            #endregion
        }

    }
}
