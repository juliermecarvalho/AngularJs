using Entidades.Base;
using Enumerados;

namespace Entidades
{
    public class Pessoa: Entidade
    {
        public virtual string Nome { get; set; }
        public virtual Sexo Sexo { get; set; }

    }
}
