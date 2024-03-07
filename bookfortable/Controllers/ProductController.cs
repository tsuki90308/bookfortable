using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using X.PagedList;


namespace bookfortable.Controllers
{
    public class ProductController : Controller
    {



        private IWebHostEnvironment _enviro = null;
        public ProductController(IWebHostEnvironment p)
        {
            _enviro = p;
        }

        //public IActionResult List(PKeywordVewModel vm)
        //{
        //    FinalContext db = new FinalContext();
        //    IEnumerable<Product> datas = null;
        //    if (string.IsNullOrEmpty(vm.txtKeyword))
        //        datas = from p in db.Products
        //                select p;
        //    else
        //        datas = db.Products.Where(p =>
        //            p.ProductName.Contains(vm.txtKeyword) ||
        //            p.SupplierId.Contains(vm.txtKeyword) ||
        //            p.ProductPhoto.Contains(vm.txtKeyword) ||
        //            p.Description.Contains(vm.txtKeyword) ||
        //            p.Isbn.ToString().Contains(vm.txtKeyword)
        //        );
        //    return View(datas);
        //}

        public IActionResult List(PKeywordVewModel vm, int? page)
        {
            FinalContext db = new FinalContext();
            IQueryable<Product> datas = db.Products; // 使用 IQueryable 以支援分頁

            // 如果有關鍵字，進行過濾
            if (!string.IsNullOrEmpty(vm.txtKeyword))
            {
                datas = datas.Where(p =>
                    p.ProductName.Contains(vm.txtKeyword) ||
                    p.SupplierId.Contains(vm.txtKeyword) ||
                    p.ProductPhoto.Contains(vm.txtKeyword) ||
                    p.Description.Contains(vm.txtKeyword) ||
                    p.Isbn.ToString().Contains(vm.txtKeyword)
                );
            }

            // 獲取符合條件的資料總數
            int totalCount = datas.Count();

            // 分頁
            int pageSize = 10; // 每頁顯示的項目數
            int pageNumber = (page ?? 1); // 如果 page 為空，預設為第 1 頁

            // 將資料集合轉換為分頁後的集合
            var pagedData = datas.ToPagedList(pageNumber, pageSize);

            // 將總筆數傳遞給視圖
            ViewBag.TotalCount = totalCount;

            // 獲取資料庫中的全部資料總數
            int totalRecordsCount = db.Products.Count();

            // 將全部資料總數傳遞給視圖
            ViewBag.TotalRecordsCount = totalRecordsCount;

            return View(pagedData);
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

        //[HttpPost]
        //public IActionResult Create(CProductWrap p)
        //{
        //    FinalContext db = new FinalContext();
        //    if (p.photo != null)
        //    {
        //        string photoName = Guid.NewGuid().ToString() + ".jpg";
        //        p.product.ProductPhoto = photoName;
        //        p.photo.CopyTo(new FileStream(_enviro.WebRootPath + "images" + photoName, FileMode.Create));
        //    }
        //    db.Products.Add(p.product);
        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}


        [HttpPost]
        public IActionResult Create(CProductWrap p)
        {
            FinalContext db = new FinalContext();
            if (p.photo != null)
            {
                // 生成新的文件名，基于当前时间戳
                string photoName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

                // 保存图像到文件系统中
                using (FileStream fs = new FileStream(Path.Combine(_enviro.WebRootPath, "images", photoName), FileMode.Create))
                {
                    p.photo.CopyTo(fs);
                }

                // 更新产品的图像信息为文件名
                p.product.ProductPhoto = photoName;
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
                    // 生成新的文件名，基于当前时间戳
                    string photoName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                    pEdit.ProductPhoto = photoName;

                    // 保存图像到文件系统中
                    using (FileStream fs = new FileStream(Path.Combine(_enviro.WebRootPath, "images", photoName), FileMode.Create))
                    {
                        pIn.photo.CopyTo(fs);
                    }
                }

                // 更新其他产品信息
                pEdit.ProductId = pIn.ProductId;
                pEdit.ProductName = pIn.ProductName;
                pEdit.SupplierId = pIn.SupplierId;
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
