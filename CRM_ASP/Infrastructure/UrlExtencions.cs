
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace CRM_ASP.Infrastructure
{
    public static class UrlExtencions
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            //var res = request.QueryString.HasValue ? $"~{request.Path}{request.QueryString}" : request.Path.ToString();
            //if (!(request.Form))
            //{              
            //    foreach (var e in request.Form)
            //    {
            //        res += e.Key + '_' + e.Value;
            //    }
            //}
            return request.QueryString.HasValue ? $"~{request.Path}{request.QueryString}" : request.Path.ToString();
        }

    }
}
