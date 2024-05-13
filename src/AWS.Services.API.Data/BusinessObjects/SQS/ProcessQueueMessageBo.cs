using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace AWS.Services.API.Data.BusinessObjects.SQS
{
    public class ProcessQueueMessageBo: IProcessQueueMessageBo
    {

        #region GlobalVariable(s)
        IConfigurationSettings _configurationSettings;
        #endregion

        private AmazonSQSClient GetAmazonSQSClient()
        {
            try
            {
                var credentials = new BasicAWSCredentials(_configurationSettings.AccessKey, _configurationSettings.SecretKey);
                //RegionEndpoint might be change
                return new AmazonSQSClient(credentials, RegionEndpoint.USEast1);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public ProcessQueueMessageBo(IConfigurationSettings configurationSettings)
        {
            _configurationSettings = configurationSettings;
        }

        public async Task<bool> SendMessageAsync(string Message)
        {
            try
            {
                var _sqs = GetAmazonSQSClient();
                var sendRequest = new SendMessageRequest(_configurationSettings.QueueUrl, Message);
                // Post message or payload to queue  
                var sendResult = await _sqs.SendMessageAsync(sendRequest);

                return sendResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public async Task<List<Message>> ReceiveMessageAsync()
        {
            try
            {
                //Create New instance  
                var request = new ReceiveMessageRequest
                {
                    QueueUrl = _configurationSettings.QueueUrl,
                    MaxNumberOfMessages = 10,
                    WaitTimeSeconds = 5
                };
                var _sqs = GetAmazonSQSClient();
                //CheckIs there any new message available to process  
                var result = await _sqs.ReceiveMessageAsync(request);

                return result.Messages.Any() ? result.Messages : new List<Message>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public async Task<bool> DeleteMessageAsync(string messageReceiptHandle)
        {
            try
            {
                var _sqs = GetAmazonSQSClient();
                //Deletes the specified message from the specified queue  
                var deleteResult = await _sqs.DeleteMessageAsync(_configurationSettings.QueueUrl, messageReceiptHandle);
                return deleteResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
