using Microsoft.AspNetCore.Mvc.Filters;

namespace BookLand.Web.Filters;

public class AjaxOnlyFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        string? value = request.Headers.XRequestedWith;

        bool isAjax = value == "XMLHttpRequest";

        if (!isAjax)
            context.Result = new StatusCodeResult(400);

        base.OnActionExecuting(context);
    }
}
