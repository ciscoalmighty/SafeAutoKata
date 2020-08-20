using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FileUpload.Models;

namespace FileUpload.Controllers
{
	public class FileUploadController : Controller
    {
		[HttpPost("FileUpload")]
		public async Task<IActionResult> Index(List<IFormFile> files)
		{
			List<IFormFile> result = new List<IFormFile>();
			result = files;
            const string txt = ".txt";
			long size = files.Sum(f => f.Length);

			var filePaths = new List<string>();
			foreach (var formFile in files)
			{

				if (formFile.Length > 0 && formFile.FileName.Contains(txt))
				{
					// full path to file in temp location
					var filePath = Path.GetTempFileName();
					filePaths.Add(filePath);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await formFile.CopyToAsync(stream);
					}
				}
				else
                {
					return RedirectToAction("Failure");

				}
			}

			// process uploaded files
			// Don't rely on or trust the FileName property without validation.
			//return Ok(new { count = files.Count, size, filePaths });
			return RedirectToAction("Success", new { count = files.Count, size, filePaths });
		}

        public IActionResult Success(string filePaths)
        {
			FilesReader.ReadFile(filePaths);
			List<Driver> result = TripWork.SortList(Program.DriverLog);
			return View(result);
        }
		public ActionResult Failure()
        {
            return View();
        }

    }
}