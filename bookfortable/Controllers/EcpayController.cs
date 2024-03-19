using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bookfortable.ViewModels;
using Bookfortable.Models;
using Bookfortable.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using bookfortable.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Bookfortable.Controllers
{
    [ApiController]
    public class EcpayController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public EcpayController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }


        [HttpPost]
        [Route("api/Ecpay/AddOrders")]
        public string AddOrders(get_localStorage json)
        {
            FinalContext db = new FinalContext();
            EcpayOrders Orders = new EcpayOrders();
            Orders.MemberID = json.MerchantID;
            Orders.MerchantTradeNo = json.MerchantTradeNo;
            Orders.RtnCode = 0; //未付款
            Orders.RtnMsg = "訂單成功尚未付款";
            Orders.TradeNo = json.MerchantID.ToString();
            Orders.TradeAmt = json.TotalAmount;
            Orders.PaymentDate = Convert.ToDateTime(json.MerchantTradeDate);
            Orders.PaymentType = json.PaymentType;
            Orders.PaymentTypeChargeFee = "0";
            Orders.TradeDate = json.MerchantTradeDate;
            Orders.SimulatePaid = 0;
            db.EcpayOrders.Add(Orders);
            db.SaveChanges();
            return "OK";
        }
        // HomeController->Index->PaymentInfoURL所設定的
        [HttpPost]
        [Route("api/Ecpay/AddAccountInfo")]
        public HttpResponseMessage AddAccountInfo(JObject info)
        {
            try
            {
                var cache = _memoryCache;
                cache.Set(info.Value<string>("MerchantTradeNo"), info, DateTime.Now.AddMinutes(60));
                return ResponseOK();
            }
            catch (Exception e)
            {
                return ResponseError();
            }
        }
        private HttpResponseMessage ResponseError()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("0|Error");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
        private HttpResponseMessage ResponseOK()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("1|OK");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
