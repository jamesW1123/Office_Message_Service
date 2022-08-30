namespace DataComm.Models
{
    public class MessageModel
    {
        public string Mid { get; set; }
        public string Recipient { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MessageText { get; set; }
        public string DateTaken { get; set; }
        public int Delivered { get; set; }
        public string SentFrom { get; set; }
    }
}