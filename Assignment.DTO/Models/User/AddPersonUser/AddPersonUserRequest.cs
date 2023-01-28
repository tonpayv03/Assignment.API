using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.User.AddPersonUser
{
    public class AddPersonUserRequest : BaseRequest
	{
		[Required(ErrorMessage = "Please input Card ID")]
		public string CardID { get; set; }

		[Required(ErrorMessage = "Please input Date of birth")]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Please input Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please input Surname")]
		public string Surname { get; set; }

        public int CompanyId { get; set; }

		[Required(ErrorMessage = "Please select Company Name")]
		public string CompanyName { get; set; }

		[Required(ErrorMessage = "Please input Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please input Address")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please input Telephone")]
		public string Telephone { get; set; }

    }
}
