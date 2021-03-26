using BI_HIGH_RISE_MONTHLY.Data.Model;
using CJRPortal.App_Helpers;
using Npgsql;
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

        public void POST_HIGH_RISE_ASSESSMENT_CONTRACTOR_CONSTRUCTION(List<Assessment_Contractor_Construction> asscon)
        {
            bool flg = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(CRMDB_CONNECTION))
                {
                    using (SqlCommand cmd = new SqlCommand("POST_HIGH_RISE_ASSESSMENT_CONTRACTOR_CONSTRUCTION", conn))
                    {
                        conn.Open();

                        foreach (var item in asscon)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();  
                            cmd.Parameters.AddWithValue("@proj_code", ((object)item.proj_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@proj_name", ((object)item.proj_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@progress_month", ((object)item.progress_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@month", ((object)item.months) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@year", ((object)item.years) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@po_no", ((object)item.po_no) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_code", ((object)item.contractor_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_full_name_snap", ((object)item.contractor_full_name_snap) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@catagory_code", ((object)item.catagory_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@catagory_name", ((object)item.catagory_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@job_quality", ((object)item.score_idx_0) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_job_quality", ((object)item.grade_idx_0) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@man_days", ((object)item.score_idx_1) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_man_days", ((object)item.grade_idx_1) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@personnel", ((object)item.score_idx_2) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_personnel", ((object)item.grade_idx_2) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@coordination", ((object)item.score_idx_3) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_coordination", ((object)item.grade_idx_3) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@management", ((object)item.score_idx_4) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_management", ((object)item.grade_idx_4) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@service", ((object)item.score_idx_5) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_service", ((object)item.grade_idx_5) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@safety_hygiene", ((object)item.score_idx_6) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_safety_hygiene", ((object)item.grade_idx_6) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@assessment", ((object)item.score_assessment) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_assessment", ((object)item.grade_assessment) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@type", ((object)item.types) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@avg_proj", ((object)item.avg_proj) ?? DBNull.Value);


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

        public List<Assessment_Contractor_Construction> GetAssConCon(DateTime dt_prev)
        {
            try
            {
                using (var conn = new NpgsqlConnection(DB_CONNECTION))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("spl_get_bi_high_rise_assessment_contractor_construction_v2", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_progress_month", NpgsqlTypes.NpgsqlDbType.Date, dt_prev); //XXXX,XXXX,XXXX

                        using (var reader = cmd.ExecuteReader())
                        {
                            return SQLDataMapper.MapToCollection<Assessment_Contractor_Construction>(reader);
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