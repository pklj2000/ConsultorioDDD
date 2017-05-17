using Consultorio.Service;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Consultorio
{
    public class CustomAuthorize : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            /*Create permission string based on the requested controller 
              name and action name in the format 'controllername-action'*/
            //string requiredPermission = String.Format("{0}-{1}",
            //       filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
            //       filterContext.ActionDescriptor.ActionName);

            /*Create an instance of our custom user authorisation object passing requesting 
              user's 'Windows Username' into constructor*/
            string _transacao;
            string _usuario;

            var filters = new List<FilterAttribute>();
            filters.AddRange(filterContext.ActionDescriptor.GetFilterAttributes(false));
            filters.AddRange(filterContext.ActionDescriptor.ControllerDescriptor.GetFilterAttributes(false));
            if (filters.Count > 0)
                _transacao = ((AuthorizeAttribute)filters[0]).Roles;
            else
                _transacao = "";

            _usuario = filterContext.RequestContext.HttpContext.User.Identity.Name;

            LoginService _service = new LoginService();
            if (!_service.HasPermission(_usuario, _transacao))
            {

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
            /*If the user has the permission to run the controller's action, then 
              filterContext.Result will be uninitialized and executing the controller's 
              action is dependant on whether filterContext.Result is uninitialized.*/
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //if not logged, it will work as normal Authorize and redirect to the Login
                base.HandleUnauthorizedRequest(filterContext);

            }
            else
            {
                //logged and wihout the role to access it - redirect to the custom controller action
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }
        }
    }
}