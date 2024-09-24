using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
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
