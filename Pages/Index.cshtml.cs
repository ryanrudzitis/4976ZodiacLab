using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.ObjectPool;
using ZodiacLab.Models;

namespace ZodiacLab.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Console.WriteLine("OnGet");
        ViewData["ErrorMessage"] = "";
    }

    public void OnPost(int year)
    {
        string zodiac = Utils.GetZodiac(year);
        string errorMessage = "";

        if (year < 1900 || year > 2024){
            errorMessage = "Please enter a year between 1900 and 2024";
            ViewData["ErrorMessage"] = errorMessage;
            return;
        }

        ViewData["Zodiac"] = zodiac;
        string ImagePath = "images/" + zodiac.ToLower() + ".png";
        ViewData["ImagePath"] = ImagePath;
        Console.WriteLine(ImagePath);
    }
}
