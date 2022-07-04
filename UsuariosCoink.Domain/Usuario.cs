using UsuariosCoink.Core.Domain.Base;

namespace UsuariosCoink.Core.Domain
{
    public class Usuario : BaseEntity
    {
        public Usuario()
        {
        }
        public Usuario(string nombre, string direccion, string telefono, int municipioId)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            MunicipioId = municipioId;
        }

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}