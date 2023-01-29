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

				var person = _userRepository.GetPersonUserByCardID(request.CardID);
				if(person != null)
				{
					response.StatusCode = StatusCodes.Status400BadRequest;
					response.ErrorMessage = "Card ID is already exist";
					return response;
				}

				var entity = new PersonUserEntity()
				{
					CardID = request.CardID,
					DateOfBirth = request.DateOfBirth,
					Name = request.Name,
					Surname = request.Surname,
					CompanyId = request.CompanyId,
					CompanyName = company.CompanyName,
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
				var company = _userRepository.GetCompanyUserByTaxID(request.TaxID);
				if (company != null)
				{
					response.StatusCode = StatusCodes.Status400BadRequest;
					response.ErrorMessage = "Tax ID is already exist";
					return response;
				}

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
				Persons = new List<PersonUserDetail>()
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

				int countRecord = 0;
				foreach (var item in result)
				{
					var model = new PersonUserDetail()
					{
						Id = item.Id,
						CardID = item.CardID,
						DateOfBirth = item.DateOfBirth.Date.ToString(),
						Name = item.Name,
						Surname = item.Surname,
						CompanyName = item.CompanyName,
						Email = item.Email,
						Address = item.Address,
						Telephone = item.Telephone
					};

					response.Persons.Add(model);
					countRecord += 1;
				}

				response.TotalRecord = countRecord;
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

				int countRecord = 0;
				foreach (var item in result)
				{
					var model = new CompanyUserDetail()
					{
						Id = item.Id,
						TaxID = item.TaxID,
						CompanyName = item.CompanyName,
						Email = item.Email,
						Address = item.Address,
						Telephone = item.Telephone
					};

					response.Companies.Add(model);
					countRecord += 1;
				}

				response.TotalRecord = countRecord;
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

		public async Task<ListPersonUsersResponse> ListPersonUsers(ListPersonUsersRequest request)
		{
			var response = new ListPersonUsersResponse()
			{
				Persons = new List<PersonUserDetail>()
			};

			try
			{
				var result = _userRepository.ListPersonUser(request.Skip, request.Take, request.OrderBy, request.OrderDirection);
				var total = _userRepository.ListAllPersonUser()?.Count;
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
						Id = item.Id,
						CardID = item.CardID,
						DateOfBirth = item.DateOfBirth.Date.ToString("yyyy-MM-dd"),
						Name = item.Name,
						Surname = item.Surname,
						CompanyName = item.CompanyName,
						Email = item.Email,
						Address = item.Address,
						Telephone = item.Telephone
					};

					response.Persons.Add(model);
				}

				response.TotalRecord = total ?? 0;
				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[ListPersonUsers]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}

		public async Task<ListCompanyUserResponse> ListCompanyUsers(ListCompanyUsersRequest request)
		{
			var response = new ListCompanyUserResponse()
			{
				Companies = new List<CompanyUserDetail>()
			};

			try
			{
				var result = _userRepository.ListCompanyUser(request.Skip, request.Take, request.OrderBy, request.OrderDirection);
				var total = _userRepository.ListAllCompanyUser()?.Count;
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
						Id = item.Id,
						TaxID = item.TaxID,
						CompanyName = item.CompanyName,
						Email = item.Email,
						Address = item.Address,
						Telephone = item.Telephone
					};

					response.Companies.Add(model);
				}

				response.TotalRecord = total ?? 0;
				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[ListCompanyUsers]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}
	}
}
