using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.Fruit.GetImage
{
	public class GetImageResponse : BaseResponse
	{
		public FileStream Image { get; set; }
	}
}
