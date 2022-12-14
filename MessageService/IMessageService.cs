using DataComm.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace MessageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IMessageServiceCallback))]
    public interface IMessageService
    {
        [OperationContract]
        List<MessageModel> GetMessages(string id);

        [OperationContract(IsOneWay = true)]
        void Join(string userId);

        [OperationContract(IsOneWay = true)]
        void SendMessage(MessageModel message);

        [OperationContract(IsOneWay = true)]
        void MarkDelivered(int mid);

        [OperationContract(IsOneWay = true)]
        void MarkNotDelivered(int mid);

        [OperationContract(IsOneWay = true)]
        void DeleteMessage(int mid);

        [OperationContract(IsOneWay = true)]
        void RestoreMessage(int mid);

        [OperationContract(IsOneWay = true)]
        void MarkRead(int mid);

        [OperationContract(IsOneWay = true)]
        void MarkNotRead(int mid);
    }

    public interface IMessageServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void RecieveMessage(MessageModel message);
    }
}