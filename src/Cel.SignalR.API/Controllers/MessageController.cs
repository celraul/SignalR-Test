using Cel.SignalR.Application.Models.Message;
using Cel.SignalR.Application.UseCases.MessageUseCases.Commands;
using Cel.SignalR.Application.UseCases.MessageUseCases.Queries.GetUserMessages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cel.SignalR.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMediator _mediator;

        public MessageController(ILogger<MessageController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MessageModel message)
        {
            bool response = await _mediator.Send(new SendMessageCommand(message));

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string id)
        {
            List<MessageModel> response = await _mediator.Send(new GetUserMessagesQuery(id));

            return Ok(response);
        }
    }
}
