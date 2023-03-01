using System.ComponentModel.DataAnnotations;

namespace CatalogoDeProjetos.Models
{
    public class RepositoriosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do repositorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite a linguagem")]
        public string Linguagem { get; set; }
        [Required(ErrorMessage = "Digite o nome do dono do repositorio")]
        public string Dono { get; set; }
        [Required(ErrorMessage = "informe a data da ultima atualização")]
        public DateTime? DataAtualizacao { get; set; }

        public bool Favorito { get; set; }
    }
}
