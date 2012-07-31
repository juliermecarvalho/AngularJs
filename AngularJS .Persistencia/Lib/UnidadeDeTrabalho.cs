namespace Lib
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        public Contexto Contexto { get; set; }

        public UnidadeDeTrabalho()
        {
            Contexto = new Contexto();
        }

       
        /// <summary>
        /// Metódos só usado para os testes
        /// </summary>
        internal virtual void CriarBanco()
        {
            this.Contexto.CriarBanco();
        }

        /// <summary>
        /// Metódos só usado para os testes
        /// </summary>
        internal virtual void ExcluirBanco()
        {
            this.Contexto.ExcluirBanco();
        }

        public virtual void Commit()
        {
            this.Contexto.SaveChanges();
        }

        public void Dispose()
        {
            this.Contexto.Dispose();
            this.Contexto = null;            
        }
    }
}
