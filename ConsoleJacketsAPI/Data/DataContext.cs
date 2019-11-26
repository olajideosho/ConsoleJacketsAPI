using System;
using System.Collections.Generic;
using System.Text;
using ConsoleJacketsAPI.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConsoleJacketsAPI.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Jacket> Jackets { get; set; }
    }
}
