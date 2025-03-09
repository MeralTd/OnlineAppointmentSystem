using Application.Features.Users.Commands;
using Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private IUserSessionHelper _userSession;

        public UserController(IMediator mediator, IUserSessionHelper sessionHelper)
        {
            _mediator = mediator;
            _userSession = sessionHelper;
        }
        public async Task<IActionResult> Index()
        {
            if (_userSession.GetUser() == null)
            {
                return RedirectToAction("SignIn", "Auth");

            }

            if (_userSession.Rol != "Admin")
            {
                return RedirectToAction("Index", "Appointment");

            }

            var users = await _mediator.Send(new GetAllUser());

            return View(users.Data);
        }



        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUser createUser)
        {
            var users = await _mediator.Send(createUser);

            return Json(users);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUser updateUser)
        {
            var users = await _mediator.Send(updateUser);


            return Json(users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUser deleteUser)
        {
            var users = await _mediator.Send(deleteUser);


            return Json(users);
        }


        [HttpPost]
        public async Task<IActionResult> GetUser(GetUserById getUserById)
        {
            var users = await _mediator.Send(getUserById);


            return Json(users);
        }
    }
}
