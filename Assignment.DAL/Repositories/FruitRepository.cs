using Assignment.DAL.Contexts;
using Assignment.DTO.Entities;
using Assignment.DTO.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Repositories
{
	public class FruitRepository : IFruitResopository
	{
		private readonly AssignmentContext _context;
		public FruitRepository(AssignmentContext context)
		{
			_context = context;
		}

		public int AddFruit(FruitEntity entity)
		{
			var transaction = _context.Database.BeginTransaction();

			try
			{
				var fruit = new FruitEntity()
				{
					Name = entity.Name,
					FileName = entity.FileName,
				};
				_context.Add(fruit);
				if (_context.SaveChanges() == 0)
					return 0;

				return 1;

			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw ex;
			}
			finally
			{
				transaction.Commit();
			}
		}

		public List<FruitEntity> ListAllFruit() => _context.Fruit.ToList();
	}
}
