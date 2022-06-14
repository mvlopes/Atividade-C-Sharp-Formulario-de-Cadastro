using Microsoft.EntityFrameworkCore;
namespace CadastroSim.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }

        public DbSet<DbCadastro> cadastro { get; set; }
    }
}
