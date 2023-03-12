using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicioWCF;
using Datos;
using System.Data;
using Prueba.Modelos;
using Datos.DTOS;

namespace Prueba.Controllers
{
    public class UsuarioControlador : Controller
    {
        private readonly UsuarioServicio _usuarioServicio;

        public UsuarioControlador(UsuarioServicio servicio)
        {
            _usuarioServicio = servicio;
        }

        
        public IActionResult AgregarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo)
        {
             _usuarioServicio.AgregarUsuario(identificacion, nombre, fechaNacimiento, sexo);
            return View();
        }

        public IActionResult ConsultarUsuarios()
        {
            DataTable usuarios = _usuarioServicio.ConsultarUsuarios();
            UsuariosVistaModelo vistaModelo = new UsuariosVistaModelo()
            {
                Usuarios = usuarios
            };

            return View(vistaModelo);
        }

 
        public IActionResult EliminarUsuario(string id)
        {
             _usuarioServicio.EliminarUsuario(id);
            return RedirectToAction("ConsultarUsuarios");
        }

        public IActionResult EditarUsuario(string id)
        {
            var usuario = _usuarioServicio.ObtenerUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            // Crear un modelo de vista con los datos del usuario
            var modelo = new UsuarioDTO
            {
                Identificacion = usuario.Identificacion,
                Nombre = usuario.Nombre,
                FechaNacimiento = usuario.FechaNacimiento,
                Sexo = usuario.Sexo
            };
            return View("ModificarUsuario", modelo);
        }

        public ActionResult ActualizarUsuario(string identificacion, string nombre, DateTime fechaNacimiento, char sexo)
        {
            try
            {
                // Actualizar usuario en base de datos
                _usuarioServicio.ModificarUsuario(identificacion, nombre, fechaNacimiento, sexo);

                return RedirectToAction("ConsultarUsuarios");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al actualizar usuario: " + ex.Message;
                return View("EditarUsuario");
            }
        }
    }
}
