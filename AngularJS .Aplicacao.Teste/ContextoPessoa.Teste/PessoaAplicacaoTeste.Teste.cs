using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoPessoa.Base;
using Dtos;
using Entidades;
using Lib;
using NUnit.Framework;
using Repositorios;
using Rhino.Mocks;

namespace ContextoPessoa.Teste
{
    [TestFixture]
    public class PessoaAplicacaoTeste
    {
        [Test]
        public void listar_pessoa()
        {
            //Arange
            var mock = new MockRepository();
            var repositorio = mock.StrictMock<IRepositorioDePessoas>();
            IPessoaAplicacao pessoaAplicacao = new PessoaAplicacao(repositorio, null);

            IQueryable<Pessoa> lista = new List<Pessoa>().AsQueryable();
            
            Expect.Call(repositorio.Listar()).Return(lista);
            mock.ReplayAll();

            //Act
            var retorno = pessoaAplicacao.ListaDt0Pessoas();

            //Assert
            CollectionAssert.AreEqual(lista, retorno);
            mock.VerifyAll();
        }

        [Test]
        public void pessoa()
        {
            //Arange
            var mock = new MockRepository();
            var repositorio = mock.StrictMock<IRepositorioDePessoas>();
            IPessoaAplicacao pessoaAplicacao = new PessoaAplicacao(repositorio, null);

            const int id = 1;
            var pessoa = new Pessoa {Id = id};
            Expect.Call(repositorio.Obter(id)).Return(pessoa);
            mock.ReplayAll();

            //Act
            var retorno = pessoaAplicacao.DtoPessoa(id);

            //Assert
            Assert.AreEqual(pessoa.Id, retorno.Id);
            mock.VerifyAll();
        }

        [Test]
        public void Salvar()
        {
            //Arange
            var mock = new MockRepository();
            var repositorio = mock.StrictMock<IRepositorioDePessoas>();
            var unidadeDeTrabalho = mock.StrictMock<IUnidadeDeTrabalho>();
            IPessoaAplicacao pessoaAplicacao = new PessoaAplicacao(repositorio, unidadeDeTrabalho);
            var pessoa = new Pessoa();
            var dtoPessoa = new DtoPessoa();
            Expect.Call(unidadeDeTrabalho.Commit);
            Expect.Call(() => repositorio.Salvar(pessoa)).IgnoreArguments();
            mock.ReplayAll();

            //Act
            pessoaAplicacao.Salvar(dtoPessoa);

            //Assert            
            mock.VerifyAll();
        }
        [Test]
        [ExpectedException(typeof(Exception))]
        public void Salvar_recebendo_null()
        {
            //Arange
            var mock = new MockRepository();
            var repositorio = mock.StrictMock<IRepositorioDePessoas>();
            IPessoaAplicacao pessoaAplicacao = new PessoaAplicacao(repositorio, null);
            var pessoa = new Pessoa();
            
            Expect.Call(() => repositorio.Salvar(pessoa));
            mock.ReplayAll();

            //Act
            pessoaAplicacao.Salvar(null);

            //Assert            
            mock.VerifyAll();
        }

        [Test]
        public void Deletar()
        {
            //Arange
            var mock = new MockRepository();
            var repositorio = mock.StrictMock<IRepositorioDePessoas>();
            var unidadeDeTrabalho = mock.StrictMock<IUnidadeDeTrabalho>();
            IPessoaAplicacao pessoaAplicacao = new PessoaAplicacao(repositorio, unidadeDeTrabalho);
            const int id = 1;
            Expect.Call(unidadeDeTrabalho.Commit);           
            Expect.Call(() => repositorio.Deletar(id));
            mock.ReplayAll();

            //Act
            pessoaAplicacao.Deletar(id);

            //Assert

            mock.VerifyAll();
        }


    }
}
