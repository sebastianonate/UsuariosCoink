using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Domain.Base;

namespace UsuariosCoink.Core.Domain
{
    public class Municipio : BaseEntity
    {
        public Municipio()
        {

        }
        public Municipio(string nombre, int departamentoId)
        {
            Nombre = nombre;
            DepartamentoId = departamentoId;
        }

        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
