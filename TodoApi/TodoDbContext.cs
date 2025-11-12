using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos => Set<Todo>();

        // Sobrescrever
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=c:\\caixa\\caixa.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
