using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace bookfortable.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _enviro = null;
        public ProductController(IWebHostEnvironment p)
        {
            _enviro = p;
        }
        public IActionResult List(PKeywordVewModel vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<Product> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.Products
                        select p;
            else
                datas = db.Products.Where(p =>
                    p.ProductName.Contains(vm.txtKeyword) ||
                    p.SupplierId.Contains(vm.txtKeyword) ||
                    p.ProductPhoto.Contains(vm.txtKeyword) ||
                    p.Description.Contains(vm.txtKeyword) ||
                    p.Isbn.ToString().Contains(vm.txtKeyword)
                );
            return View(datas);
        }
        [HttpGet]
        public IActionResult ClearSearch()
        {
            // 重置查詢條件為初始值，這取決於您的應用程序邏輯

            // 例如，將查詢字符串重置為空
            HttpContext.Session.SetString("QueryString", "");

            // 重定向到原始頁面或者列表頁面
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                Product prod = db.Products.FirstOrDefault(p => p.ProductId == id);
                if (prod != null)
                {
                    db.Products.Remove(prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Product p)
        //{
        //    FinalContext db = new FinalContext();
        //    db.Products.Add(p);
        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}

        [HttpPost]
        public IActionResult Create(CProductWrap p)
        {
            FinalContext db = new FinalContext();
            if (p.photo != null)
            {
                string photoName = Guid.NewGuid().ToString() + ".jpg";
                p.product.ProductPhoto = photoName;
                p.photo.CopyTo(new FileStream(_enviro.WebRootPath + "images" + photoName, FileMode.Create));
            }
            db.Products.Add(p.product);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            Product prod = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (prod == null)
                return RedirectToAction("List");
            CProductWrap cp = new CProductWrap();
            cp.product = prod;

            return View(cp);
        }
        [HttpPost]

        public IActionResult Edit(CProductWrap pIn)
        {
            FinalContext db = new FinalContext();
            Product pEdit = db.Products.FirstOrDefault(p => p.ProductId == pIn.ProductId);
            if (pEdit != null)
            {
                if (pIn.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    pEdit.ProductPhoto = photoName;
                    pIn.photo.CopyTo(new FileStream(_enviro.WebRootPath + "images" +photoName, FileMode.Create));
                }

                pEdit.ProductId = pIn.ProductId;
                pEdit.ProductName = pIn.ProductName;
                pEdit.SupplierId = pIn.SupplierId;
                //pEdit.ProductPhoto = pIn.ProductPhoto;
                pEdit.Description = pIn.Description;
                pEdit.UnitPrice = pIn.UnitPrice;
                pEdit.UnitsInStock = pIn.UnitsInStock;
                pEdit.VersionInfo = pIn.VersionInfo;
                pEdit.PublicationDate = pIn.PublicationDate;
                pEdit.SellingPrice = pIn.SellingPrice;
                pEdit.Isbn = pIn.Isbn;

                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
