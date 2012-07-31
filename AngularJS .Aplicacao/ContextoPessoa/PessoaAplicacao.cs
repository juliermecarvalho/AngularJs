using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoPessoa.Base;
using Dtos;
using Entidades;
using Enumerados;
using Lib;
using Repositorios;

namespace ContextoPessoa
{
   

    public class PessoaAplicacao : IPessoaAplicacao
    {
        private readonly IRepositorioDePessoas _repositorioDePessoas;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public PessoaAplicacao()
        {
            _unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>();
            _repositorioDePessoas = Fabrica.Instancia.Obter<IRepositorioDePessoas>(_unidadeDeTrabalho);
        }

        public PessoaAplicacao(IRepositorioDePessoas repositorioDePessoas, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _repositorioDePessoas = repositorioDePessoas;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public virtual IEnumerable<DtoPessoa> ListaDt0Pessoas()
        {
            var lista = _repositorioDePessoas.Listar().Select(p => new DtoPessoa
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Sexo = (int) p.Sexo
                });
            

            return lista;
        }

        public virtual DtoPessoa DtoPessoa(int id)
        {
            var pessoa = _repositorioDePessoas.Obter(id);
            var dtoPessoa = new DtoPessoa
                {
                    Id = pessoa.Id, 
                    Nome = pessoa.Nome, 
                    Sexo = (int) pessoa.Sexo
                };
            return dtoPessoa;
        }

        public virtual void Salvar(DtoPessoa dtoPessoa)
        {
            if(dtoPessoa == null)
            {
                throw new Exception("DtoPessoa igual a null");
            }

            var pessoa = new Pessoa
                {
                    Id = dtoPessoa.Id,
                    Nome = dtoPessoa.Nome,
                    Sexo = (Sexo) dtoPessoa.Sexo
                };


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
