using Assignment.DAL.Contexts;
using Assignment.DTO.Entities;
using Assignment.DTO.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly AssignmentContext _context;
		public UserRepository(AssignmentContext context)
		{
			_context = context;
		}

		public int AddPersonUser(PersonUserEntity entity)
		{
			var transaction = _context.Database.BeginTransaction();

			try
			{
				var person = new PersonUserEntity()
				{
					CardID = entity.CardID,
					DateOfBirth = entity.DateOfBirth,
					Name = entity.Name,
					Surname = entity.Surname,
					CompanyId = entity.CompanyId,
					CompanyName = entity.CompanyName,
					Email = entity.Email,
					Address = entity.Address,
					Telephone = entity.Telephone
				};
				_context.Add(person);
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

		public int AddCompanyUser(CompanyUserEntity entity)
		{
			var transaction = _context.Database.BeginTransaction();

			try
			{
				var company = new CompanyUserEntity()
				{
					TaxID = entity.TaxID,
					CompanyName = entity.CompanyName,
					Email = entity.Email,
					Address = entity.Address,
					Telephone = entity.Telephone
				};

				_context.Add(company);
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

		public List<PersonUserEntity> ListAllPersonUser()
		{
			return _context.PersonUser.ToList();
		}

		public List<CompanyUserEntity> ListAllCompanyUser()
		{
			return _context.CompanyUser.ToList();
		}

		public CompanyUserEntity GetCompanyUserById(int id) => _context.CompanyUser.Where(s => s.Id == id).FirstOrDefault();
	}
}
