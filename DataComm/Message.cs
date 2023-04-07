namespace DataComm
{
    public class Message
    {
        public string Address { get; set; }
        public string Date_Taken { get; set; }
        public int Deleted { get; set; }
        public int Delivered { get; set; }
        public string Email { get; set; }
        public string Message_Text { get; set; }
        public int Mid { get; private set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Read { get; set; }
        public string Recipient { get; set; }
        public string Sent_From { get; set; }
    }
}