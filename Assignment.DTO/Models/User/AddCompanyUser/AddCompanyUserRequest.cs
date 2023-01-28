using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.User.AddCompanyUser
{
    public class AddCompanyUserRequest : BaseRequest
	{
		[Required(ErrorMessage = "Please input Tax ID")]
		public string TaxID { get; set; }

		[Required(ErrorMessage = "Please input Company Name")]
		public string CompanyName { get; set; }

		[Required(ErrorMessage = "Please input Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please input Address")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please input Telephone")]
		public string Telephone { get; set; }


    }
}
