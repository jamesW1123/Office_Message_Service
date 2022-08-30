using Dapper;
using DataComm.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace DataComm.DbAccess
{
    public class DB
    {
        public static void Insert(MessageModel message)
        {
            //Message message = new Message();
            //message.Name = "Someone Else";
            //message.Address = "123 Any St.";
            //message.Phone = "123-123-1234";
            //message.Email = "someone@email.com";
            //message.MessageText = "Some message goes here";
            //message.DateTaken = DateTime.Now.ToString();
            //message.Recipient = "user2";

            message.Mid = GenerateMid(message);

            string sql = "INSERT INTO Messages" +
                "(mid, recipient, name, address, phone, email, message_text, date_taken, sent_from, delivered) " +
                "VALUES(@Mid, @Recipient, @Name, @Address, @Phone, @Email, @MessageText, @DateTaken, @SentFrom, @Delivered)";

            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute(sql, message);
            }
        }

        public static void Read()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<MessageModel>("SELECT * FROM messages", new DynamicParameters());
                foreach (MessageModel msg in output)
                {
                    Console.WriteLine(msg.Mid);
                    Console.WriteLine(msg.Recipient);
                    Console.WriteLine(msg.Name);
                    Console.WriteLine(msg.Address);
                    Console.WriteLine(msg.Phone);
                    Console.WriteLine(msg.Email);
                    Console.WriteLine(msg.MessageText);
                    Console.WriteLine(msg.DateTaken);
                    Console.WriteLine(msg.Delivered);
                    Console.WriteLine(msg.SentFrom);
                }
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private static string GenerateMid(MessageModel message)
        {
            return message.GetHashCode().ToString();
        }
    }
}