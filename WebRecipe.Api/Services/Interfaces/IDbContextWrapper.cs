using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace WebRecipe.Api.Services.Interfaces;

public interface IDbContextWrapper<T>
     where T : DbContext
{
    T DbContext { get; }
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}
