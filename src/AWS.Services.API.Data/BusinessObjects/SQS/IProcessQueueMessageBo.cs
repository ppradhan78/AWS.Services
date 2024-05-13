using Amazon.SQS.Model;

namespace AWS.Services.API.Data.BusinessObjects.SQS
{
    public interface IProcessQueueMessageBo
    {
        Task<bool> SendMessageAsync(string Message);
        Task<List<Message>> ReceiveMessageAsync();
        Task<bool> DeleteMessageAsync(string messageReceiptHandle);
    }
}
