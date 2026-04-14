using System.ComponentModel.DataAnnotations;

namespace EnterpriseProject.Web.ViewModels.Enterprise;

public class EnterpriseViewModel
{
    public int Id { get; set; }
    
    [Display(Name = "Nome da Empresa")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "CNPJ")]
    public string Cnpj { get; set; } = string.Empty;
}
