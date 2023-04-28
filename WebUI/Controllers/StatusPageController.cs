using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.IO;

namespace WebUI.Controllers
{
	[Authorize(Roles = "Admin,Accounting,Cashier,MobileSales,StockRoom,TechnicalService")]

	public class StatusPageController : Controller
	{
		public IActionResult Status(int? code)
		{
			
			return View(); //404 not found
		}

		public IActionResult Error()
		{
			var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

			var logFileName = DateTime.Now.ToString();

			logFileName = logFileName.Replace(" ", "_");
			logFileName = logFileName.Replace(":", "-");
			logFileName = logFileName.Replace("/", "-");
			logFileName += ".txt";

			var logFilePath = Path.Combine(logFolderPath, logFileName);

			DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);

			if (!directoryInfo.Exists )
			{
				directoryInfo.Create();
			}

			FileInfo fileInfo = new FileInfo(logFilePath);
			var writer = fileInfo.CreateText();
			writer.WriteLine("Hatanın gerçekleştiği yer : " + exceptionHandlerPathFeature.Path);
			writer.WriteLine("Hata mesajı : " + exceptionHandlerPathFeature.Error.Message);

			writer.Close();




			return View();
		}
	}
}
