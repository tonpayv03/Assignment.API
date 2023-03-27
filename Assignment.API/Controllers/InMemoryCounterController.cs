using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
	[ApiController]
	[Route("/")]
	public class InMemoryCounterController : ControllerBase
	{
		public static int number;
		private object lockObject = new object();
		public InMemoryCounterController()
		{

		}

		[HttpGet("api/view/counter")]
		public IActionResult GetCounter()
		{
			return Ok(number);
		}


		[HttpPost("api/view/counter")]
		public IActionResult Counter()
		{
			// Synchronization, Queue
			lock (lockObject)
			{
				return Ok(++number);
			}
		}

		[HttpDelete("api/view/counter")]
		public IActionResult DeleteCounter()
		{
			number = 0;
			return Ok();
		}
	}
}
