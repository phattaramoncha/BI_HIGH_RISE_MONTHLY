using ReportCM.Data.Dao;
using System;

namespace BI_HIGH_RISE_MONTHLY
{
     class PROGRESS
    {
        public void exc()
        {
            ReportDao rptDao = new ReportDao();
            var result = rptDao.GetProgess();

            int ii = result.Count;
            if (ii > 0)
            {
                //rptDao.TRUNCATE_PROGRESS();
                //rptDao.InsertProgress(result);
                rptDao.POST_HIGH_RISE_PROGRESS(result);
            }
        }
    }
}