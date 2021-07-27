using CrudOperation.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace CrudOperation.Controllers
{
    public class ProductsController : Controller
    {
        //GET: AllProducts
        db_NimapTestEntities dbObj = new db_NimapTestEntities();
        public ActionResult AllProducts(tbl_NimapTest obj)
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProducts(tbl_NimapTest model)
        {

            tbl_NimapTest obj = new tbl_NimapTest();
           
                obj.ProductId = model.ProductId;
            obj.ProductName = model.ProductName;
            obj.CategoryId = model.CategoryId;
            obj.CategoryName = model.CategoryName;

            if (model.ProductId == 0)
            {
                dbObj.tbl_NimapTest.Add(obj);
                dbObj.SaveChanges();
                ViewBag.Message = "Data Inserted Successfully Click";
            }

          

            return View("AllProducts");
        }

      //  public ActionResult EditProduct(int id=0)
        //{ 
        //tbl_NimapTest P

        ///}


        public ActionResult ProductsList(int? i)
        {
            var res = dbObj.tbl_NimapTest.ToList().ToPagedList(i ?? 1, 10);
            return View(res);
        }

        public ActionResult DeleteProducts(int ProductId)
        {
            var res = dbObj.tbl_NimapTest.Find(ProductId);
            dbObj.tbl_NimapTest.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tbl_NimapTest.ToList();

            return RedirectToAction("ProductsList", list);
        }







    }

}