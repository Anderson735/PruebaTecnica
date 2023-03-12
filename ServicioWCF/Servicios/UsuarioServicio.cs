using Datos.Usuario;
using ServicioWCF.Interfaces;
using System;
using System.Collections.Generic;
using Datos.Procedimientos;
using System.Data;
using Datos.DTOS;

namespace ServicioWCF
{
    public class UsuarioServicio : IUsuario
    {
        public void AgregarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo)
        {
            PUsuario pUsuario = new PUsuario();
            pUsuario.AgregarUsuario(identificacion, nombre, fechaNacimiento, sexo);
            
        }

        public DataTable ConsultarUsuarios()
        {
            PUsuario pUsuario = new PUsuario();
            return pUsuario.ConsultarUsuarios();
        }

        public void EliminarUsuario(string identificacionUsuario)
        {
 
            PUsuario pUsuario = new PUsuario();
            pUsuario.EliminarUsuario(identificacionUsuario);

        }

        public void ModificarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo)
        {
     
            PUsuario pUsuario = new PUsuario();
            pUsuario.ModificarUsuario(identificacion, nombre, fechaNacimiento, sexo);
            
        }

        public UsuarioDTO ObtenerUsuarioPorId(string identificacion)
        {

            PUsuario pUsuario = new PUsuario();
            return pUsuario.ObtenerUsuarioPorId(identificacion);
            
        }
        
    }
}
