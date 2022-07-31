using Microsoft.AspNetCore.Http;

namespace HwStore.Application.Core;

public class BasketAccessor
{
    private IHttpContextAccessor _httpContext;
    public BasketAccessor(IHttpContextAccessor contextAccessor)
    {
        _httpContext = contextAccessor;
    }
    public string GetBuyerId()
    {
        var cookieUser = _httpContext.HttpContext.Request.Cookies["buyerId"];

        var userName = _httpContext.HttpContext.User.Identity?.Name;
        var buyerId = userName ?? cookieUser;
        if (buyerId == null)
        {
            _httpContext.HttpContext.Response.Cookies.Delete("buyerId");
            return null;
        }
        return buyerId;
    }
}
