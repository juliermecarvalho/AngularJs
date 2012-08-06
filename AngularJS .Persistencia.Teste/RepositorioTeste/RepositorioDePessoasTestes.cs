using System.Collections.Generic;
using System.Linq;
using Entidades;
using Enumerados;
using Lib;
using NUnit.Framework;
using Repositorios;

namespace RepositorioTeste
{
    
    [TestFixture]
    public class RepositorioDePessoasTestes
    {
        
        private int _id;

        /// <summary>
        /// É criado um banco de dados somente para os teste
        /// </summary>
        [SetUp]
        public void Contexto()
        {
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                var deTrabalho = unidadeDeTrabalho as UnidadeDeTrabalho;
                if (deTrabalho != null)
                    deTrabalho.CriarBanco();
            }
        }

        /// <summary>
        /// É excluido o banco de dados de teste
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                var deTrabalho = unidadeDeTrabalho as UnidadeDeTrabalho;
                if (deTrabalho != null)
                    deTrabalho.ExcluirBanco();
            }
        }

        [Test]
        public void Crud_Pessoa()
        {
            this.Salvar_Pessoa();
            this.Listar_Pessoa();
            this.Deletar_Pessoa();
        }
        
        public void Salvar_Pessoa()
        {
            
            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                IRepositorioDePessoas repositorioDePessoas =
                    Fabrica.Instancia.Obter<IRepositorioDePessoas>(unidadeDeTrabalho);

                Pessoa pessoa = new Pessoa { Nome = "Teste", Sexo = Sexo.Masculino };

                repositorioDePessoas.Salvar(pessoa);
                unidadeDeTrabalho.Commit();

                Assert.IsTrue(pessoa.Id > 0);
                this._id = pessoa.Id;
            }
        }

        public void Listar_Pessoa()
        {

            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                IRepositorioDePessoas repositorioDePessoas =
                    Fabrica.Instancia.Obter<IRepositorioDePessoas>(unidadeDeTrabalho);



                IEnumerable<Pessoa> pessoas = repositorioDePessoas.Listar().ToList();



                CollectionAssert.AllItemsAreInstancesOfType(pessoas, typeof(Pessoa));
                Assert.AreEqual(pessoas.Count(), 1);

            }
        }

        public void Deletar_Pessoa()
        {

            using (IUnidadeDeTrabalho unidadeDeTrabalho = Fabrica.Instancia.Obter<IUnidadeDeTrabalho>())
            {
                IRepositorioDePessoas repositorioDePessoas =
                    Fabrica.Instancia.Obter<IRepositorioDePessoas>(unidadeDeTrabalho);

                Pessoa pessoa = repositorioDePessoas.Obter(_id);
                repositorioDePessoas.Deletar(pessoa);
                unidadeDeTrabalho.Commit();
                pessoa = repositorioDePessoas.Obter(_id);
                Assert.IsNull(pessoa);
                
            }
        }

    }
}
