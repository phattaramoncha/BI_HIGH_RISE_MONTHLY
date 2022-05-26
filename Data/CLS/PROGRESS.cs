using BI_HIGH_RISE_MONTHLY.Data.Dao;

namespace BI_HIGH_RISE_MONTHLY
{
    class PROGRESS
    {
        public void exc_progress()
        {
            ReportDao rptDao = new ReportDao();

            var proj_id = rptDao.GetProjHighRise();
            foreach (var id_ in proj_id)
            {
                var result = rptDao.GetProgess(id_.proj_id);
                if (result.Count >0)
                {
                    rptDao.POST_HIGH_RISE_PROGRESS(result);
                }

            }


        }

    }
}