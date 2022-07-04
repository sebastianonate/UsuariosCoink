using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Base;

namespace UsuariosCoink.Core.Domain
{
    public class Departamento : BaseEntity
    {
        public Departamento()
        {

        }
        public Departamento(string nombre, int paisId)
        {
            Nombre = nombre;
            PaisId = paisId;
        }

        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
