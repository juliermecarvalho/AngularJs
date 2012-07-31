using System.Data.Entity.ModelConfiguration;
using Entidades;

namespace Mapeamentos
{
    class MapPessoa : EntityTypeConfiguration<Pessoa>
    {
        public MapPessoa()
        {
            this.ToTable("Pessoas");
        }
    }
}
