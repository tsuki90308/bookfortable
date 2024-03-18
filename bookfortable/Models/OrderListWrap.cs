using System.ComponentModel;

namespace Bookfortable.Models
{
    public class OrderListWrap
    {
        private OrderList _orderlist;
        public OrderList orderlist
        {
            get { return _orderlist; }
            set { _orderlist = value; }
        }
        public OrderListWrap()
        {
            _orderlist = new OrderList();
        }
        public int Oid
        {
            get { return _orderlist.Oid; }
            set { _orderlist.Oid = value; }
        }
        [DisplayName("訂單流水號")]
        public string? Oidramd
        {
            get { return _orderlist.Oidramd; }
            set { _orderlist.Oidramd = value; }
        }
        [DisplayName("訂單詳情id")]
        public int? OrderDetailId
        {
            get { return _orderlist.OrderDetailId; }
            set { _orderlist.OrderDetailId = value; }
        }
        [DisplayName("訂單日期")]
        public DateTime? OrderDate
        {
            get { return _orderlist.OrderDate; }
            set { _orderlist.OrderDate = value; }
        }
        [DisplayName("會員")]
        public bool? IsMember
        {
            get { return _orderlist.IsMember; }
            set { _orderlist.IsMember = value; }
        }
        [DisplayName("會員帳號")]
        public int? MemberId
        {
            get { return _orderlist.MemberId; }
            set { _orderlist.MemberId = value; }
        }
        [DisplayName("付款日期")]
        public DateTime? PayDate
        {
            get { return _orderlist.PayDate; }
            set { _orderlist.PayDate = value; }
        }
        [DisplayName("付款狀態")]
        public bool? IsPayed
        {
            get { return _orderlist.IsPayed; }
            set { _orderlist.IsPayed = value; }
        }
        [DisplayName("訂單總額")]
        public decimal? OrderTotal
        {
            get { return _orderlist.OrderTotal; }
            set { _orderlist.OrderTotal = value; }
        }
        [DisplayName("指定送貨時間")]
        public string? ShippingTimeReq
        {
            get { return _orderlist.ShippingTimeReq; }
            set { _orderlist.ShippingTimeReq = value; }
        }
        [DisplayName("訂單狀態")]
        public string? OrderState
        {
            get { return _orderlist.OrderState; }
            set { _orderlist.OrderState = value; }
        }
        [DisplayName("送貨方式")]
        public string? ShippingMethod
        {
            get { return _orderlist.ShippingMethod; }
            set { _orderlist.ShippingMethod = value; }
        }
        [DisplayName("7-11貨到付款")]
        public bool? Is711Pay
        {
            get { return _orderlist.Is711Pay; }
            set { _orderlist.Is711Pay = value; }
        }
        [DisplayName("7-11門市")]
        public string? Store711
        {
            get { return _orderlist.Store711; }
            set { _orderlist.Store711 = value; }
        }
        [DisplayName("購買人姓名")]
        public string? CustomerName
        {
            get { return _orderlist.CustomerName; }
            set { _orderlist.CustomerName = value; }
        }
        [DisplayName("購買人電話")]
        public string? CustomerPhone
        {
            get { return _orderlist.CustomerPhone; }
            set { _orderlist.CustomerPhone = value; }
        }
        [DisplayName("購買人電郵")]
        public string? CustomerEmail
        {
            get { return _orderlist.CustomerEmail; }
            set { _orderlist.CustomerEmail = value; }
        }
        [DisplayName("購買人地址1")]
        public string? CustomerAdd1
        {
            get { return _orderlist.CustomerAdd1; }
            set { _orderlist.CustomerAdd1 = value; }
        }
        [DisplayName("購買人地址2")]
        public string? CustomerAdd2
        {
            get { return _orderlist.CustomerAdd2; }
            set { _orderlist.CustomerAdd2 = value; }
        }
        [DisplayName("購買人地址3")]
        public string? CustomerAdd3
        {
            get { return _orderlist.CustomerAdd3; }
            set { _orderlist.CustomerAdd3 = value; }
        }
        [DisplayName("收件人姓名")]
        public string? ShippingName
        {
            get { return _orderlist.ShippingName; }
            set { _orderlist.ShippingName = value; }
        }
        [DisplayName("收件人電話")]
        public string? ShippingPhone
        {
            get { return _orderlist.ShippingPhone; }
            set { _orderlist.ShippingPhone = value; }
        }
        [DisplayName("收件人地址1")]
        public string? ShippingAdd1
        {
            get { return _orderlist.ShippingAdd1; }
            set { _orderlist.ShippingAdd1 = value; }
        }
        [DisplayName("收件人地址2")]
        public string? ShippingAdd2
        {
            get { return _orderlist.ShippingAdd2; }
            set { _orderlist.ShippingAdd2 = value; }
        }
        [DisplayName("收件人地址3")]
        public string? ShippingAdd3
        {
            get { return _orderlist.ShippingAdd3; }
            set { _orderlist.ShippingAdd3 = value; }
        }
        [DisplayName("手機載具條碼")]
        public string? Phinvoice
        {
            get { return _orderlist.Phinvoice; }
            set { _orderlist.Phinvoice = value; }
        }
        [DisplayName("統一編號")]
        public string? Cpinvoice
        {
            get { return _orderlist.Cpinvoice; }
            set { _orderlist.Cpinvoice = value; }
        }
        [DisplayName("公司抬頭")]
        public string? Cptitle
        {
            get { return _orderlist.Cptitle; }
            set { _orderlist.Cptitle = value; }
        }
        [DisplayName("付款方式")]
        public string? PayMethod
        {
            get { return _orderlist.PayMethod; }
            set { _orderlist.PayMethod = value; }
        }
        [DisplayName("折扣碼")]
        public string? DiscountCode
        {
            get { return _orderlist.DiscountCode; }
            set { _orderlist.DiscountCode = value; }
        }
        [DisplayName("折扣金額")]
        public decimal? DiscountPrice
        {
            get { return _orderlist.DiscountPrice; }
            set { _orderlist.DiscountPrice = value; }
        }
        [DisplayName("運費")]
        public decimal? ShippingFeed
        {
            get { return _orderlist.ShippingFeed; }
            set { _orderlist.ShippingFeed = value; }
        }
        [DisplayName("點數")]
        public int? Points
        {
            get { return _orderlist.Points; }
            set { _orderlist.Points = value; }
        }
        [DisplayName("備註")]
        public string? OrderListNote
        {
            get { return _orderlist.OrderListNote; }
            set { _orderlist.OrderListNote = value; }
        }

        public virtual Member? Member
        {
            get { return _orderlist.Member; }
            set { _orderlist.Member = value; }
        }

        public virtual OrderDetail? OrderDetail
        {
            get { return _orderlist.OrderDetail; }
            set { _orderlist.OrderDetail = value; }
        }
    }
}
