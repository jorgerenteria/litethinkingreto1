using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Context
{
    public class ToDoListContext(IConfiguration configuration) : DbContext
    {
        public string ConnectionString { get; set; } = configuration.GetSection("ConnectionStrings:SQLConnection").Value ?? string.Empty;
        public DbSet<ToDoListEntity> ToDoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
    }
}
