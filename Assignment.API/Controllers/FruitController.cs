using Assignment.API.Middlewares;
using Assignment.BSL.Services;
using Assignment.DTO.Interfaces.IServices;
using Assignment.DTO.Models.Fruit.AddFruit;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
	[ServiceFilter(typeof(ValidationFilterAttribute))]
	[Route("api/v1/[controller]")]
	[ApiController]
	public class FruitController : ControllerBase
	{
		private readonly IFruitService _fruitService;

		public FruitController(IFruitService fruitService)
		{
			_fruitService = fruitService;
		}

		[HttpGet("ListAllFruit")]
		public async Task<IActionResult> ListAllFruit()
		{
			try
			{
				var result = await _fruitService.ListAllFruit();
				return StatusCode(result.StatusCode, result);
				throw new NotImplementedException();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, Helpers.InternalServerErrorResponse());
			}
		}

		[HttpPost(nameof(AddFruit))]
		public async Task<IActionResult> AddFruit([FromForm] AddFruitRequest request)
		{
			try
			{
				var result = await _fruitService.AddFruit(request);
				return StatusCode(result.StatusCode, result);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
			}
		}

		[HttpGet("GetImage/{fileName}")]
		public async Task<IActionResult> GetImage([FromRoute] string fileName)
		{
			try
			{
				var result = await _fruitService.GetImage(fileName);
				if (!result.IsSuccess)
				{
					return StatusCode(result.StatusCode, result);
				}

				return File(result.Image, "image/jpeg");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
			}
		}
	}
}
