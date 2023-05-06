using CultureSpot.Infrastructure.DAL.Context;

namespace CultureSpot.Infrastructure.DAL;

internal sealed class PostgresUnitOfWork : IUnitOfWork
{
    private readonly CultureSpotDbContext _dbContext;

    public PostgresUnitOfWork(CultureSpotDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        TResult result;

        try
        {
            result = await action();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }

        return result;
    }
}


