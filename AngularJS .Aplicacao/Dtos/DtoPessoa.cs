using System.ComponentModel.DataAnnotations;

namespace Dtos
{
    public class DtoPessoa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Sexo { get; set; }
    }
}