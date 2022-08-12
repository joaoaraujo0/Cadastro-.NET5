using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using NovoProjeto.Data.Map;
using NovoProjeto.Models;

namespace ControleDeContatos.Data {
    public class BancoContext : DbContext {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}