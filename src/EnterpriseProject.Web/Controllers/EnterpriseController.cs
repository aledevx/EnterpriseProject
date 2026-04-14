using EnterpriseProject.Application.UseCases.Enterprise.GetById;
using EnterpriseProject.Application.UseCases.Enterprise.Register;
using EnterpriseProject.Application.UseCases.Enterprise.Update;
using EnterpriseProject.Application.UseCases.SenhaEnterprise.Gerar;
using EnterpriseProject.Communication.Requests;
using EnterpriseProject.Web.ViewModels.Enterprise;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace EnterpriseProject.Web.Controllers;

public class EnterpriseController : Controller
{
    private readonly IRegisterEnterpriseUseCase _registerUseCase;
    private readonly IUpdateEnterpriseUseCase _updateUseCase;
    private readonly IGetByIdEnterpriseUseCase _getByIdUseCase;

    public EnterpriseController(
        IRegisterEnterpriseUseCase registerUseCase,
        IUpdateEnterpriseUseCase updateUseCase,
        IGetByIdEnterpriseUseCase getByIdUseCase)
    {
        _registerUseCase = registerUseCase;
        _updateUseCase = updateUseCase;
        _getByIdUseCase = getByIdUseCase;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterEnterpriseViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterEnterpriseViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var request = new RequestRegisterEnterprise(viewModel.Name, viewModel.Cnpj);
        
        try
        {
            var response = await _registerUseCase.ExecuteAsync(request);
            return RedirectToAction(nameof(GetById), new { id = response.Id });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(viewModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        try
        {
            var response = await _getByIdUseCase.ExecuteAsync(id);
            var viewModel = new UpdateEnterpriseViewModel
            {
                Id = response.Id,
                Name = response.Name,
                Cnpj = response.Cnpj
            };
            return View(viewModel);
        }
        catch
        {
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateEnterpriseViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var request = new RequestUpdateEnterprise(viewModel.Name, viewModel.Cnpj);

        try
        {
            await _updateUseCase.ExecuteAsync(viewModel.Id, request);
            return RedirectToAction(nameof(GetById), new { id = viewModel.Id });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(viewModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var response = await _getByIdUseCase.ExecuteAsync(id);
            var viewModel = new EnterpriseViewModel
            {
                Id = response.Id,
                Name = response.Name,
                Cnpj = response.Cnpj
            };
            return View(viewModel);
        }
        catch
        {
            return RedirectToAction("Index", "Home");
        }
    }
    [HttpPost]
    public async Task<JsonResult> GerarSenha(int id, [FromServices] IGerarSenhaUseCase useCase)
    {
        var senha = await useCase.ExecuteAsync(id);
        return Json(senha);
    }
}
