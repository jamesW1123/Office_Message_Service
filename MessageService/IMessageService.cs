using DataComm.Models;
using System.ServiceModel;

namespace MessageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IMessageServiceCallback))]
    public interface IMessageService
    {
        [OperationContract(IsOneWay = true)]
        void ProcessReport();

        [OperationContract]
        MessageModel GetMessage(string id);

        [OperationContract(IsOneWay = true)]
        void Join(string userId);

        [OperationContract(IsOneWay = true)]
        void SendMessage(MessageModel message);
    }

    public interface IMessageServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Progress(int percentageCompleted);

        [OperationContract(IsOneWay = true)]
        void RecieveMessage(MessageModel message);
    }
}