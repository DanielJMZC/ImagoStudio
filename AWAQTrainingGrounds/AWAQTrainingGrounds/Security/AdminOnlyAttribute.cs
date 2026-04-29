using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AdminOnlyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var httpContext = context.HttpContext;

        var isAdmin = httpContext.Session.GetInt32("is_admin");

        if (isAdmin == null || isAdmin != 1)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return;
        }

        base.OnActionExecuting(context);
    }
}