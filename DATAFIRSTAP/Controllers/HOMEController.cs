using DATAFIRSTAP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DATAFIRSTAP.Controllers
{
    public class HOMEController : Controller
    {
        studentEntities DB = new studentEntities();
        // GET: HOME
        public ActionResult Index()
        {
            var DATA = DB.Student1.ToList();
            return View(DATA);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Student1 s)
        {
            if (ModelState.IsValid == true)
            {

                DB.Student1.Add(s);
                int a = DB.SaveChanges();
                if (a > 0)
                {
                    TempData["insertdata"] = "<script>alert('inserted ')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["insertdata"] = "<script>alert(' not inserted ')</script>";
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = DB.Student1.Where(model => model.Rollno == id).FirstOrDefault();

            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student1 s)
        {
            if (ModelState.IsValid == true)
            {
                DB.Entry(s).State = EntityState.Modified;
                int a = DB.SaveChanges();
                if (a > 0)
                {
                    TempData["updatedata"] = "<script>alert('update ')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["updatedata"] = "<script>alert(' not update ')</script>";
                }
            }
                return View(); 
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
               var DeleteRow = DB.Student1.Where(model => model.Rollno == id).FirstOrDefault();
                if(DeleteRow != null)
                {
                    DB.Entry(DeleteRow).State = EntityState.Deleted;
                      int a = DB.SaveChanges();
                       if (a > 0)
                        {
                            TempData["Deletedata"] = "<script>alert('Delete ')</script>";
                            return RedirectToAction("Index");
                        }
                       else
                       {
                            TempData["Deletedata"] = "<script>alert(' not Delete ')</script>";
                        }
                }
            }
            return View();
        }
        //[HttpPost]
        //public ActionResult Delete(Student1 p)
        //{
        //    DB.Entry(p).State = EntityState.Deleted;
        //    int a = DB.SaveChanges();
        //   if (a > 0)
        //    {
        //        TempData["Deletedata"] = "<script>alert('Delete ')</script>";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        TempData["Deletedata"] = "<script>alert(' not Delete ')</script>";
        //    }
        //    return View();
        //}
        public ActionResult Details(int id) 
        { 

         var Row = DB.Student1.Where(model => model.Rollno == id).FirstOrDefault();
            return View(Row);
        }

       /* private class Db
        {
            internal static int savechanges()
            {
                throw new NotImplementedException();
            }
        }*/
    }
}