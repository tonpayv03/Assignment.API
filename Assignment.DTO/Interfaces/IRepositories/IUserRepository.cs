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

		List<PersonUserEntity> ListPersonUser(int skip, int take, string orderBy, string orderDirection);

		List<CompanyUserEntity> ListCompanyUser(int skip, int take, string orderBy, string orderDirection);

		PersonUserEntity GetPersonUserByCardID(string cardID);

		CompanyUserEntity GetCompanyUserByTaxID(string taxID);

	}
}
