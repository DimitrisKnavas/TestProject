using AutoMapper;
using CompanyDataManager.Helper;
using CompanyDataManager.Models;
using CompanyDataManagerLibrary.DataAccess;
using CompanyDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CompanyDataManager.Controllers
{
    public class CustomerController : Controller
    {
        //used to map models in mvc and data library
        private IMapper mapper = AutomapperHelper.ConfigureAutomapper();

        // GET: Customer
        public ActionResult Index()
        {

            CustomerData data = new CustomerData();

            var output = data.GetCustomers().ToList();

            var customers = mapper.Map<List<Customer>>(output);

            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerData data = new CustomerData();

            var output = data.GetCustomerById(id).FirstOrDefault();

            var customer = mapper.Map<Customer>(output);

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
        public ActionResult Create([Bind(Include = "FirstName, LastName, PhoneNumber, HomeAddress, Email")]Customer customer)
        {
            CustomerData data = new CustomerData();
            data.SaveCustomer(mapper.Map<CustomerModel>(customer));
            return RedirectToAction(nameof(Index));
        }

        // GET: /Customer/Edit/id
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerData data = new CustomerData();

            var output = data.GetCustomerById(id).FirstOrDefault();

            var customer = mapper.Map<Customer>(output);

            return View(customer);
        }

        // POST: /Customer/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id, FirstName, LastName, PhoneNumber, HomeAddress, Email")]Customer customer)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerData data = new CustomerData();

            data.UpdateCustomer(mapper.Map<CustomerModel>(customer));

            return RedirectToAction(nameof(Index));
        }

        //GET: /Customer/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {

            CustomerData data = new CustomerData();

            data.DeleteCustomer(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
