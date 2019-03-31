using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using DreamRF.Data.Entities;

namespace DreamRF.Helpers{
 public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }       

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}