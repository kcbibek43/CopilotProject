using YourNamespace.Model;
using YourNamespace.Services;
using Microsoft.AspNetCore.Mvc;

namespace CopilotProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertiesService _propertiesService;

        public PropertiesController(PropertiesService propertiesService)
        {
            _propertiesService = propertiesService;
        }

        [HttpGet]
        public ActionResult<List<Property>> Get() =>
            _propertiesService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProperty")]
        public ActionResult<Property> Get(string id)
        {
            var property = _propertiesService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            return property;
        }

        [HttpPost]
        public ActionResult<Property> Create(Property property)
        {
            _propertiesService.Create(property);

            return CreatedAtRoute("GetProperty", new { id = property.Id.ToString() }, property);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Property propertyIn)
        {
            var property = _propertiesService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            _propertiesService.Update(id, propertyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var property = _propertiesService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            _propertiesService.Remove(property.Id);

            return NoContent();
        }
        [HttpGet("ByLandLord/{landLordId}")]
        public ActionResult<List<Property>> GetByLandLordId(string landLordId)
        {
            var properties = _propertiesService.GetByLandLordId(landLordId);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }
    }
}
