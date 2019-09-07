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
        
        // GET: Customer
        public ActionResult Index()
        {
            var customers = context.Customers.ToList();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = context.Customers.Where(i => i.Id == id).FirstOrDefault();

            return View(customer);
        }

        // GET: /Customer/Create  
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "FirstName, LastName, PhoneNumber, HomeAddress, Email")]Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Customer/Edit/id
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

        // POST: /Customer/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id, FirstName, LastName, PhoneNumber, HomeAddress, Email")]Customer customer)
        {
            if (id != customer.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customerToUpdate = context.Customers.Find(id);
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

                return RedirectToAction(nameof(Index));
        }

        //GET: /Customer/Delete/id
        [HttpGet]
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

            return RedirectToAction(nameof(Index));
        }
    }
}