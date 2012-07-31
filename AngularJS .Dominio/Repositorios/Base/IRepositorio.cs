using System.Linq;
using Entidades.Base;

namespace Repositorios.Base
{
    public interface IRepositorio<TEntidade>  where TEntidade   : IEntidade
    {
        TEntidade Obter(int id);
        void Salvar(TEntidade entidade);
        void Deletar(TEntidade entidade);
        void Deletar(int id);
        IQueryable<TEntidade> Listar();

    }
}
