using System;
using BI_HIGH_RISE_MONTHLY.Data.Dao;

namespace BI_HIGH_RISE_MONTHLY.Data.CLS
{
    public class PO_RETENTION_WARRANTY_EXPIRED
    {
        public void exec(DateTime dtPrev)
        {
            ReportDao rptDao = new ReportDao();

            var result = rptDao.GetPoRetenionWarrantyExpired(dtPrev);
            if (result.Count > 0)
            {
                rptDao.POST_HIGH_RISE_PO_RETENTION_WARRANTY_EXPIRED(result);
            }
        }
    }
}