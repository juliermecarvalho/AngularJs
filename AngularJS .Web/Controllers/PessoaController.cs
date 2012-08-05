using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContextoPessoa;
using ContextoPessoa.Base;
using Dtos;
using Entidades;
using Repositorios;

namespace Controllers
{
    public class PessoaController : ApiController
    {
        private readonly IPessoaAplicacao _pessoaAplicacao;
        public PessoaController()
        {
            _pessoaAplicacao = new PessoaAplicacao();
        }
        public PessoaController(IPessoaAplicacao pessoaAplicacao)
        {
            _pessoaAplicacao = pessoaAplicacao;
        }

        // GET api/pessoa
        public virtual IEnumerable<DtoPessoa> Get()
        {
            return _pessoaAplicacao.ListaDt0Pessoas();
        }

        // GET api/pessoa/5
        public virtual DtoPessoa Get(int id)
        {
            return _pessoaAplicacao.DtoPessoa(id);
        }

        // POST api/pessoa
        public virtual HttpResponseMessage Post(DtoPessoa pessoa)
        {
            _pessoaAplicacao.Salvar(pessoa);
            var response = new HttpResponseMessage(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, "api/pessoa/" + pessoa.Id);
            return response;
        }

       
        // DELETE api/pessoa/5
        public virtual HttpResponseMessage Delete(int id)
        {
            _pessoaAplicacao.Deletar(id);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;

        }
    }
}
