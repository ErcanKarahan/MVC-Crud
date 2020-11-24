using MVCCrud_0.DesignPatterns.SingletonPattern;
using MVCCrud_0.Models;
using MVCCrud_0.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud_0.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }

        // GET: Category
        public ActionResult CategoryList()
        {
            #region UsingNotlari
            //using (NorthwindEntities db = new NorthwindEntities)
            //{
            //bu noktada ise db sadece bu alanlarda calısarak Garbage Collector'a varsayılan görevinden ziyade sizin tarafınızdan yönetilmesiyle yasatılır ve son paranteze geldigi anda Ram'den kaldırılır...
            //}


            //NorthwindEntities db = new NorthwindEntities();
            //1000 satırlık calıstıgı sürece üstteki db nesnesi Ram'de kalacaktır. Ancak ve ancak bu yasam alanının parantezi bittiginde Garbage Collector tarafından kaldırılır... 
            #endregion


            CategoryVM cvm = new CategoryVM
            {
                Categories = _db.Categories.ToList()
            };
            return View(cvm);
        }

        public ActionResult AddCategory()
        {
            #region HTTPVeActionNotlari
            //Burası HttpGet yöntemi ile calısacak bir Action'dir...BU Action'ın amacı kullanıcıya üzerine bilgi yazabilecegi bir form cıkarmaktır...Sonra o ilgili form doldurularak server'a gönderilmelidir(Post) BU işlemi yapabilmesi icin de ayrı bir HttpPost yöntemi uygulayan metot (Action) lazımdır. Bu acılacak Action da Category verisi alabilmesi parametreli olması gerekir...


            //Bir View'dan Controller icerisindeki Action'a veri gidebilmesi icin ilgili View'in kesinlikle bir Html form etiketine sahip olması gerekir. Sonra yine model binding yöntemi ile gönderilecek verinin View tarafından bilinmesi gerekir...

            //Eger bir Action View'a model göndermiyorsa buna ragmen ilgili View sanki modeli karsılıyormus @model keyword'u ile set ediyorsa o zaman bu demektir ki ilgili View post olan bir action'a model gönderiyordur... 
            #endregion
            //İlgili Kateogrinin product'larını listele

            CategoryVM cvm = new CategoryVM()
            {
                Category = new Category()
            };
            return View(cvm);
        }

        [HttpPost]
        public ActionResult AddCategory(Category item)
        {

            _db.Categories.Add(item);
            _db.SaveChanges();



            return RedirectToAction("CategoryList");
        }
    }
}