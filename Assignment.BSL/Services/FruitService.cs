using Assignment.DTO.Entities;
using Assignment.DTO.Interfaces.IRepositories;
using Assignment.DTO.Interfaces.IServices;
using Assignment.DTO.Models.Fruit.AddFruit;
using Assignment.DTO.Models.Fruit.GetImage;
using Assignment.DTO.Models.Fruit.ListAllFruit;
using Assignment.DTO.Models.User.ListPersonUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.BSL.Services
{
	public class FruitService : IFruitService
	{
		private readonly IFruitResopository _fruitResopository;
		private readonly ILogger _logger;
		public FruitService(IFruitResopository fruitResopository, ILogger<FruitService> logger)
		{
			_fruitResopository = fruitResopository;
			_logger = logger;
		}

		public async Task<AddFruitResponse> AddFruit(AddFruitRequest request)
		{
			var response = new AddFruitResponse();

			try
			{
				#region Validate
				var maxContentLength = 1024 * 1024 * 3; // Size 3 MB
				var allowedFileExtensions = new List<string>() { ".jpg", ".gif", ".png" };
				if (request.ImageFile.Length == 0)
				{
					response.StatusCode = StatusCodes.Status400BadRequest;
					response.ErrorMessage = "ImageFile is empty";
					return response;
				}

				var fileName = request.Name;
				var file = request.ImageFile;
				var fileNameExtension = file.FileName[file.FileName.LastIndexOf(".")..];

				if (!allowedFileExtensions.Contains(fileNameExtension.ToLower()))
				{
					response.StatusCode = StatusCodes.Status400BadRequest;
					response.ErrorMessage = "Please Upload image of type .jpg, .png";
					return response;
				}
				if (file.Length > maxContentLength)
				{
					response.StatusCode = StatusCodes.Status400BadRequest;
					response.ErrorMessage = "Please Upload a file upto 3 mb.";
					return response;
				}
				#endregion

				string uniqueFileName = $"{DateTime.UtcNow:yyyyMMddHHmmssfff}_{fileName}{fileNameExtension}";
				
				var currentDirectory = $"{Directory.GetCurrentDirectory()}\\Images\\";
				bool exists = Directory.Exists(currentDirectory);
				if (!exists)
				{
					Directory.CreateDirectory(currentDirectory);
				}

				var imagePath = Path.Combine(currentDirectory, uniqueFileName);
				using (FileStream fs = System.IO.File.Create(imagePath))
				{
					await request.ImageFile.CopyToAsync(fs);
				}
				//request.ImageFile.CopyTo(new FileStream(imagePath, FileMode.Create));

				var model = new FruitEntity()
				{
					Name = request.Name,
					FileName = uniqueFileName,
				};
				var resultInsert = _fruitResopository.AddFruit(model);
				if (resultInsert == 0)
				{
					response.StatusCode = StatusCodes.Status200OK;
					response.ErrorMessage = "Add fruit unsuccess";
					return response;
				}

				response.Name = model.Name;
				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[AddFruit]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}

		public async Task<ListAllFruitResponse> ListAllFruit()
		{
			var response = new ListAllFruitResponse()
			{
				Fruits = new List<FruitDetail>()
			};

			try
			{
				var result = _fruitResopository.ListAllFruit();
				if (result is null || result?.Count == 0)
				{
					response.StatusCode = StatusCodes.Status404NotFound;
					response.ErrorMessage = "Data Not found";
					return response;
				}

				foreach (var item in result)
				{
					var model = new FruitDetail()
					{
						Id = item.Id,
						Name = item.Name,
						FileName = item.FileName,
					};

					response.Fruits.Add(model);
				}

				response.IsSuccess = true;
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[ListAllFruit]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}

		public async Task<GetImageResponse> GetImage(string fileName)
		{
			var response = new GetImageResponse();
			try
			{
				if (string.IsNullOrEmpty(fileName))
				{
					response.StatusCode = StatusCodes.Status400BadRequest;
					response.ErrorMessage = "fileName is empty";
					return response;
				}

				var currentDirectory = $"{Directory.GetCurrentDirectory()}\\Images\\";
				var imagePath = Path.Combine(currentDirectory, fileName);

				FileStream file = new FileStream(imagePath, FileMode.Open);

				response.Image = file;
				response.IsSuccess = true;
				return response;
			}
			catch (FileNotFoundException ex)
			{
				response.StatusCode = StatusCodes.Status404NotFound;
				response.ErrorMessage = "Image not found";
				return response;
			}
			catch (Exception ex)
			{
				string message = $"[GetImage]:{DateTime.Now}:::{ex.Message}";
				_logger.LogError(message);
				throw ex;
			}
		}
	}
}
