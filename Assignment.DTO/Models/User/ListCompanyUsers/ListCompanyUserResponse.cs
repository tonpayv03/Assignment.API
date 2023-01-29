using Assignment.DTO.Models.User.ListPersonUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.User.ListCompanyUsers
{
	public class ListCompanyUserResponse : BaseResponse
	{
		public List<CompanyUserDetail> Companies { get; set; }

		public int TotalRecord { get; set; }
	}
}
