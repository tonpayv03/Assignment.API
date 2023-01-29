using Assignment.DTO.Entities;
using Assignment.DTO.Models.User.AddCompanyUser;
using Assignment.DTO.Models.User.AddPersonUser;
using Assignment.DTO.Models.User.ListCompanyUsers;
using Assignment.DTO.Models.User.ListPersonUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DTO.Interfaces.IServices
{
	public interface IUserService
	{
		Task<AddPersonUserResponse> AddPersonUser(AddPersonUserRequest request);

		Task<AddCompanyUserResponse> AddCompanyUser(AddCompanyUserRequest request);

		Task<ListPersonUsersResponse> ListAllPersonUser();

		Task<ListCompanyUserResponse> ListAllCompanyUser();

		Task<ListPersonUsersResponse> ListPersonUsers(ListPersonUsersRequest request);

		Task<ListCompanyUserResponse> ListCompanyUsers(ListCompanyUsersRequest request);
	}
}
