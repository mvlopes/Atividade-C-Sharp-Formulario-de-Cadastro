using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace CadastroSim.Models
{
    [Table("cadastro", Schema = "public")]
    public class DbCadastro
    {
        [Key]

        public int id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public DateTime datanascimento { get; set; }
        public string? sexo { get; set; }
        public string? rua { get; set; }
        public string? numero { get; set; }
        public string? cep { get; set; }
        public string? cidade { get; set; }
        public string? estado { get; set; }
        public string? mensagem { get; set; }

    }
}
