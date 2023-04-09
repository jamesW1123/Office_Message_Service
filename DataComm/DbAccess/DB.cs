﻿using Dapper;
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

        public static void Delete(int mid)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "UPDATE Messages \n" +
                        "SET deleted = 1 \n" +
                        "WHERE mid = @mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@mid", mid);

                    conn.Execute(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<Message> GetAllMessages(string recipient)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "SELECT * \n" +
                        "FROM messages \n" +
                        "WHERE recipient = @recipient AND deleted = 0";

                    var parameters = new DynamicParameters();
                    parameters.Add("@recipient", recipient);

                    var output = conn.Query<Message>(sql, parameters);
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static List<Message> GetDeletedMessages(string recipient)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "SELECT * \n" +
                        "FROM messages \n" +
                        "WHERE recipient = @recipient AND deleted = 1";

                    var parameters = new DynamicParameters();
                    parameters.Add("@recipient", recipient);

                    var output = conn.Query<Message>(sql, parameters);
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static List<Message> GetNewMessages(string recipient)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "SELECT * \n" +
                        "FROM messages \n" +
                        "WHERE recipient = @recipient AND delivered = 0 AND deleted = 0";

                    var parameters = new DynamicParameters();
                    parameters.Add("@recipient", recipient);

                    var output = conn.Query<Message>(sql, parameters);
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static void Insert(Message message)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "INSERT INTO Messages \n" +
                        "(recipient, name, address, phone, email, message_text, date_taken, sent_from, delivered) \n" +
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
                    string sql = "UPDATE Messages \n" +
                        "SET delivered = 1 \n" +
                        "WHERE mid = @mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@mid", mid);

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
                    string sql = "UPDATE Messages \n" +
                        "SET delivered = 0 \n" +
                        "WHERE mid = @mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@mid", mid);

                    conn.Execute(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void MarkNotRead(int mid)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "UPDATE Messages \n" +
                        "SET read = 0 \n" +
                        "WHERE mid = @mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@mid", mid);

                    conn.Execute(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void MarkRead(int mid)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "UPDATE Messages \n" +
                        "SET read = 1 \n" +
                        "WHERE mid = @mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@mid", mid);

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
                var output = conn.Query<Message>("SELECT * FROM messages", new DynamicParameters());
                foreach (Message msg in output)
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

        public static void Restore(int mid)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    string sql = "UPDATE Messages \n" +
                        "SET deleted = 0 \n" +
                        "WHERE mid = @mid";

                    var parameters = new DynamicParameters();
                    parameters.Add("@mid", mid);

                    conn.Execute(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}