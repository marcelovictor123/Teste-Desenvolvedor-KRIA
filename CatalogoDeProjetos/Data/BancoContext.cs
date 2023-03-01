using CatalogoDeProjetos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeProjetos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<RepositoriosModel> Repositorios { get; set; }
        public DbSet<FavoriteRepositoryModel> FavoriteRepositories { get; set; }
    }
}
