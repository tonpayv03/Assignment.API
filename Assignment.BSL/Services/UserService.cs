using Assignment.DTO.Entities;
using Assignment.DTO.Interfaces.IRepositories;
using Assignment.DTO.Interfaces.IServices;
using Assignment.DTO.Models.User.AddCompanyUser;
using Assignment.DTO.Models.User.AddPersonUser;
using Assignment.DTO.Models.User.ListCompanyUsers;
using Assignment.DTO.Models.User.ListPersonUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.BSL.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly ILogger _logger;

		public UserService(IUserRepository userRepository, ILogger<UserService> logger)
		{
			_userRepository = userRepository;
			_logger = logger;
		}
		public async Task<AddPersonUserResponse> AddPersonUser(AddPersonUserRequest request)
		{
			var response = new AddPersonUserResponse();
			try
			{

				var company = _userRepository.GetCompanyUserById(request.CompanyId);
				if (company == null)
				{
					response.StatusCode = StatusCodes.Status404NotFound;
					response.ErrorMessage = "Company not found";
					return response;
				}

				var entity = new PersonUserEntity()
				{
					CardID = request.CardID,
					DateOfBirth = request.DateOfBirth,
					Name = request.Name,
					Surname = request.Surname,
					CompanyId = request.CompanyId,
					CompanyName = request.CompanyName,
					Email = request.Email,
					Address = request.Address,
					Telephone = request.Telephone
				};

				var resultInsert = _userRepository.AddPersonUser(entity);
				if (resultInsert == 0)
				{
					response.StatusCode = StatusCodes.Status200OK;
					response.ErrorMessage = "Add person user unsuccess";
					return response;
				}

				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[AddPersonUser]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}

		public async Task<AddCompanyUserResponse> AddCompanyUser(AddCompanyUserRequest request)
		{
			var response = new AddCompanyUserResponse();
			try
			{
				var entity = new CompanyUserEntity()
				{
					TaxID = request.TaxID,
					CompanyName = request.CompanyName,
					Email = request.Email,
					Address = request.Address,
					Telephone = request.Telephone
				};

				var resultInsert = _userRepository.AddCompanyUser(entity);
				if (resultInsert == 0)
				{
					response.StatusCode = StatusCodes.Status200OK;
					response.ErrorMessage = "Add company user unsuccess";
					return response;
				}

				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[AddCompanyUser]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}

		public async Task<ListPersonUsersResponse> ListAllPersonUser()
		{
			var response = new ListPersonUsersResponse()
			{
				Users = new List<PersonUserDetail>()
			};

			try
			{
				var result = _userRepository.ListAllPersonUser();
				if (result is null || result?.Count == 0)
				{
					response.StatusCode = StatusCodes.Status404NotFound;
					response.ErrorMessage = "Data Not found";
					return response;
				}

				foreach (var item in result)
				{
					var model = new PersonUserDetail()
					{
						CardID = item.CardID,
						DateOfBirth = item.DateOfBirth,
						Name = item.Name,
						Surname = item.Surname,
						CompanyName = item.CompanyName,
						Email = item.Email,
						Address = item.Address,
						Telephone = item.Telephone
					};

					response.Users.Add(model);
				}

				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[ListAllPersonUser]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}

		public async Task<ListCompanyUserResponse> ListAllCompanyUser()
		{
			var response = new ListCompanyUserResponse()
			{
				Companies = new List<CompanyUserDetail>()
			};

			try
			{
				var result = _userRepository.ListAllCompanyUser();
				if (result is null || result?.Count == 0)
				{
					response.StatusCode = StatusCodes.Status404NotFound;
					response.ErrorMessage = "Data Not found";
					return response;
				}

				foreach (var item in result)
				{
					var model = new CompanyUserDetail()
					{
						TaxID = item.TaxID,
						CompanyName = item.CompanyName,
						Email = item.Email,
						Address = item.Address,
						Telephone = item.Telephone
					};

					response.Companies.Add(model);
				}

				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[ListAllCompanyUser]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}
	}
}
