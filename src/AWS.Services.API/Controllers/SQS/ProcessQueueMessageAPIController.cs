using AWS.Services.API.Data.Core;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Services.API.Controllers.SQS
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessQueueMessageAPIController : ControllerBase
    {

        #region Global Variable(s)
        private readonly IProcessQueueMessageCore _processQueueMessage;
        private readonly ILogger _logger;
        #endregion

        public ProcessQueueMessageAPIController(IProcessQueueMessageCore processQueueMessage,
            ILogger<ProcessQueueMessageAPIController> logger)
        {
            _processQueueMessage = processQueueMessage;
            _logger = logger;
        }

        [Route("postMessage")]
        [HttpPost]
        public async Task<IActionResult> PostMessageAsync([FromBody] string message)
        {
            var result = await _processQueueMessage.SendMessageAsync(message);
            return Ok(new { isSucess = result });
        }
        [Route("getAllMessages")]
        [HttpGet]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            var result = await _processQueueMessage.ReceiveMessageAsync();
            return Ok(result);
        }
       
    }
}
