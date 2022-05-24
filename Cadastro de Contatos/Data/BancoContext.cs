using Cadastro_de_Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_de_Contatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext (DbContextOptions<BancoContext> options ) : base(options)
        {

        }

        public DbSet<Contatomodel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
