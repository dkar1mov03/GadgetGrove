using System.Net.Http;
using Microsoft.AspNetCore.Http;
namespace GadgetGrove.Shared.Helpers;

public class HttpContextHelper
{
    private static long _tempUserId;
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static string UserRole => HttpContext?.User?.FindFirst("role")?.Value;
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
    public static long? UserId => long.TryParse(HttpContext?.User?.FindFirst("id")?.Value, out _tempUserId) ? _tempUserId : null;

}