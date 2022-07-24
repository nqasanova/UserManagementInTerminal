using System;
namespace UserManagement.Database.Models
{
    public class Report
    {
        public static int row = 1;
        public int Row { get; set; }
        public string Reporter { get; set; }
        public string Receiver { get; set; }
        public string Text { get; set; }
        public bool IsReceiverAdmin { get; set; }
        public DateTime ReportTime { get; set; }

        public Report(string reporter, string receiver, string text, bool isReceiverAdmin = false)
        {
            Row = row++;
            Reporter = reporter;
            Receiver = receiver;
            Text = text;
            IsReceiverAdmin = isReceiverAdmin;
            ReportTime = DateTime.Now;
        }

        public virtual string GetUserReportInfo()
        {
            return $"Row No : {Row}, Reporter : {Reporter}, Receiver : {Receiver}, Text : {Text}, Is the person receiving the text admin : {IsReceiverAdmin}, Report time : {ReportTime}";
        }

        public string GetAdminReportInfo()
        {
            return $"Row No : {Row}, Reporter : {Reporter}, Receiver : {Receiver}, Text : {Text}, Is the person receiving the text admin : {IsReceiverAdmin = true}, Report time : {ReportTime}";
        }
    }
}