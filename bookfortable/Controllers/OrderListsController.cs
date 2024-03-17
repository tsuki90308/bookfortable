using Bookfortable.Models;
using Bookfortable.ViewModels;
using Bookfortable.Models;
using Bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bookfortable.Controllers
{
    public class OrderListsController : Controller
    {
        private readonly FinalContext _context;

        public OrderListsController(FinalContext context)
        {
            _context = context;
        }

        //客戶端的放這裡
        public async Task<IActionResult> Checkout(
            string deliveryWay, string howtopay, decimal resultPrice, decimal sum, string txtDiscountCode, decimal shipping, string CustomerName, string CustomerPhone, string CustomerEmail,
            int TempBoxId, string BookTag2string, int ProductAmount, decimal singileitemsum, string Oidramd)
        {
            FinalContext db = new FinalContext();
            if (!HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST))
                return RedirectToAction("Shopping", "List");

            string guid = Guid.NewGuid().ToString();
            OrderList orderList = new OrderList();
            orderList.Oidramd = guid;
            orderList.ShippingMethod = deliveryWay;
            orderList.PayMethod = howtopay;
            orderList.DiscountPrice = resultPrice;
            orderList.OrderTotal = sum;
            orderList.DiscountCode = txtDiscountCode;
            orderList.ShippingFeed = shipping;
            orderList.CustomerName = CustomerName;
            orderList.CustomerPhone = CustomerPhone;
            orderList.CustomerEmail = CustomerEmail;
            orderList.DiscountCode = txtDiscountCode;
            //db.Add(orderList);
            db.OrderLists.Add(orderList);
            db.SaveChanges();

            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);


            ViewBag.CartItem = cart;

            return View(orderList);

        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderList odList)
        {

            FinalContext db = new FinalContext();
            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);

            var x = db.OrderLists.First(x => x.Oidramd == odList.Oidramd);
            x.OrderDate = DateTime.Now;
            x.IsPayed = false;
            x.CustomerName = odList.CustomerName;
            x.CustomerPhone = odList.CustomerPhone;
            x.CustomerEmail = odList.CustomerEmail;
            x.CustomerAdd1 = odList.CustomerAdd1;
            x.CustomerAdd2 = odList.CustomerAdd2;
            x.CustomerAdd3 = odList.CustomerAdd3;
            x.ShippingName = odList.ShippingName;
            x.ShippingPhone = odList.ShippingPhone;
            x.ShippingAdd1 = odList.ShippingAdd1;
            x.ShippingAdd2 = odList.ShippingAdd2;
            x.ShippingAdd3 = odList.ShippingAdd3;
            x.Phinvoice = odList.Phinvoice;
            //odList.CShoppingCartItems = cart;
            db.SaveChanges();

            OrderDetail detail = new OrderDetail();
            foreach (var item in cart)
            {
                detail.OrderDetailId = odList.Oidramd;
                detail.TempBoxId = item.productId;
                detail.BookTag2string = item.productType;
                detail.ProductAmount = item.count;
                detail.Price = item.price;
            }
            ViewBag.CartItem = cart;
            db.OrderDetails.Add(detail);
            db.SaveChanges();
            ViewBag.OrderDetail = detail;

            cart.Clear();
            return RedirectToAction("ReviewOrder");

        }

        public async Task<IActionResult> ReviewOrder(OrderList odList, OrderDetail odDetail)
        {
            FinalContext db = new FinalContext();
            var x = db.OrderLists.First(x => x.Oidramd == odList.Oidramd);
            var y = db.OrderDetails.First(y => y.OrderDetailId == odDetail.OrderDetailId);



            return View(odList);
        }

        private List<CShoppingCartItem> GetOrderItems(string odIDramd)
        {
            FinalContext db = new FinalContext();
            var OrderItems = db.OrderDetails.Where(p => p.OrderDetailId == odIDramd).ToList();
            List<CShoppingCartItem> orderitems = new List<CShoppingCartItem>();
            foreach (var orderitem in OrderItems)
            {
                CShoppingCartItem item = new CShoppingCartItem();
                item.product = db.TempBoxes.Single(x => x.BoxId == orderitem.TempBoxId);
                orderitems.Add(item);
            }
            return orderitems;
        }





        // GET: OrderLists
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.OrderLists.Include(o => o.Member).Include(o => o.OrderDetail);
            return View(await finalContext.ToListAsync());
        }

        public IActionResult List(KeywordViewModels vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<OrderList> datas = null;

            //布林值轉換字元
            List<OrderListViewModel> list = new List<OrderListViewModel>();
            //foreach (OrderList os in datas)
            //{
            //    OrderListViewModel osvm = new OrderListViewModel();
            //    //osvm.list = (OrderList)datas;
            //    //osvm.OSisMember = Convert.ToString(os.IsMember);
            //}


            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.OrderLists
                        select p;
            else
                datas = db.OrderLists.Where(p =>
                p.Oidramd.Contains(vm.txtKeyword) ||
                p.CustomerName.Contains(vm.txtKeyword) ||
                p.DiscountCode.Contains(vm.txtKeyword));

            return View(datas);
        }

        // GET: OrderLists/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderList = await _context.OrderLists
        //        .Include(o => o.Member)
        //        .Include(o => o.OrderDetail)
        //        .FirstOrDefaultAsync(m => m.Oid == id);
        //    if (orderList == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderList);
        //}

        // GET: OrderLists/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: OrderLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public IActionResult Create(OrderList o)
        {
            FinalContext db = new FinalContext();
            db.OrderLists.Add(o);
            OrderListWrap olw = new OrderListWrap();
            olw.orderlist = o;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        // GET: OrderLists/Edit/5
        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            OrderList odl = db.OrderLists.FirstOrDefault(p => p.Oid == id);
            if (odl == null)
                return RedirectToAction("List");
            OrderListWrap odlw = new OrderListWrap();
            odlw.orderlist = odl;

            return View(odlw);
        }

        // POST: OrderLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public IActionResult Edit(OrderListWrap oIn)
        {
            FinalContext db = new FinalContext();
            OrderList oEdit = db.OrderLists.FirstOrDefault(p => p.Oid == oIn.Oid);
            if (oEdit != null)
            {
                oEdit.Oidramd = oIn.Oidramd;
                oEdit.OrderDetailId = oIn.OrderDetailId;
                oEdit.OrderDate = oIn.OrderDate;
                oEdit.IsMember = oIn.IsMember;
                oEdit.MemberId = oIn.MemberId;
                oEdit.PayDate = oIn.PayDate;
                oEdit.IsPayed = oIn.IsPayed;
                oEdit.OrderTotal = oIn.OrderTotal;
                oEdit.ShippingTimeReq = oIn.ShippingTimeReq;
                oEdit.OrderState = oIn.OrderState;
                oEdit.ShippingMethod = oIn.ShippingMethod;
                oEdit.Is711Pay = oIn.Is711Pay;
                oEdit.Store711 = oIn.Store711;
                oEdit.CustomerName = oIn.CustomerName;
                oEdit.CustomerPhone = oIn.CustomerPhone;
                oEdit.CustomerEmail = oIn.CustomerEmail;
                oEdit.CustomerAdd1 = oIn.CustomerAdd1;
                oEdit.CustomerAdd2 = oIn.CustomerAdd2;
                oEdit.CustomerAdd3 = oIn.CustomerAdd3;
                oEdit.ShippingName = oIn.ShippingName;
                oEdit.ShippingPhone = oIn.ShippingPhone;
                oEdit.ShippingAdd1 = oIn.ShippingAdd1;
                oEdit.ShippingAdd2 = oIn.ShippingAdd2;
                oEdit.ShippingAdd3 = oIn.ShippingAdd3;
                oEdit.Phinvoice = oIn.Phinvoice;
                oEdit.Cpinvoice = oIn.Cpinvoice;
                oEdit.Cptitle = oIn.Cptitle;
                oEdit.PayMethod = oIn.PayMethod;
                oEdit.DiscountCode = oIn.DiscountCode;
                oEdit.DiscountPrice = oIn.DiscountPrice;
                oEdit.ShippingFeed = oIn.ShippingFeed;
                oEdit.Points = oIn.Points;
                oEdit.OrderListNote = oIn.OrderListNote;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        // GET: OrderLists/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                OrderList odl = db.OrderLists.FirstOrDefault(p => p.Oid == id);
                if (odl != null)
                {
                    db.OrderLists.Remove(odl);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        // POST: OrderLists/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var orderList = await _context.OrderLists.FindAsync(id);
        //    if (orderList != null)
        //    {
        //        _context.OrderLists.Remove(orderList);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrderListExists(int id)
        //{
        //    return _context.OrderLists.Any(e => e.Oid == id);
        //}
    }
}
