using System.Collections.Generic;
using ContextoPessoa.Base;
using Dtos;
using NUnit.Framework;
using Rhino.Mocks;

namespace Controllers.Teste
{
    [TestFixture]
    public class PessoaControllerTeste
    {
        
        // GET api/pessoa
        [Test]
        public void Get_teste()
        {
            //Arange
            var mock = new MockRepository();
            var aplicacao = mock.StrictMock<IPessoaAplicacao>();
            IEnumerable<DtoPessoa> pessoas = new List<DtoPessoa> { new DtoPessoa() };
            PessoaController pessoaController = new PessoaController(aplicacao);
            Expect.Call(aplicacao.ListaDt0Pessoas()).Return(pessoas);
            mock.ReplayAll();

            //Act
            var retorno = pessoaController.Get();

            //Assert
            Assert.IsNotNull(retorno);
            Assert.AreSame(retorno, pessoas);
            CollectionAssert.AreEqual(retorno, pessoas);       
            mock.VerifyAll();
        }

        // GET api/pessoa/5
        [Test]
        public void Get_id_teste()
        {
            //Arange
            var mock = new MockRepository();
            var aplicacao = mock.StrictMock<IPessoaAplicacao>();
            const int id = 1;
            var pessoa = new DtoPessoa() { Id = id };
            PessoaController pessoaController = new PessoaController(aplicacao);
            Expect.Call(aplicacao.DtoPessoa(id)).Return(pessoa);
            mock.ReplayAll();

            //Act
            var retorno = pessoaController.Get(id);

            //Assert
            Assert.IsNotNull(retorno);
            Assert.AreSame(retorno, pessoa);
            mock.VerifyAll();
            
        }

        // POST api/pessoa
        [Test]
        public void Post_teste()
        {
            //Arange
            var mock = new MockRepository();
            var aplicacao = mock.StrictMock<IPessoaAplicacao>();
            const int id = 1;
            var pessoa = new DtoPessoa() { Id = id };
            PessoaController pessoaController = new PessoaController(aplicacao);
            Expect.Call(() => aplicacao.Salvar(pessoa));
            mock.ReplayAll();

            //Act
            var retorno = pessoaController.Post(pessoa);

            //Assert
            Assert.AreEqual("Created", retorno.ReasonPhrase);
            Assert.IsTrue(retorno.IsSuccessStatusCode);
            mock.VerifyAll();
        }

        //// PUT api/pessoa/5
        //[Test]
        //public void Put_teste()
        //{
        //    //Arange
        //    var mock = new MockRepository();
        //    var aplicacao = mock.StrictMock<IPessoaAplicacao>();
        //    const int id = 1;
        //    var pessoa = new DtoPessoa() { Id = id };
        //    PessoaController pessoaController = new PessoaController(aplicacao);
        //    Expect.Call(() => aplicacao.Salvar(pessoa));
        //    mock.ReplayAll();

        //    //Act
        //    pessoaController.Put(pessoa);

        //    //Assert
        //    mock.VerifyAll();
        //}

        // DELETE api/pessoa/5
        [Test]
        public void Delete_teste()
        {
            //Arange
            var mock = new MockRepository();
            var aplicacao = mock.StrictMock<IPessoaAplicacao>();
            const int id = 1;
            
            PessoaController pessoaController = new PessoaController(aplicacao);
            Expect.Call(() => aplicacao.Deletar(id));
            mock.ReplayAll();

            //Act
            pessoaController.Delete(id);

            //Assert
            mock.VerifyAll();
        }
    }
}
