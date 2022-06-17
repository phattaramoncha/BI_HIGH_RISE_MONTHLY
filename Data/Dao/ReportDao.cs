using BI_HIGH_RISE_MONTHLY.Data.CLS;
using BI_HIGH_RISE_MONTHLY.Data.Model;
using CJRPortal.App_Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BI_HIGH_RISE_MONTHLY.Data.Dao
{
    public class ReportDao : BaseDao
    {
        SEND_EMAIL mail = new SEND_EMAIL();

        public List<ProjHighRise> GetProjHighRise()
        {
            try
            {
                using (var conn = new NpgsqlConnection(DB_CONNECTION))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("spl_get_proj_high_rise", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("in_closed_date", NpgsqlTypes.NpgsqlDbType.Date, dt_prev); //XXXX,XXXX,XXXX

                        using (var reader = cmd.ExecuteReader())
                        {
                            return SQLDataMapper.MapToCollection<ProjHighRise>(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string text = "GetProgess => spl_get_proj_high_rise: " + ex.Message.ToString();
                mail.SendtoEmail(text);
                throw new Exception(ex.Message);
            }
        }

        public List<Progress> GetProgess(Guid in_projid)
        {
            try
            {
                using (var conn = new NpgsqlConnection(DB_CONNECTION))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("spl_get_bi_high_rise_progress_devv", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_projid", NpgsqlTypes.NpgsqlDbType.Uuid,
                            in_projid); //XXXX,XXXX,XXXX

                        using (var reader = cmd.ExecuteReader())
                        {
                            return SQLDataMapper.MapToCollection<Progress>(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string text = "GetProgess => spl_get_bi_high_rise_progress_zz: " + ex.Message.ToString();
                mail.SendtoEmail(text);
                throw new Exception(ex.Message);
            }
        }

        public void POST_HIGH_RISE_ASSESSMENT_CONTRACTOR_CONSTRUCTION(List<Assessment_Contractor_Construction> asscon)
        {
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
                            cmd.Parameters.AddWithValue("@progress_month",
                                ((object)item.progress_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@month", ((object)item.months) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@year", ((object)item.years) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@po_no", ((object)item.po_no) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_code",
                                ((object)item.contractor_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_full_name_snap",
                                ((object)item.contractor_full_name_snap) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@catagory_code",
                                ((object)item.catagory_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@catagory_name",
                                ((object)item.catagory_name) ?? DBNull.Value);
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
                            cmd.Parameters.AddWithValue("@g_safety_hygiene",
                                ((object)item.grade_idx_6) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@assessment",
                                ((object)item.score_assessment) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@g_assessment",
                                ((object)item.grade_assessment) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@type", ((object)item.types) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@avg_proj", ((object)item.avg_proj) ?? DBNull.Value);


                            int result = cmd.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Exc ... POST_HIGH_RISE_ASSESSMENT_CONTRACTOR_CONSTRUCTION.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string text = "Stored P. => POST_HIGH_RISE_ASSESSMENT_CONTRACTOR_CONSTRUCTION: " +
                              ex.Message.ToString();
                mail.SendtoEmail(text);
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
                    using (var cmd = new NpgsqlCommand("spl_get_bi_high_rise_assessment_contractor_construction_v2",
                               conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_progress_month", NpgsqlTypes.NpgsqlDbType.Date,
                            dt_prev); //XXXX,XXXX,XXXX

                        using (var reader = cmd.ExecuteReader())
                        {
                            return SQLDataMapper.MapToCollection<Assessment_Contractor_Construction>(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string text = "GetAssConCon => spl_get_bi_high_rise_assessment_contractor_construction_v2: " +
                              ex.Message.ToString();
                mail.SendtoEmail(text);
                throw new Exception(ex.Message);
            }
        }

        public void POST_HIGH_RISE_PROGRESS(List<Progress> progress)
        {
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
                            cmd.Parameters.AddWithValue("@rev", ((object)item.rev) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@beginning_period",
                                ((object)item.beginning_period) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@work_period", ((object)item.work_period) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@months", ((object)item.months) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@cat_code", ((object)item.cat_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@cat_name", ((object)item.cat_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@sub_cat_code", ((object)item.sub_cat_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@sub_cat_name", ((object)item.sub_cat_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_code",
                                ((object)item.contractor_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_name",
                                ((object)item.contractor_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@work_days", ((object)item.work_days) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@monthly", ((object)item.monthly) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@period", ((object)item.period) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@master_of_category",
                                ((object)item.master_of_category) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@adjust_of_category",
                                ((object)item.adjust_of_category) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@master_of_month",
                                ((object)item.master_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@adjust_of_month",
                                ((object)item.adjust_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@progress_of_month",
                                ((object)item.progress_of_month) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@cashflow_of_month",
                                ((object)item.cashflow_of_month) ?? DBNull.Value);

                            int result = cmd.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("exec ... POST_HIGH_RISE_PROGRESS.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string text = "Stored P. => POST_HIGH_RISE_PROGRESS: " + ex.Message.ToString();
                mail.SendtoEmail(text);
                throw new Exception(ex.Message);
            }
        }

        public List<Contract_Construction_Date> GetContractConstructionDate(Guid in_projid)
        {
            try
            {
                using (var conn = new NpgsqlConnection(DB_CONNECTION))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("spl_get_bi_high_rise_construction_date",
                               conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_projid", NpgsqlTypes.NpgsqlDbType.Uuid,
                            in_projid); //XXXX,XXXX,XXXX

                        using (var reader = cmd.ExecuteReader())
                        {
                            return SQLDataMapper.MapToCollection<Contract_Construction_Date>(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string text = "GetContractConstructionDate => spl_get_bi_high_rise_construction_date: " +
                              ex.Message.ToString();
                mail.SendtoEmail(text);
                throw new Exception(ex.Message);
            }
        }

        public void POST_HIGH_RISE_CONTRACT_CONSTRUCTION_DATE(List<Contract_Construction_Date> contract)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CRMDB_CONNECTION))
                {
                    using (SqlCommand cmd = new SqlCommand("POST_HIGH_RISE_CONTRACT_CONSTRUCTION_DATE", conn))
                    {
                        conn.Open();

                        foreach (var item in contract)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@proj_code", ((object)item.proj_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@proj_name", ((object)item.proj_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@po_no", ((object)item.po_no) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_code",
                                ((object)item.contractor_code) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@contractor_name",
                                ((object)item.contractor_name) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@construction_start_date",
                                ((object)item.construction_start_date) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@construction_end_date",
                                ((object)item.construction_end_date) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@work_days", ((object)item.work_days) ?? DBNull.Value);

                            cmd.Parameters.AddWithValue("@rpt_kpi_proj_start_date",
                                ((object)item.rpt_kpi_proj_start_date) ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@rpt_kpi_proj_end_date",
                                ((object)item.rpt_kpi_proj_end_date) ?? DBNull.Value);

                            int result = cmd.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("exec ... POST_HIGH_RISE_CONTRACT_CONSTRUCTION_DATE.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string text = "Stored P. => POST_HIGH_RISE_CONTRACT_CONSTRUCTION_DATE: " + ex.Message.ToString();
                mail.SendtoEmail(text);
                throw new Exception(ex.Message);
            }
        }
    }
}