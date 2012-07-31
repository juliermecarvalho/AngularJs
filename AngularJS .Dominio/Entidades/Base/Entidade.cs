using System;

namespace Entidades.Base
{
    [Serializable]
    public class Entidade : IEntidade
    {
        public virtual int Id { get; set; }
    }
}
