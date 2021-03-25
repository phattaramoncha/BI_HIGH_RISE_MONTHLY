using BI_High.Data.Model;
using CJRPortal.App_Helpers;
using Npgsql;
using ReportCM.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ReportCM.Data.Dao
{
    public class ReportDao : BaseDao
    {

        public List<Progress> GetProgess()
        {
            try
            {
                using (var conn = new NpgsqlConnection(DB_CONNECTION))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("spl_get_bi_high_rise_progress_v11", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("in_closed_date", NpgsqlTypes.NpgsqlDbType.Date, dt_prev); //XXXX,XXXX,XXXX

                        using (var reader = cmd.ExecuteReader())
                        {
                            return SQLDataMapper.MapToCollection<Progress>(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void POST_HIGH_RISE_PROGRESS(List<Progress> progress)
        {
            bool flg = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(CRMDB_CONNECTION))
                {
                    using (SqlCommand cmd = new SqlCommand("POST_HIGH_RISE_PROGRESS", conn))
                    {
                        conn.Open();

                        foreach (var item in progress)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@proj_code", ((object)item.proj_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@proj_name", ((object)item.proj_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@po_no", ((object)item.po_no) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@revs", ((object)item.revs) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@beginning_period", ((object)item.beginning_period) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@months", ((object)item.months) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@cat_code", ((object)item.cat_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@sub_cat_code", ((object)item.sub_cat_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@sub_cat_name", ((object)item.sub_cat_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_code", ((object)item.contractor_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_name", ((object)item.contractor_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@current_peroid", ((object)item.current_peroid) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@work_days", ((object)item.work_days) ?? DBNull.Value);

                            cmd.Parameters.AddWithValue("@master_of_category", ((object)item.master_of_category) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@adjust_of_category", ((object)item.adjust_of_category) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@monthly", ((object)item.monthly) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@master_of_month", ((object)item.master_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@adjust_of_month", ((object)item.adjust_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@progress_of_month", ((object)item.progress_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@cashflow_of_month", ((object)item.cashflow_of_month) ?? DBNull.Value);


                            int result = cmd.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                            else flg = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertProgress(List<Progress> progress)
        {
            bool flg = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(CRMDB_CONNECTION))
                {
                    String query = "INSERT INTO tb_Research_High_Rise_Progress(proj_code, proj_name, po_no, revs, beginning_period, months, " +
                        "cat_code, sub_cat_code, sub_cat_name, contractor_code, contractor_name, current_peroid, work_days, " +
                        "master_of_category, adjust_of_category, monthly, master_of_month, adjust_of_month, progress_of_month, cashflow_of_month) " +
                        "VALUES (@proj_code, @proj_name, @po_no, @revs, @beginning_period, @months, " +
                        "@cat_code, @sub_cat_code, @sub_cat_name, @contractor_code, @contractor_name, @current_peroid, @work_days, " +
                        "@master_of_category, @adjust_of_category, @monthly, @master_of_month, @adjust_of_month, @progress_of_month, @cashflow_of_month)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        foreach (var item in progress)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@proj_code", ((object)item.proj_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@proj_name", ((object)item.proj_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@po_no", ((object)item.po_no) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@revs", ((object)item.revs) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@beginning_period", ((object)item.beginning_period) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@months", ((object)item.months) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@cat_code", ((object)item.cat_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@sub_cat_code", ((object)item.sub_cat_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@sub_cat_name", ((object)item.sub_cat_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_code", ((object)item.contractor_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_name", ((object)item.contractor_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@current_peroid", ((object)item.current_peroid) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@work_days", ((object)item.work_days) ?? DBNull.Value);

                            cmd.Parameters.AddWithValue("@master_of_category", ((object)item.master_of_category) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@adjust_of_category", ((object)item.adjust_of_category) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@monthly", ((object)item.monthly) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@master_of_month", ((object)item.master_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@adjust_of_month", ((object)item.adjust_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@progress_of_month", ((object)item.progress_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@cashflow_of_month", ((object)item.cashflow_of_month) ?? DBNull.Value);

                            int result = cmd.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                            else flg = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void TRUNCATE_PROGRESS()
        {
            bool flg = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(CRMDB_CONNECTION))
                {
                    String query = "TRUNCATE TABLE  [dbo].[tb_Research_High_Rise_Progress]";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        int result = cmd.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        else flg = true;

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}