using CatalogoDeProjetos.Data;
using CatalogoDeProjetos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeProjetos.Repository
{
    public class Repository : IRepository
    {
        private readonly BancoContext _bancoContext;
        public Repository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public RepositoriosModel Adicionar(RepositoriosModel repositorio)
        {
            _bancoContext.Repositorios.Add(repositorio);
            _bancoContext.SaveChanges();
            return repositorio;
        }

        public bool Apagar(int id)
        {
            RepositoriosModel repositorioDB = ListarPorId(id);

            if (repositorioDB == null) throw new System.Exception("Houve um erro na delição do repositorio");

            _bancoContext.Repositorios.Remove(repositorioDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public void ExcluirTodos()
        {
            _bancoContext.Repositorios.RemoveRange(_bancoContext.Repositorios);
            _bancoContext.SaveChanges();
        }

        public void ApagarTodos()
        {
            _bancoContext.Repositorios.RemoveRange(_bancoContext.Repositorios);
            _bancoContext.SaveChanges();
        }






        public List<RepositoriosModel> BuscarTodos()
        {
            return _bancoContext.Repositorios.ToList();
        }

        public RepositoriosModel ListarPorId(int id)
        {
            return _bancoContext.Repositorios.FirstOrDefault(x => x.Id == id);
        }
        public RepositoriosModel Atualizar(RepositoriosModel repositorio)
        {
            RepositoriosModel repositorioDB = ListarPorId(repositorio.Id);

            if (repositorioDB == null) throw new System.Exception("Houve um erro na atualização do repositorio");

            repositorioDB.Nome = repositorio.Nome;
            repositorioDB.Descricao = repositorio.Descricao;
            repositorioDB.Linguagem = repositorio.Linguagem;
            repositorioDB.DataAtualizacao = repositorio.DataAtualizacao;
            repositorioDB.Dono = repositorio.Dono;

            _bancoContext.Repositorios.Update(repositorioDB);
            _bancoContext.SaveChanges();

            return repositorioDB;
        }
    }
}
