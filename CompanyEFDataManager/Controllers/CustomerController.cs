using CompanyEFDataManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CompanyEFDataManager.Controllers
{
    public class CustomerController : Controller
    {
        private CompanyDataEntities context;

        public CustomerController()
        {
            context = new CompanyDataEntities();
        }
        
        
        public JsonResult GetCustomers()
        {
            var customers = context.Customers.ToList();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult Details(int? id)
        {
            var customer = context.Customers.Where(i => i.Id == id).FirstOrDefault();

            return Json(customer,JsonRequestBehavior.AllowGet);
        }


        
        [HttpPost]
        public async Task<JsonResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
            
            return Json(null);
        }

        
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = await context.Customers.FindAsync(id);

            return View(customer);
        }

        
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customerToUpdate = context.Customers.Find(customer.Id);
            if (TryUpdateModel(customerToUpdate, "",
               new string[] { "FirstName", "LastName", "PhoneNumber","HomeAddress", "Email" }))
            {
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

                return Json(null);
        }

        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Customer student = context.Customers.Find(id);
                context.Customers.Remove(student);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Json(null);
        }
    }
}