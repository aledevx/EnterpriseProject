namespace EnterpriseProject.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
