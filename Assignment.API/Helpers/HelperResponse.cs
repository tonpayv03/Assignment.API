using Assignment.DTO.Models;

namespace Assignment.API
{
	public static class Helpers
	{
		public static BaseResponse InternalServerErrorResponse()
		{
			return new BaseResponse { ErrorMessage = "Internal Server Error" };
		}
	}
}
