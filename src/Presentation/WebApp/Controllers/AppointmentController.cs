using Application.Features.Appointments.Commands;
using Application.Features.Appointments.Queries;
using Application.Features.Services.Queries;
using Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApp.Helper;

namespace WebApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;
        private IUserSessionHelper _userSession;

        public AppointmentController(IMediator mediator, IUserSessionHelper userSession)
        {
            _mediator = mediator;
            _userSession = userSession;
        }
        public async Task<IActionResult> Index()
        {

            if (_userSession.GetUser() == null)
            {
                return RedirectToAction("SignIn", "Auth");


            }

            if (_userSession.Rol == "Admin")
            {
                var appointmentAll = await _mediator.Send(new GetAllAppointment());
                return View(appointmentAll.Data);

            }


            var getAllAppointmentByUserId = new GetAllAppointmentByUserId();
            getAllAppointmentByUserId.UserId = _userSession.GetUser().Id;
            var appointment = await _mediator.Send(getAllAppointmentByUserId);
            return View(appointment.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAndServices()
        {
            var users = await _mediator.Send(new GetAllUser());  // Adjust the query to get users
            var services = await _mediator.Send(new GetAllService());  // Adjust the query to get services

            var response = new
            {
                users = users.Data.Select(u => new { u.Id, u.FirstName, u.LastName }).ToList(),
                services = services.Data.Select(s => new { s.Id, s.Name }).ToList()
            };

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(CreateAppointment createAppointment)
        {
            var appointment = await _mediator.Send(createAppointment);



            return Json(appointment);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointment updateAppointment)
        {
            var appointment = await _mediator.Send(updateAppointment);


            return Json(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(DeleteAppointment deleteAppointment)
        {
            var appointment = await _mediator.Send(deleteAppointment);


            return Json(appointment);
        }


        [HttpPost]
        public async Task<IActionResult> GetAppointment(GetAppointmentById getAppointmentById)
        {
            var appointment = await _mediator.Send(getAppointmentById);


            return Json(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(ChangeAppointmentStatus changeAppointmentStatus)
        {
            var appointment = await _mediator.Send(changeAppointmentStatus);


            return Json(appointment);
        }

    }
}
