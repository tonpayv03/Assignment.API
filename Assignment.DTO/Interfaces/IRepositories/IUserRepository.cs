using Assignment.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Interfaces.IRepositories
{
	public interface IUserRepository
	{
		int AddPersonUser(PersonUserEntity entity);
		
		int AddCompanyUser(CompanyUserEntity entity);

		List<PersonUserEntity> ListAllPersonUser();

		List<CompanyUserEntity> ListAllCompanyUser();

		CompanyUserEntity GetCompanyUserById(int id);
	}
}
