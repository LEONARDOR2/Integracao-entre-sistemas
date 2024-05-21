using Cronos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cronos.Data
{
    public class BancoContext : DbContext
    {

        

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; } 
    }
}

