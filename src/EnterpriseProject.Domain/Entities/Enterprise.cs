namespace EnterpriseProject.Domain.Entities;

public class Enterprise
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; }
    public bool Active { get; set; } = true;
}
