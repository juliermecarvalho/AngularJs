using System;
using System.Collections.Generic;
using System.Linq;
using BindDominoDto;
using ContextoPessoa.Base;
using Dtos;
using Enumerados;
using Lib;
using Repositorios;

namespace ContextoPessoa
{
   

    public class PessoaAplicacao : IPessoaAplicacao
    {
        private readonly IRepositorioDePessoas _repositorioDePessoas;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly PessoaMapper _pessoaMapper;

        public PessoaAplicacao()
        {
            _unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>();
            _repositorioDePessoas = Fabrica.Instancia.Obter<IRepositorioDePessoas>(_unidadeDeTrabalho);
            _pessoaMapper = new PessoaMapper();
        }

        public PessoaAplicacao(IRepositorioDePessoas repositorioDePessoas, IUnidadeDeTrabalho unidadeDeTrabalho, PessoaMapper pessoaMapper)
        {
            _repositorioDePessoas = repositorioDePessoas;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _pessoaMapper = pessoaMapper;
        }

        public virtual IEnumerable<DtoPessoa> ListaDt0Pessoas()
        {
            var lista = _repositorioDePessoas.Listar().Select(p => new DtoPessoa
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Sexo = (int) p.Sexo,
                    DescricaoSexo = p.Sexo == Sexo.Masculino ? "Masculino" : "Feminino"
                }).ToList();
            return lista;
        }

        public virtual DtoPessoa DtoPessoa(int id)
        {
            var pessoa = _repositorioDePessoas.Obter(id);
            var dtoPessoa = _pessoaMapper.Mapeamento(pessoa);
            return dtoPessoa;
        }

        public virtual void Salvar(DtoPessoa dtoPessoa)
        {
            if(dtoPessoa == null)
            {
                throw new Exception("DtoPessoa igual a null");
            }

           
            var pessoa = _pessoaMapper.Mapeamento(dtoPessoa);


            _repositorioDePessoas.Salvar(pessoa);
            _unidadeDeTrabalho.Commit();
        }

        public virtual void Deletar(int id)
        {
            _repositorioDePessoas.Deletar(id);
            _unidadeDeTrabalho.Commit();
        }
    }
}
