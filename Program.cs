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
            Program pg = new Program();

            DateTime dt_prev = DateTime.Now.AddMonths(-1);
            //DateTime dt_now = DateTime.Now;

            //DateTime dt = DateTime.Now.AddDays(-1);

            //Set First Day of Month
            dt_prev = new DateTime(dt_prev.Year, dt_prev.Month, 1);
            //dt_now = new DateTime(dt_now.Year, dt_now.Month, 1);

            #region progress
            try
            {
                //var cls = new PROGRESS();
                //cls.exc();
            }
            catch (Exception ex)
            {
                string text = "excBIProgress: " + ex.Message.ToString();
                bool flgBIProgress = pg.SendtoEmail(text);
            }


            #endregion

            #region  Assessment_Contractor_Construction ประเมินผู้รับเหมา งานก่อนสร้าง
            try
            {
                var cls = new ASSESSMENT_CONTRACTOR_CONSTRUCTION();
                cls.exc(dt_prev);
            }
            catch (Exception ex)
            {
                string text = "excBIAssessment_Contractor_Construction: " + ex.Message.ToString();
                bool flgBIAssCon = pg.SendtoEmail(text);
            }



            #endregion
        }
        public bool SendtoEmail(string strBody)
        {
            bool flg = false;
            try
            {

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //for gmail host 
                smtp.Port = 587;

                smtp.Credentials = new NetworkCredential("system@supalai.com", "SPL@cm#1!");
                smtp.EnableSsl = true;

                MailMessage message = new MailMessage();
                ///FromMailAddress
                //message.From = new MailAddress("phattaramon.cha@supalai.com", "Mine");

                message.From = new MailAddress("erp@supalai.com", "Supalai IT (BI High Rise)");
                ///ToMailAddress
                message.To.Add(new MailAddress("it@supalai.com"));
                message.Subject = "Error : BI High Rise";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = strBody;

                smtp.Send(message);
                flg = true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Console.Write(ex.ToString());
                flg = false;
            }
            return flg;
        }
    }
}
