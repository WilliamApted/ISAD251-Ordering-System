using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.SharedFunctions
{
    public class CookieManager
    {
        public static void SetCookie(string key, string value, HttpResponse response)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(7);
            response.Cookies.Append(key, value, option);
        }

        public static void RemoveCookie(string key, HttpResponse response)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(-10);
            response.Cookies.Append(key, "", option);
        }
    }
}
