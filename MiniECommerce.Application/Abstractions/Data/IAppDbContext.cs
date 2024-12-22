using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain.Core;

namespace MiniECommerce.Application.Abstractions.Data
{
    public interface IAppDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}
