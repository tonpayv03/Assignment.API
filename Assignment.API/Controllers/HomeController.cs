using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
	[Route("/")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		public string Get()
		{
			return "API Start!!";
		}
	}
}
