using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using YourNamespace.Models;
    using YourNamespace.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public ActionResult<List<Appointment>> Get() =>
            _appointmentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAppointment")]
        public ActionResult<Appointment> Get(string id)
        {
            var appointment = _appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        [HttpPost]
        public ActionResult<Appointment> Create(Appointment appointment)
        {
            _appointmentService.Create(appointment);

            return CreatedAtRoute("GetAppointment", new { id = appointment.Id.ToString() }, appointment);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Appointment appointmentIn)
        {
            var appointment = _appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Update(id, appointmentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var appointment = _appointmentService.Get(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Remove(appointment.Id);

            return NoContent();
        }
    }
}
