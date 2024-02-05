using Microsoft.AspNetCore.Mvc;
using YourNamespace.Model;
using YourNamespace.Services;

namespace YourNamespace.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessagesService _messagesService;

        public MessagesController(MessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpGet]
        public ActionResult<List<Messages>> Get() =>
            _messagesService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMessages")]
        public ActionResult<Messages> Get(string id)
        {
            var messages = _messagesService.Get(id);

            if (messages == null)
            {
                return NotFound();
            }

            return messages;
        }

        [HttpPost]
        public ActionResult<Messages> Create(Messages messages)
        {
            _messagesService.Create(messages);

            return CreatedAtRoute("GetMessages", new { id = messages.Id.ToString() }, messages);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Messages messagesIn)
        {
            var messages = _messagesService.Get(id);

            if (messages == null)
            {
                return NotFound();
            }

            _messagesService.Update(id, messagesIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var messages = _messagesService.Get(id);

            if (messages == null)
            {
                return NotFound();
            }

            _messagesService.Remove(messages.Id);

            return NoContent();
        }


        [HttpGet("tenant/{tenantId}")]
        public IActionResult GetByTenantId(string tenantId)
        {
            var messages = _messagesService.GetByTenantId(tenantId);

            if (messages == null || messages.Count == 0)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        [HttpGet("landlord/{landlordId}")]
        public IActionResult GetByLandlordId(string landlordId)
        {
            var messages = _messagesService.GetByLandlordId(landlordId);

            if (messages == null || messages.Count == 0)
            {
                return NotFound();
            }

            return Ok(messages);
        }
    }
}
