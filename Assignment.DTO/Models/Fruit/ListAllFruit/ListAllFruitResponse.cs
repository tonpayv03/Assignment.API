using Assignment.DTO.Models.User.ListCompanyUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.Fruit.ListAllFruit
{
	public class ListAllFruitResponse : BaseResponse
	{
		public List<FruitDetail> Fruits { get; set; }
	}
}
