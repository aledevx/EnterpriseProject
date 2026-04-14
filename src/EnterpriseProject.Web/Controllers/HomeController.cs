using EnterpriseProject.Application.UseCases.Enterprise.GetAll;
using EnterpriseProject.Web.Models;
using EnterpriseProject.Web.ViewModels.Enterprise;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnterpriseProject.Web.Controllers;

public class HomeController : Controller
{
    private readonly IGetAllEnterprisesUseCase _getAllUseCase;

    public HomeController(IGetAllEnterprisesUseCase getAllUseCase)
    {
        _getAllUseCase = getAllUseCase;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _getAllUseCase.ExecuteAsync();
        var viewModels = response.Select(e => new EnterpriseViewModel 
        { 
            Id = e.Id, 
            Name = e.Name, 
            Cnpj = e.Cnpj 
        }).ToList();

        return View(viewModels);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
