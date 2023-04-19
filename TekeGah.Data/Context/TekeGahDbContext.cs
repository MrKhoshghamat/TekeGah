using Microsoft.EntityFrameworkCore;
using TekeGah.Domain.Entities.Account;

namespace TekeGah.Data.Context;

public class TekeGahDbContext : DbContext
{
    public TekeGahDbContext(DbContextOptions<TekeGahDbContext> options) : base(options)
    {
        
    }

    public DbSet<User>? Users { get; set; }
}