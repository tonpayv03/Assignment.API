using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.User.ListCompanyUsers
{
	public class ListCompanyUsersRequest : BaseRequest
	{
		public int Skip { get; set; }

		public int Take { get; set; }

		public string OrderBy { get; set; }

		public string OrderDirection { get; set; }
	}
}
