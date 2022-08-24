using mvc_first_akshay.db;
using mvc_first_akshay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_first_akshay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            mydbEntities obj = new mydbEntities();
            var res = obj.mvc_table_akshay.ToList();
            List<Class1> cal = new List<Class1>();
            foreach (var item in res)
            {
                cal.Add(new Class1
                { 
                id=item.id,
                name=item.name,
                email=item.email,
                phone=item.phone,
                city=item.city
                
                
                });
            }
            return View(cal);
        }

        public ActionResult About()
        {
            mydbEntities obj = new mydbEntities();
            var result = obj.mvc_table_akshay.ToList();

            return View(result);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // delete method
        public ActionResult delete(int ID)
        {
            mydbEntities Entobj = new mydbEntities();
            var dal = Entobj.mvc_table_akshay.Where(m => m.id == ID).First();
            Entobj.mvc_table_akshay.Remove(dal);
            Entobj.SaveChanges();


            return RedirectToAction("Index");
        }
        // addForm
        [HttpGet]
        public ActionResult AddForm()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult AddForm(Class1 classobj)
        {
            mydbEntities Entobj = new mydbEntities();
            mvc_table_akshay tblobj = new mvc_table_akshay();
            tblobj.id = classobj.id;
            tblobj.name = classobj.name;
            tblobj.email = classobj.email;
            tblobj.phone = classobj.phone;
            tblobj.city = classobj.city;

            if (classobj.id==0)
            {

            Entobj.mvc_table_akshay.Add(tblobj);
            Entobj.SaveChanges();
            }
            else
            {
                Entobj.Entry(tblobj).State = System.Data.Entity.EntityState.Modified;
                Entobj.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            mydbEntities Entobj = new mydbEntities();
            var edititem = Entobj.mvc_table_akshay.Where(m => m.id == id).First();
            Class1 claobj = new Class1();
            claobj.id = edititem.id;
            claobj.name = edititem.name;
            claobj.email = edititem.email;
            claobj.phone = edititem.phone;
            claobj.city = edititem.city;

            return View("AddForm",claobj);
        }
    }
}