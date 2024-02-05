using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controller
{
    using YourNamespace.Model;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentsController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public ActionResult<List<Document>> Get() =>
            _documentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDocument")]
        public ActionResult<Document> Get(string id)
        {
            var document = _documentService.Get(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        [HttpPost]
        public ActionResult<Document> Create(Document document)
        {
            _documentService.Create(document);

            return CreatedAtRoute("GetDocument", new { id = document.Id.ToString() }, document);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Document documentIn)
        {
            var document = _documentService.Get(id);

            if (document == null)
            {
                return NotFound();
            }

            _documentService.Update(id, documentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var document = _documentService.Get(id);

            if (document == null)
            {
                return NotFound();
            }

            _documentService.Remove(document.Id);

            return NoContent();
        }
        [HttpGet("tenant/{tenantId}")]
        public IActionResult GetByTenantId(string tenantId)
        {
            var document = _documentService.GetByTenantId(tenantId);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpGet("landlord/{landlordId}")]
        public IActionResult GetByLandlordId(string landlordId)
        {
            var document = _documentService.GetByLandlordId(landlordId);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }
    }
}
