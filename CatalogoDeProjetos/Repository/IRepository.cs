using CatalogoDeProjetos.Models;

namespace CatalogoDeProjetos.Repository
{
    public interface IRepository
    {
        RepositoriosModel ListarPorId(int id);
        List<RepositoriosModel> BuscarTodos();
        RepositoriosModel Adicionar(RepositoriosModel repositorio);
        RepositoriosModel Atualizar(RepositoriosModel repositorio);

        bool Apagar(int id);

        void ApagarTodos();
        void ExcluirTodos();
    }
}
