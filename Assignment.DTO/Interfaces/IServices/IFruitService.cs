using Assignment.DTO.Entities;
using Assignment.DTO.Models.Fruit.AddFruit;
using Assignment.DTO.Models.Fruit.GetImage;
using Assignment.DTO.Models.Fruit.ListAllFruit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Interfaces.IServices
{
	public interface IFruitService
	{
		Task<ListAllFruitResponse> ListAllFruit();

		Task<AddFruitResponse> AddFruit(AddFruitRequest request);

		Task<GetImageResponse> GetImage(string fileName);
	}
}
