using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UsertEntity> Users { get; set; } 
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<StatusEntity> Status { get; set; }
}
