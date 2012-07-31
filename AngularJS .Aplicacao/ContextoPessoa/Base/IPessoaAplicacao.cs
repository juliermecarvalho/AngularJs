using System.Collections.Generic;
using Dtos;
using Entidades;

namespace ContextoPessoa.Base
{
    public interface IPessoaAplicacao
    {
        IEnumerable<DtoPessoa> ListaDt0Pessoas();
        DtoPessoa DtoPessoa(int id);
        void Salvar(DtoPessoa pessoa);
        void Deletar(int id);
    }
}