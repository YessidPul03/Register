using Microsoft.AspNetCore.Mvc;
using App_DVP.Models;
using App_DVP.Recursos;
using App_DVP.Servicios.Contrato;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.AccessControl;
using Microsoft.VisualBasic;
using App_Coink.Models;

namespace App_DVP.Controllers
{
    public class Inicio : Controller
    {
        private readonly IUsuarioService _usuarioServicio;

        public Inicio(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(EntidadPersona modelo)
        {
            //modelo.NuevaContrasena = Utilidades.ClaveSegura(modelo.NuevaContrasena);

            EntidadPersona usuarioCreate = await _usuarioServicio.SavePersona(modelo);

            //var resultado = await this.RegistrarUsuario(new EntidadUsuario());
            var paisModelo = new PaisUsuario();
            await RegistrarPaisUsuario(paisModelo);

            if (usuarioCreate.Identificador > 0)
            {
                return RedirectToAction("Registrar", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPaisUsuario(PaisUsuario modelo)
        {
            //modelo.Pass = Utilidades.ClaveSegura(modelo.Pass);

            PaisUsuario usuarioCreate = await _usuarioServicio.SavePaisUsuario(modelo);
            var departamentoModelo = new DepartamentoUsuario();
            await RegistrarDepartamentoUsuario(departamentoModelo);

            if (usuarioCreate.Identificador > 0)
            {
                return RedirectToAction("Registrar", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarDepartamentoUsuario(DepartamentoUsuario modelo)
        {
            //modelo.Pass = Utilidades.ClaveSegura(modelo.Pass);

            DepartamentoUsuario usuarioCreate = await _usuarioServicio.SaveDepartamentoUsuario(modelo);
            var municipioModelo = new MunicipioUsuario();
            await RegistrarMunicipioUsuario(municipioModelo);

            if (usuarioCreate.Identificador > 0)
            {
                return RedirectToAction("Registrar", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarMunicipioUsuario(MunicipioUsuario modelo)
        {
            //modelo.Pass = Utilidades.ClaveSegura(modelo.Pass);

            MunicipioUsuario usuarioCreate = await _usuarioServicio.SaveMunicipioUsuario(modelo);
            /*var usuarioModelo = new Usuario();
            await RegistrarUsuario(usuarioModelo);*/

            if (usuarioCreate.Identificador > 0)
            {
                return RedirectToAction("Registrar", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        /*public IActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InicioSesion(string user, string pass)
        {
            PaisUsuario usuarioFound = await _usuarioServicio.GetUsuario(user, pass);

            if (usuarioFound == null)
            {
                ViewData["Mensaje"] = "No se encontro registros";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioFound.Usuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity),
               properties
            );

            return RedirectToAction("Index", "Home");
        }*/

    }
    
}
