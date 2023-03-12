using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DTOS;
using Datos.Usuario;

namespace ServicioWCF.Interfaces
{
    interface IUsuario
    {
        void AgregarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo);
        void ModificarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo);
        DataTable ConsultarUsuarios();
        UsuarioDTO ObtenerUsuarioPorId(string identificacion);
        void EliminarUsuario(string identificacionUsuario);
    }
}
