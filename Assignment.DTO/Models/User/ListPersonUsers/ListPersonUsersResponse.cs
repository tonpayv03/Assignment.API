﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.User.ListPersonUsers
{
	public class ListPersonUsersResponse : BaseResponse
	{
		public List<PersonUserDetail> Persons { get; set; }

		public int TotalRecord { get; set; }
	}
}
