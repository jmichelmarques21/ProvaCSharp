using Microsoft.EntityFrameworkCore;
using ProvaCSharp.models;
using ProvaCSharp.Models;

namespace ProvaCSharp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Cliente> Clientes { get; internal set; }
        public DbSet<Contrato> Contratos { get; internal set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}