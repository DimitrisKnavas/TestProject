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
        
        [HttpGet]
        public JsonResult GetCustomers()
        {
            var customers = context.Customers.ToList();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
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

        
        
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customerToUpdate = context.Customers.Find(customer.Id);
            if (TryUpdateModel(customerToUpdate, "",
               new string[] { "FirstName", "LastName", "PhoneNumber","HomeAddress", "Email" }))
            {
                try
                {
                    context.Entry(customerToUpdate).State = EntityState.Modified;
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
                Customer customer = context.Customers.Find(id);
                context.Customers.Remove(customer);
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