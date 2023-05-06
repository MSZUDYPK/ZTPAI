namespace CultureSpot.Infrastructure.DAL;

public interface IUnitOfWork
{
    Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> action);
}
