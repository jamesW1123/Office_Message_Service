using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Host
{
    internal class HostMain
    {
        private static void Main(string[] args)
        {
            //User user = new User();
            //user.User_Name = "user3";
            //user.Display_Name = "User 3";

            //DB.RegisterUser(user);

            //Message message = new Message();
            //message.Name = "NoOne Else";
            //message.Address = "Some St.";
            //message.Phone = "987-987-9876";
            //message.Email = "anyone@email.com";
            //message.Message_Text = "ANY message can go here";
            //message.Date_Taken = DateTime.Now.ToString();
            //message.Recipient = "user3";
            //message.Sent_From = "user1";
            //DB.Insert(message);

            var x = DataComm.DbAccess.DB.GetAllMessages("user3");
            foreach (DataComm.Message msg in x)
            {
                Console.WriteLine(msg.Mid);
                Console.WriteLine(msg.Recipient);
                Console.WriteLine(msg.Name);
                Console.WriteLine(msg.Address);
                Console.WriteLine(msg.Phone);
                Console.WriteLine(msg.Email);
                Console.WriteLine(msg.Message_Text);
                Console.WriteLine(msg.Date_Taken);
                Console.WriteLine(msg.Sent_From);
                Console.WriteLine(msg.Delivered);
                Console.WriteLine("read: " + msg.Read);
                Console.WriteLine(msg.Deleted);
                Console.WriteLine();

                DataComm.DbAccess.DB.MarkRead(msg.Mid);
            }
            Console.WriteLine("______________________________________________________________________________________________");
            x = DataComm.DbAccess.DB.GetNewMessages("user3");
            foreach (DataComm.Message msg in x)
            {
                Console.WriteLine(msg.Mid);
                Console.WriteLine(msg.Name);
                Console.WriteLine(msg.Delivered);
                Console.WriteLine("read: " + msg.Read);
                Console.WriteLine(msg.Deleted);
                Console.WriteLine();

                DataComm.DbAccess.DB.MarkNotRead(msg.Mid);
            }
            //Console.WriteLine("______________________________________________________________________________________________");
            //x = DB.GetDeletedMessages("user3");
            //foreach (Message msg in x)
            //{
            //    Console.WriteLine(msg.Mid);
            //    Console.WriteLine(msg.Name);
            //    Console.WriteLine(msg.Delivered);
            //    Console.WriteLine(msg.Read);
            //    Console.WriteLine(msg.Deleted);
            //    Console.WriteLine();

            //    //DB.Delete(msg.Mid);
            //}
            //Console.WriteLine("______________________________________________________________________________________________");
            //x = DB.GetMessages("user3");
            //foreach (MessageModel msg in x)
            //{
            //    Console.WriteLine(msg.Mid);
            //    Console.WriteLine(msg.Name);
            //    Console.WriteLine(msg.Delivered);
            //    Console.WriteLine(msg.Read);
            //    Console.WriteLine(msg.Deleted);
            //    Console.WriteLine();

            //    //DB.Restore(msg.Mid);
            //}
            //Console.WriteLine("______________________________________________________________________________________________");
            //x = DB.GetMessages("user3");
            //foreach (MessageModel msg in x)
            //{
            //    Console.WriteLine(msg.Mid);
            //    Console.WriteLine(msg.Name);
            //    Console.WriteLine(msg.Delivered);
            //    Console.WriteLine(msg.Read);
            //    Console.WriteLine(msg.Deleted);
            //    Console.WriteLine();
            //}

            using (ServiceHost host = new ServiceHost(typeof(MessageService.MessageService)))
            {
                ServiceMetadataBehavior serviceMetadataBehavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true,
                };

                host.Description.Behaviors.Add(serviceMetadataBehavior);
                host.AddServiceEndpoint(typeof(MessageService.IMessageService), new NetTcpBinding(), "MessageService");
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}