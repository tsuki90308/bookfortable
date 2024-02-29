using bookfortable.Models;
using NuGet.Protocol;
using System.ComponentModel;

namespace Bookfortable.ViewModels
{
    public class OrderListViewModel
    {
        public OrderList list { get; set; } = new OrderList();

        //public string strBoolConvert { get; set; }
        //public string IsMember { get; set; }
        //[DisplayName("是否會員")]
        //public string OSisMember
        //{
        //    get
        //    {
        //        return "";
        //    }
        //    set
        //    {
        //        if (list.IsMember.ToString() == "0") { value = "否"; }
        //        else { value = "是"; }
        //    }
        //}
    }
}
