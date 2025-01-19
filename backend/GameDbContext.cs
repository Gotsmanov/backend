//Класс контекста базы данных
using Microsoft.EntityFrameworkCore;
using backend;

using Microsoft.EntityFrameworkCore;

public class GameDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("DefaultConnection");
        }
    }
}