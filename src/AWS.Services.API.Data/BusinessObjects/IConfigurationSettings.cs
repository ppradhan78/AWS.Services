namespace AWS.Services.API.Data.BusinessObjects
{
    public interface IConfigurationSettings
    {
        string QueueUrl { get; }
        string AccessKey { get; }
        string SecretKey { get; }
    }
}
