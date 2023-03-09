namespace NotificationBlazor.Data
{
    public class NotificationMessage
    {
        public int MsgId { get; set; }
        public string SenderName { get; set; } = "";
        public string ReceiverName { get; set; } = "";
        public string MsgTitle { get; set; } = "";
        public string MsgBody { get; set; } = "";
        public DateTime MsgDate { get; set; } = DateTime.Now;
        public string MsgDateSt => this.MsgDate.ToString("dd-MMM-yyyy");
    }
}
