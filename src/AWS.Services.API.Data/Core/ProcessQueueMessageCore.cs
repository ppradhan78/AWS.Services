using Amazon.SQS.Model;
using AWS.Services.API.Data.BusinessObjects.SQS;

namespace AWS.Services.API.Data.Core
{
    public class ProcessQueueMessageCore : IProcessQueueMessageCore
    {
        #region GlobalVariable(s)
        IProcessQueueMessageBo _processQueueMessageBo;
        #endregion

        public ProcessQueueMessageCore(IProcessQueueMessageBo processQueueMessageBo) 
        {
            _processQueueMessageBo = processQueueMessageBo;
        }    
        public Task<bool> DeleteMessageAsync(string messageReceiptHandle)
        {
          return  _processQueueMessageBo.DeleteMessageAsync(messageReceiptHandle);
        }

        public Task<List<Message>> ReceiveMessageAsync()
        {
            return _processQueueMessageBo.ReceiveMessageAsync();

        }

        public Task<bool> SendMessageAsync(string Message)
        {
            return _processQueueMessageBo.SendMessageAsync(Message);

        }
    }
}
