using Amazon.SQS.Model;

namespace AWS.Services.API.Data.Core
{
    public interface IProcessQueueMessageCore
    {
        Task<bool> SendMessageAsync(string Message);
        Task<List<Message>> ReceiveMessageAsync();
        Task<bool> DeleteMessageAsync(string messageReceiptHandle);
    }
}
