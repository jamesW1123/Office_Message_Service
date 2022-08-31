using Dapper;
using DataComm.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DataComm.DbAccess
{
    public class DB
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public static void Insert(MessageModel message)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "INSERT INTO Messages" +
                        "(recipient, name, address, phone, email, message_text, date_taken, sent_from, delivered) " +
                        "VALUES(@Recipient, @Name, @Address, @Phone, @Email, @Message_Text, @Date_Taken, @Sent_From, @Delivered)";

                    conn.Execute(sql, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void MarkDelivered(int mid)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "UPDATE Messages" +
                        "SET delivered = 1" +
                        "WHERE mid = @Mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@recipient", mid);

                    conn.Execute(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void MarkNotDelivered(int mid)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "UPDATE Messages" +
                        "SET delivered = 0" +
                        "WHERE mid = @Mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@recipient", mid);

                    conn.Execute(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void Read()
        {
            using (IDbConnection conn = new SQLiteConnection(_connectionString))
            {
                var output = conn.Query<MessageModel>("SELECT * FROM messages", new DynamicParameters());
                foreach (MessageModel msg in output)
                {
                    //Console.WriteLine(msg.Mid);
                    //Console.WriteLine(msg.Recipient);
                    //Console.WriteLine(msg.Name);
                    //Console.WriteLine(msg.Address);
                    //Console.WriteLine(msg.Phone);
                    //Console.WriteLine(msg.Email);
                    //Console.WriteLine(msg.MessageText);
                    //Console.WriteLine(msg.DateTaken);
                    //Console.WriteLine(msg.Delivered);
                    //Console.WriteLine(msg.SentFrom);
                }
            }
        }

        public static List<MessageModel> GetMessages(string recipient)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "SELECT * FROM messages WHERE recipient = @recipient";

                    var parameters = new DynamicParameters();
                    parameters.Add("@recipient", recipient);

                    var output = conn.Query<MessageModel>(sql, parameters);
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}