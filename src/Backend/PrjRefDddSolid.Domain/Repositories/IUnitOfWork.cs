namespace PrjRefDddSolid.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
