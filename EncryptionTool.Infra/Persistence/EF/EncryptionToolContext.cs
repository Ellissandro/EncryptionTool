using EncryptionTool.Domain.Entities;
using EncryptionTool.Domain.ValueObjects;
using EncryptionTool.Infra.Persistence.EF.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionTool.Infra.Persistence.EF
{
    public class EncryptionToolContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EncryptionTool;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Nome>();

            modelBuilder.ApplyConfiguration(new MapUsuario());
            base.OnModelCreating(modelBuilder);
        }
    }
}
