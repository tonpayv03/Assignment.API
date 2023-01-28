using Assignment.DAL.Contexts;
using Assignment.DTO.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Repositories
{
	public class ActionRepository : IActionRepository
	{
		private readonly AssignmentContext _context;
		public ActionRepository(AssignmentContext context)
		{
			_context = context;
		}

		public int Commit()
		{
			try
			{
				return _context.SaveChanges();
			}
			catch (DbUpdateException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
