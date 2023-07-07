using AsbtCore.UtilsV2;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace YandexDeliveryAPI.Services.Services
{
    public interface IHttpContextAccessorExtensions
    {
        public bool IsRoleAdmin();
        public int GetId();
        public int GetUserType();
        public string GetUserFullName();
        public string GetUserPhone();
        public string GetUserIp();
    }

    public sealed class HttpContextAccessorExtensions : IHttpContextAccessorExtensions
    {
        private readonly IHttpContextAccessor accessor;

        public HttpContextAccessorExtensions(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public bool IsRoleAdmin()
        {
            var role = accessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            return role == "1";
        }

        public int GetId()
        {
            return accessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid).ToInt();
        }

        public int GetUserType()
        {
            return accessor.HttpContext.User.FindFirstValue(ClaimTypes.Role).ToInt();
        }

        public string GetUserFullName()
        {
            return accessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        public string GetUserPhone()
        {
            var role = accessor.HttpContext.User.FindFirst(ClaimTypes.MobilePhone);
            return role.Value;
        }

        public string GetUserIp()
        {
            return accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}
