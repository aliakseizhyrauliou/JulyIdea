using JulyIdea.Services.IdeasAPI.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JulyIdea.Services.IdeasAPI.AuthAttributes
{
    public class IdeaOwnerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long ideaId;
            var ideasRepository =
                context.HttpContext.RequestServices.GetService(typeof(IIdeasRepository)) as IdeasRepository;
            var parceResult = long.TryParse(context.HttpContext.Request.Query["ideaid"], out ideaId);
            var idea = ideasRepository.GetById(ideaId).Result;

            var userId = int.Parse(context.HttpContext.User.Claims.SingleOrDefault(u => u.Type == "Id").Value);

            if (idea.UserId != userId)
            {
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
