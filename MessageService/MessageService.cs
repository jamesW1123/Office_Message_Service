﻿using DataComm;
using DataComm.DbAccess;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace MessageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class MessageService : IMessageService
    {
        private Dictionary<string, IMessageServiceCallback> users = new Dictionary<string, IMessageServiceCallback>();

        public void DeleteMessage(int mid)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllMessages(string id)
        {
            var messages = DB.GetAllMessages(id);

            return messages;
        }

        public List<Message> GetDeletedMessages(string id)
        {
            var messages = DB.GetAllMessages(id);

            return messages;
        }

        public List<Message> GetNewMessages(string id)
        {
            var messages = DB.GetAllMessages(id);

            return messages;
        }

        public void Join(string userId)
        {
            users.Add(userId, OperationContext.Current.GetCallbackChannel<IMessageServiceCallback>());
        }

        public void Leave(string userId)
        {
            users.Remove(userId);
        }

        public void MarkDelivered(int mid)
        {
            throw new NotImplementedException();
        }

        public void MarkNotDelivered(int mid)
        {
            throw new NotImplementedException();
        }

        public void MarkNotRead(int mid)
        {
            throw new NotImplementedException();
        }

        public void MarkRead(int mid)
        {
            throw new NotImplementedException();
        }

        public void RestoreMessage(int mid)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Message message)
        {
            Console.WriteLine(message.Name);
            Console.WriteLine(message.Address);
            Console.WriteLine(message.Phone);
            Console.WriteLine(message.Email);
            Console.WriteLine(message.Message_Text);
            Console.WriteLine(message.Date_Taken);
            Console.WriteLine(message.Recipient);

            DB.Insert(message);

            string rec = message.Recipient;

            var con = users[rec];
            con.RecieveMessage(message);
        }
    }
}