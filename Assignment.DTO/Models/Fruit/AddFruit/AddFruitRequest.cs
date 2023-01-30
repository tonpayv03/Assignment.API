using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Models.Fruit.AddFruit
{
    public class AddFruitRequest : BaseRequest
	{
        [Required(ErrorMessage = "Please input Name")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Please input ImageFile")]
		public IFormFile ImageFile { get; set; }
    }
}
