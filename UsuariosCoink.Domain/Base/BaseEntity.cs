using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Contracts;

namespace UsuariosCoink.Core.Domain.Base
{
    public class BaseEntity<TId> : IEntity<TId>, IEntity
    {
        public TId Id { get; protected set; } = default!;
    }
    public class BaseEntity : IEntity<int>, IEntity
    {
        public int Id { get; protected set; } = default!;
    }
}
