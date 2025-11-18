using Microsoft.EntityFrameworkCore;
using Vorlagen.Domain.Entities;

namespace Vorlagen.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
}
