using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Base;

namespace UsuariosCoink.Core.Domain
{
    public class Pais : BaseEntity
    {
        public Pais()
        {
        }
        public Pais(string nombre)
        {
            Nombre = nombre;
        }
        public string Nombre { get; set; }
    }
}
