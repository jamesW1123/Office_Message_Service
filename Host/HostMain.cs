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
            message.MessageText = "ANY message can go here";
            message.DateTaken = DateTime.Now.ToString();
            message.Recipient = "user3";
            message.SentFrom = "user1";

            DB.Insert(message);
            DB.Read();

            using (ServiceHost host = new ServiceHost(typeof(MessageService.MessageService)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}