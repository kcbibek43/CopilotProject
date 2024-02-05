namespace YourNamespace.Services
{
    using MongoDB.Driver;
    using System.Collections.Generic;
    using YourNamespace.Models;

    public class AppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(MongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _appointments = database.GetCollection<Appointment>("Appointment");
        }

        public List<Appointment> Get() =>
            _appointments.Find(appointment => true).ToList();

        public Appointment Get(string id) =>
            _appointments.Find<Appointment>(appointment => appointment.Id == id).FirstOrDefault();

        public Appointment Create(Appointment appointment)
        {
            _appointments.InsertOne(appointment);
            return appointment;
        }

        public void Update(string id, Appointment appointmentIn) =>
            _appointments.ReplaceOne(appointment => appointment.Id == id, appointmentIn);

        public void Remove(Appointment appointmentIn) =>
            _appointments.DeleteOne(appointment => appointment.Id == appointmentIn.Id);

        public void Remove(string id) => 
            _appointments.DeleteOne(appointment => appointment.Id == id);
    }
}
