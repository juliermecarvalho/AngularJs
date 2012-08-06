using System.ComponentModel.DataAnnotations;
using Dtos.Base;

namespace Dtos
{
    public class DtoPessoa: IDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Sexo { get; set; }
        public string DescricaoSexo { get; set; }
    }
}