using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace asp_lab7.Controllers;

public class FileController : Controller
{
    public IActionResult DownloadFile(string firstName = "", string secondName = "", string fileName = "")
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName) || string.IsNullOrEmpty(fileName))
        {
            ViewData["WarningMessage"] = "You must enter each field!";
            return View();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"First Name: {firstName}\n");
            sb.Append($"Second Name: {secondName}");
            
            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            FileContentResult result = new FileContentResult(bytes, contentType: @"text/plain");
            result.FileDownloadName = $"{fileName}.txt";
            return result;
        }
    }
}