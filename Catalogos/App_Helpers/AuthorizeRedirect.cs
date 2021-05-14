using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Catalogos.App_Helpers
{
    public class AuthorizeRedirect : AuthorizeAttribute
    {
        /// <summary>
        /// Class AuthorizeRedirect.
        /// </summary>
        /// <seealso cref="System.Web.Mvc.AuthorizeAttribute" />
        //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var urlHelper = new UrlHelper(filterContext.RequestContext);
            var returnUrl = filterContext.HttpContext.Request.UrlReferrer?.LocalPath;
            var ingreso = urlHelper.Action("Index", "Home", new { returnUrl });
            // agregar controller y view 
            var noAutorizado = urlHelper.Action("Forbidden", "Welcome");


            var ctx = filterContext.RequestContext.HttpContext.GetOwinContext();
            ClaimsPrincipal user = ctx.Authentication.User;
            IEnumerable<Claim> claims = user.Claims;
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                if (!filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    var jsonResult = new JsonResult();
                    //jsonResult.Data = new AjaxResponse { Success = false, Message = "Su sesión ha expirado, favor de refrescar la página", Data = new { Refresh = true } };
                    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = jsonResult;
                }
            }
            else
            {
                filterContext.Result = !filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated
                ? new RedirectResult(ingreso)
                : new RedirectResult(noAutorizado);
            }
        }
    }
}