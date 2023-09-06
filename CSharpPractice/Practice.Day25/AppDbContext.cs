using Microsoft.EntityFrameworkCore;
using Npgsql;
using Practice.Day25.Entities;
using Practice.Day25.Enums;

namespace Practice.Day25;

class AppDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=sirius.chq1l0z6tcia.eu-central-1.rds.amazonaws.com;" +
            "Port=5432;Database=rental;Username=lapochkin;Password=lapochka")
            .UseSnakeCaseNamingConvention();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<ItemStatus>();
    }
}
