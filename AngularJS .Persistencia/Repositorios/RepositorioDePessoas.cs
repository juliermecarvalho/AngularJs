using Entidades;
using Lib;
using Repositorios.Base;

namespace Repositorios
{
    public class RepositorioDePessoas :  Repositorio<Pessoa>, IRepositorioDePessoas
    {
        public RepositorioDePessoas(IUnidadeDeTrabalho unidadeDeTrabalho):base(unidadeDeTrabalho)
        {

        }
    }
}
