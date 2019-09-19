using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Order.Models;
using System.Data.Entity;


namespace Order.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (OrderingContext context = new OrderingContext()) 
            {


                return View(context.Customers.ToList());
            }
           
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (OrderingContext context=new OrderingContext())
            {

                return View(context.Customers.Find(id));
            }       
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (OrderingContext context = new OrderingContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();                
                }

                return RedirectToAction("Index");     
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (OrderingContext context = new OrderingContext())
            {

                return View(context.Customers.Find(id));
            }       
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            //customer.FirstName = "Test";

            try
            {
                using (OrderingContext context = new OrderingContext())
                {
                    context.Entry(customer).State = EntityState.Modified;
                    context.SaveChanges();      
                }            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {

            using (OrderingContext context = new OrderingContext())
            {

                return View(context.Customers.Find(id));
            }       
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (OrderingContext context=new OrderingContext())
            try
            {
                Customer customer = context.Customers.Find(id);
                context.Customers.Remove(customer);
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
