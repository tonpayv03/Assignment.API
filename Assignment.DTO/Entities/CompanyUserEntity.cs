using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DTO.Models;

namespace Assignment.DTO.Entities
{
	public class CompanyUserEntity : BaseEntity
	{
		public string TaxID { get; set; }

		public string CompanyName { get; set; }

		public string Email { get; set; }

		public string Address { get; set; }

		public string Telephone { get; set; }

		public ICollection<PersonUserEntity> Persons { get; set; }

		//public int InformationId { get; set; }
		//public virtual InformationEntity Information { get; set; }
	}
}
