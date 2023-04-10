using DataComm;
using System.Collections.Generic;
using System.ServiceModel;

namespace MessageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IMessageServiceCallback))]
    public interface IMessageService
    {
        [OperationContract(IsOneWay = true)]
        void DeleteMessage(int mid);

        [OperationContract]
        List<User> GetActiveUsers();

        [OperationContract]
        List<Message> GetAllMessages(string id);

        [OperationContract]
        List<Message> GetDeletedMessages(string id);

        [OperationContract]
        List<Message> GetNewMessages(string id);

        [OperationContract(IsOneWay = true)]
        void Join(string userId);

        [OperationContract(IsOneWay = true)]
        void Leave(string userId);

        [OperationContract(IsOneWay = true)]
        void MarkDelivered(int mid);

        [OperationContract(IsOneWay = true)]
        void MarkNotDelivered(int mid);

        [OperationContract(IsOneWay = true)]
        void MarkNotRead(int mid);

        [OperationContract(IsOneWay = true)]
        void MarkRead(int mid);

        [OperationContract(IsOneWay = true)]
        void RestoreMessage(int mid);

        [OperationContract(IsOneWay = true)]
        void SendMessage(Message message);
    }

    public interface IMessageServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void RecieveMessage(Message message);
    }
}