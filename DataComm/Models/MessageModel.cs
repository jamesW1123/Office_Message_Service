﻿namespace DataComm.Models
{
    public class MessageModel
    {
        public int Mid { get; private set; }
        public string Recipient { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message_Text { get; set; }
        public string Date_Taken { get; set; }
        public string Sent_From { get; set; }
        public int Delivered { get; set; }
        public int Read { get; set; }
        public int Deleted { get; set; }
    }
}