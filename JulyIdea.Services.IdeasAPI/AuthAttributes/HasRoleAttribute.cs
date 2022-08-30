using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JulyIdea.Services.IdeasAPI.AuthAttributes
{
    public class HasRoleAttribute : ActionFilterAttribute
    {
        private Roles _roles;

        public HasRoleAttribute(Roles siteRole)
        {
            _roles = siteRole;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var roles = context.HttpContext.User.Claims?.SingleOrDefault(x => x.Type == "Role").Value;
            bool successful = Enum.TryParse(roles, out _roles);
            if (!(successful && _roles.HasFlag(Roles.Admin))) 
            {
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}
