using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Web.Models;

namespace FiapHackaton.Application
{
    public class AppointmentService :IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;



        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;

       
        }

        public IEnumerable<AppointmentModel> GetAllAppointments()
        {
            return _appointmentRepository.GetAllAppointments();
        }

        public AppointmentModel GetAppointmentById(int id)
        {
            return _appointmentRepository.GetAppointmentById(id);
        }

        public async Task AddAppointmentAsync(AppointmentModel appointment)
        {
            _appointmentRepository.AddAppointment(appointment);
           
        }
        public void UpdateAppointment(AppointmentModel appointment)
        {
            _appointmentRepository.UpdateAppointment(appointment);
        }

        public void CancelAppointment(int id)
        {
            var appointment = _appointmentRepository.GetAppointmentById(id);
            if (appointment != null)
            {
                appointment.Status = "Canceled";
                _appointmentRepository.UpdateAppointment(appointment);
            }
        }
    }

       
    }