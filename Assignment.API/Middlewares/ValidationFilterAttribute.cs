using Assignment.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Principal;

namespace Assignment.API.Middlewares
{
	public class ValidationFilterAttribute : IActionFilter
	{
		public void OnActionExecuting(ActionExecutingContext context)
		{
			var param = context.ActionArguments.SingleOrDefault(p => p.Value is BaseRequest);
			if (param.Value == null && context.HttpContext.Request.Method != "GET")
			{
				context.Result = new BadRequestObjectResult("The object do not extends BaseRequest");
				return;
			}

			if (!context.ModelState.IsValid)
			{
				var errors = new List<string>();

				foreach (var modelState in context.ModelState.Values)
				{
					foreach (var error in modelState.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}

				var responseObj = new BaseResponse
				{
					IsSuccess = false,
					ErrorMessage = string.Join(", ", errors)
				};

				context.Result = new JsonResult(responseObj)
				{
					StatusCode = 400
				};
			}
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{

		}
	}
}
