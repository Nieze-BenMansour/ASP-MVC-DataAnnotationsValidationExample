using Microsoft.AspNetCore.Mvc;
using DataAnnotationsExample.Models;
using DataAnnotationsExample.Validators;

namespace DataAnnotationsExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(
        Person person,
        [FromServices] PersonValidator personValidator)
    {
        //Business validation
        var validationDict = personValidator.Validate(person);

        PopulateModelState(validationDict);

        if (!ModelState.IsValid)
        {
            return View("Index", person);
        }
        return View(person);
    }

    private void PopulateModelState(Dictionary<string, string> validationDict)
    {
        foreach (var validationKeyValue in validationDict)
        {
            ModelState.AddModelError(validationKeyValue.Key, validationKeyValue.Value);
        }
    }
}