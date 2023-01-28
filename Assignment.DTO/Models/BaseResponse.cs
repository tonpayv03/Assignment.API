using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; } = StatusCodes.Status200OK;

		public string ErrorMessage { get; set; } = "Success";
    }
}
