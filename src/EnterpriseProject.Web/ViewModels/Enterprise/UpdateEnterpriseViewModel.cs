using System.ComponentModel.DataAnnotations;

namespace EnterpriseProject.Web.ViewModels.Enterprise;

public class UpdateEnterpriseViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [Display(Name = "Nome da Empresa")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CNPJ é obrigatório.")]
    [Display(Name = "CNPJ")]
    public string Cnpj { get; set; } = string.Empty;
}
