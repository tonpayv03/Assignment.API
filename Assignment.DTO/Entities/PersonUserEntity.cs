using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Entities
{
	public class PersonUserEntity : BaseEntity
	{
		public string CardID { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string CompanyName { get; set; }

		public int CompanyId { get; set; }
		public CompanyUserEntity Company { get; set; }

		public string Email { get; set; }

		public string Address { get; set; }

		public string Telephone { get; set; }

	}
}
