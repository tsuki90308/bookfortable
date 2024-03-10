using bookfortable.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
namespace Bookfortable.Models.CLoginDictionary
{
    public class CLoginDictionary
    {
        public static readonly string SK_LOGINGED_USER = "SK_LOGINGED_USER";

        //json拆包
        public static Member mDeseliaze(string json)
        {
            try
            {
                Member mbr = JsonSerializer.Deserialize<Member>(json);
                return mbr;
            }catch (Exception ex) { return null; }
        }

        //回傳json
        public static string getJson(string key, HttpContext httpContext)
        {
            try
            {
                string json = httpContext.Session.GetString(SK_LOGINGED_USER);
                return json;
            }
            catch(Exception ex) { return null; }
        }

        //回傳登入與否
        public static bool isLogin(HttpContext httpContext)
        {
            bool isLogin = false;
            string json = getJson(SK_LOGINGED_USER, httpContext);
            if(json != null)
            {
                isLogin = true;
            }
            return isLogin;
        }
    }
}
