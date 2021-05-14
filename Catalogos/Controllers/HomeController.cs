using System;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Logica.Interfaces;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Catalogos.Controllers
{
    public class HomeController : Controller
    {
        ICatalogos _servicioUsuario;
        ICatalogos _servicioUsrRol;
        ICatalogos _servicioUsrRoles;

        public HomeController([Named("LUsuarios")]  ICatalogos iUsuarios, [Named("LUsuarioRoles")]  ICatalogos iUsrRol,
            [Named("LRoles")] ICatalogos iRoles)
        {
            _servicioUsrRol = iUsrRol;
            _servicioUsuario = iUsuarios;
            _servicioUsrRoles = iRoles;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string usr = form.Get("Usuario");
            string pass = form.Get("Password");

            if(string.IsNullOrEmpty(usr) || string.IsNullOrEmpty(pass))
            {
                ModelState.AddModelError("","Usuario ó Contraseña incorrectos.");
                return View("Index");
            }
            ETransactionResult result = new ETransactionResult();
            var _usuario = (EUsuarios)_servicioUsuario.select(new EUsuarios { Loggin = usr }, ref result);

            if(_usuario == null)
            {
                ModelState.AddModelError("", "Usuario ó Contraseña incorrectos.");
                return View("Index");
            }
            if(_usuario.Password != pass)
            {
                ModelState.AddModelError("", "Usuario ó Contraseña incorrectos.");
                return View("Index");
            }
            result = new ETransactionResult();
            
            List<EUsuariosRoles> _roles = _servicioUsrRol.GetAll(ref result).Cast<EUsuariosRoles>().ToList();
            _roles = _roles.Where(x => x.IdUsuario == _usuario.Id).ToList();
            
            if (_roles == null || _roles.Count == 0)
            {
                ModelState.AddModelError("", "No cuenta con roles para acceder a la aplicación.");
                Request.GetOwinContext().Authentication.SignOut();
                return View("Index");
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.UserData, _usuario.Loggin),
                    new Claim(ClaimTypes.Name, _usuario.Nombre +" " +_usuario.ApellidoM + " " + _usuario.ApellidoP ),
                    new Claim(ClaimTypes.Surname, _usuario.ApellidoM + " " + _usuario.ApellidoP),
                     new Claim(ClaimTypes.Email, _usuario.Email == null ?"":_usuario.Email),

                    new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                        _usuario.Loggin),
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        _usuario.Loggin)

                };
                claims.AddRange(_roles.Select(rol => new Claim(ClaimTypes.Role, rol.IdRol)));
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var authenticationProperties = new AuthenticationProperties()
                {                    
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.AddMinutes(30)
                };
                Request.GetOwinContext().Authentication.SignIn(authenticationProperties, identity);
            }

            return RedirectToAction("Index", "Welcome");
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    }
}