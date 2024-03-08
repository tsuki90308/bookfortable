using bookfortable.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
namespace Bookfortable.Models.CLoginDictionary
{
    public class CLoginDictionary
    {
        public static readonly string SK_LOGINGED_USER = "SK_LOGINGED_USER";
        public static readonly string SK_PREVIUS_ACTION = "SK_PREVIUS_ACTION";
        public static readonly string SK_PREVIUS_CONTROLLER = "SK_PREVIUS_CONTROLLER";

        public static Member mDeseliaze(string json)
        {
            try
            {
                Member mbr = JsonSerializer.Deserialize<Member>(json);
                return mbr;
            }catch (Exception ex) { return null; }
        }

        public static string getJson(string key, HttpContext httpContext)
        {
            try
            {
                string json = httpContext.Session.GetString(SK_LOGINGED_USER);
                return json;
            }
            catch(Exception ex) { return null; }
        }

        public static void recNow(ViewContext view, HttpContext httpContext)
        {
            httpContext.Session.SetString(CLoginDictionary.SK_PREVIUS_ACTION, view.RouteData.Values["action"] as string);
            httpContext.Session.SetString(CLoginDictionary.SK_PREVIUS_CONTROLLER, view.RouteData.Values["controller"] as string);
        }
    }
}
