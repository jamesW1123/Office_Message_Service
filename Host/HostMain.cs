using DataComm.DbAccess;
using DataComm.Models;
using System;
using System.ServiceModel;

namespace Host
{
    internal class HostMain
    {
        private static void Main(string[] args)
        {
            MessageModel message = new MessageModel();
            message.Name = "Anyone Else";
            message.Address = "Some St.";
            message.Phone = "987-987-9876";
            message.Email = "anyone@email.com";
            message.Message_Text = "ANY message can go here";
            message.Date_Taken = DateTime.Now.ToString();
            message.Recipient = "user3";
            message.Sent_From = "user1";

            DB.Insert(message);
            DB.Read();
            var x = DB.GetMessages("user3");
            foreach (MessageModel msg in x)
            {
                Console.WriteLine(msg.Mid);
                Console.WriteLine(msg.Recipient);
                Console.WriteLine(msg.Name);
                Console.WriteLine(msg.Address);
                Console.WriteLine(msg.Phone);
                Console.WriteLine(msg.Email);
                Console.WriteLine(msg.Message_Text);
                Console.WriteLine(msg.Date_Taken);
                Console.WriteLine(msg.Delivered);
                Console.WriteLine(msg.Sent_From);
            }

            using (ServiceHost host = new ServiceHost(typeof(MessageService.MessageService)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}