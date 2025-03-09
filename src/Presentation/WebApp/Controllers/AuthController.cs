using Application.Features.Authorizations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using WebApp.Helper;

namespace WebApp.Controllers
{
	public class AuthController : Controller
	{
		private readonly IMediator _mediator;
		private IUserSessionHelper _userSession;
		private readonly IToastNotification _toastNotification;

		public AuthController(IMediator mediator, IUserSessionHelper userSession, IToastNotification toastNotification)
		{
			_mediator = mediator;
			_userSession = userSession;
			_toastNotification = toastNotification;
		}
		public IActionResult SignIn()
		{
			if (IsUserLoggedIn())
			{
				return RedirectToAction("Index", "Appointment");

			}
			return View("SignIn");

		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginUser loginUser)
		{

			var loginResult = await _mediator.Send(loginUser);

			if (loginResult.Success)
			{
				_userSession.SetUser(loginResult.Data.User);

				_toastNotification.AddSuccessToastMessage("You have logged in successfully.");


				return RedirectToAction("Index", "Appointment");

			}

			_toastNotification.AddErrorToastMessage(loginResult.Message);
			return View("SignIn");


		}

		public IActionResult Logout()
		{
			Response.Cookies.Delete(".AdventureWorks.Session");
			_userSession.Clear();
			return RedirectToAction("SignIn");
		}


		public bool IsUserLoggedIn()
		{
			return _userSession.GetUser() != null;
		}

	}
}
