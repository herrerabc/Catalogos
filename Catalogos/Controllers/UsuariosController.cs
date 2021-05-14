using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Web;
using System.Web.Mvc;
using Catalogos.App_Helpers;
using Logica.Interfaces;
using Entidades;

namespace Catalogos.Controllers
{
    [AuthorizeRedirect(Roles = "ADMIN")]
    public class UsuariosController : Controller
    {
        ICatalogos _servicioUsurios;
        public UsuariosController([Named("LUsuarios")] ICatalogos usuarios)
        {
            _servicioUsurios = usuarios;
        }
        [AuthorizeRedirect(Roles = "ADMIN")]
        public ActionResult Index()
        {
            return View();
        }    
        [HttpGet]
        public ActionResult getLista()
        {
            ETransactionResult result = new ETransactionResult();
           List<EUsuarios> _usuarios = _servicioUsurios.GetAll(ref result).Cast<EUsuarios>().ToList();

            return Json(_usuarios , JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AddUsuario()
        {
            return PartialView("_Nuevo", new EUsuarios());
        }
        [HttpPost]
        public ActionResult SaveUsuario(EUsuarios model)
        {
            if (!ModelState.IsValid)
            {
                
                return PartialView("_Nuevo", model);
            }

            try
            {
                ETransactionResult result = new ETransactionResult();
                _servicioUsurios.Insert(model, ref result);
                
                if(result.result != 0)
                {
                    ModelState.AddModelError("ERROR", result.message);
                    return PartialView("_Nuevo", model);
                }
            }
            catch (Exception e)
            {                
                ModelState.AddModelError("ERROR", e.Message);
                return PartialView("_Nuevo", model);
            }

            return Json("success",JsonRequestBehavior.DenyGet);
        }
    }
}