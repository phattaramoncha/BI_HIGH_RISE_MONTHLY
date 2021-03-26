using ReportCM.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI_HIGH_RISE_MONTHLY.Data.CLS
{
    class ASSESSMENT_CONTRACTOR_CONSTRUCTION
    {
        public void exc(DateTime dt_prev)
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
