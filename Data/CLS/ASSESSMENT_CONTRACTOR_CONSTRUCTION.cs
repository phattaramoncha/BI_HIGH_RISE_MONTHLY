using BI_HIGH_RISE_MONTHLY.Data.Dao;
using System;

namespace BI_HIGH_RISE_MONTHLY.Data.CLS
{
    class ASSESSMENT_CONTRACTOR_CONSTRUCTION
    {
        public void exec(DateTime dt_prev)
        {
            ReportDao rptDao = new ReportDao();
            var result = rptDao.GetAssConCon(dt_prev);

            int ii = result.Count;
            if (ii > 0)
            {
                rptDao.POST_HIGH_RISE_ASSESSMENT_CONTRACTOR_CONSTRUCTION(result);
            }
        }
    }
}
