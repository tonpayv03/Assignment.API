using Assignment.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Interfaces.IRepositories
{
	public interface IFruitResopository
	{
		List<FruitEntity> ListAllFruit();

		int AddFruit(FruitEntity entity);
	}
}
