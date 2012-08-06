using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using Entidades;
using Enumerados;
using NUnit.Framework;

namespace BindDominoDto.Teste
{
    [TestFixture]
    public class PessoaMapperTeste
    {

         [Test]
         public void Bind_de_pessoa_para_dtopessoa()
         {
             Pessoa pessoa = new Pessoa{Id = 10, Nome = "Nome", Sexo = Sexo.Feminino};
             
             PessoaMapper pessoaMapper = new PessoaMapper();
             DtoPessoa dtoPessoa = pessoaMapper.Mapeamento(pessoa);


             Assert.AreEqual(dtoPessoa.Id, pessoa.Id);
             Assert.AreEqual(dtoPessoa.Nome, pessoa.Nome);
             Assert.AreEqual(dtoPessoa.Sexo, (int) pessoa.Sexo);


         }

         [Test]
         public void Bind_de_dtopessoa_para_dtopessoa()
         {
             DtoPessoa dtoPessoa = new DtoPessoa { Id = 10, Nome = "Nome", Sexo = 1 };

             PessoaMapper pessoaMapper = new PessoaMapper();
             Pessoa pessoa = pessoaMapper.Mapeamento(dtoPessoa);


             Assert.AreEqual(pessoa.Id, dtoPessoa.Id);
             Assert.AreEqual(pessoa.Nome, dtoPessoa.Nome);
             Assert.AreEqual((int)pessoa.Sexo, dtoPessoa.Sexo);


         }

    }
}
