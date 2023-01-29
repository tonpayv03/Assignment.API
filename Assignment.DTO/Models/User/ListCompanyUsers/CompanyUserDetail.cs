﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.User.ListCompanyUsers
{
	public class CompanyUserDetail
	{
		public int Id { get; set; }

		public string TaxID { get; set; }

		public string CompanyName { get; set; }

		public string Email { get; set; }

		public string Address { get; set; }

		public string Telephone { get; set; }
	}
}
