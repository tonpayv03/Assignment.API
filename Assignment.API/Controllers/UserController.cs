using Assignment.DTO.Interfaces.IRepositories;
using Assignment.DTO.Interfaces.IServices;
using Assignment.DTO.Models.User.AddCompanyUser;
using Assignment.DTO.Models.User.AddPersonUser;
using Assignment.API.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Assignment.DTO.Models.User.ListPersonUsers;
using Assignment.DTO.Models.User.ListCompanyUsers;

namespace Assignment.API.Controllers
{
	[ServiceFilter(typeof(ValidationFilterAttribute))]
	[Route("api/v1/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("AddPersonUser")]
		public async Task<IActionResult> AddPersonUser([FromBody] AddPersonUserRequest request)
		{
			try
			{
				var result = await _userService.AddPersonUser(request);
				return StatusCode(result.StatusCode, result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, Helpers.InternalServerErrorResponse());
			}
		}

		[HttpPost("AddCompanyUser")]
		public async Task<IActionResult> AddCompanyUser([FromBody] AddCompanyUserRequest request)
		{
			try
			{
				var result = await _userService.AddCompanyUser(request);
				return StatusCode(result.StatusCode, result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, Helpers.InternalServerErrorResponse());
			}
		}

		[HttpGet("ListAllPersonUser")]
		public async Task<IActionResult> ListAllPersonUser()
		{
			try
			{
				var result = await _userService.ListAllPersonUser();
				return StatusCode(result.StatusCode, result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, Helpers.InternalServerErrorResponse());
			}
		}

		[HttpGet("ListAllCompanyUser")]
		public async Task<IActionResult> ListAllCompanyUser()
		{
			try
			{
				var result = await _userService.ListAllCompanyUser();
				return StatusCode(result.StatusCode, result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, Helpers.InternalServerErrorResponse());
			}
		}

		[HttpPost("ListPersonUsers")]
		public async Task<IActionResult> ListPersonUsers(ListPersonUsersRequest request)
		{
			try
			{
				var result = await _userService.ListPersonUsers(request);
				return StatusCode(result.StatusCode, result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, Helpers.InternalServerErrorResponse());
			}
		}

		[HttpPost("ListCompanyUsers")]
		public async Task<IActionResult> ListCompanyUsers(ListCompanyUsersRequest request)
		{
			try
			{
				var result = await _userService.ListCompanyUsers(request);
				return StatusCode(result.StatusCode, result);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, Helpers.InternalServerErrorResponse());
			}
		}
	}
}
