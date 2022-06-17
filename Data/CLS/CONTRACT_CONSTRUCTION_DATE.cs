using System;
using BI_HIGH_RISE_MONTHLY.Data.Dao;

namespace BI_HIGH_RISE_MONTHLY.Data.CLS
{
    public class CONTRACT_CONSTRUCTION_DATE
    {
        public void EXCE_CONTRACT_CONSTRUCTION_DATE(Guid in_projid)
        {
            ReportDao rptDao = new ReportDao();
            var result = rptDao.GetContractConstructionDate(in_projid);

            if (result.Count > 0)
            {
                rptDao.POST_HIGH_RISE_CONTRACT_CONSTRUCTION_DATE(result);
            }
        }
    }
}