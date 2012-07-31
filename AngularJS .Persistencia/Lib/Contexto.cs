using System.Data.Entity;
using Entidades;
using Mapeamentos;

namespace Lib
{
    public class Contexto : DbContext
    {
        

        public DbSet<Pessoa> Pessoas { get; set; } 

        public Contexto()
            : base("name=AngularJs")
        {
            
        }

      

        /// <summary>
        /// Metódos sé para os testes
        /// </summary>
        internal void CriarBanco()
        {
            this.Database.CreateIfNotExists();
        }
        /// <summary>
        /// Metódos sé para os testes
        /// </summary>
        internal void ExcluirBanco()
        {
            this.Database.Delete();         
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapPessoa());
        }

        
       
    }
}
