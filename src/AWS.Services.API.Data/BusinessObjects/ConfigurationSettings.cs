using Microsoft.Extensions.Configuration;

namespace AWS.Services.API.Data.BusinessObjects
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        #region Global Variable(s)
        private readonly IConfiguration _configuration;
        #endregion

        public ConfigurationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Public Prop(s)
        public string AccessKey => _configuration["AWS:AccessKey"];
        public string SecretKey => _configuration["AWS:SecretKey"];
        public string QueueUrl => _configuration["AWS:AWSSQS:QueueUrl"];

        #endregion

    }
}
