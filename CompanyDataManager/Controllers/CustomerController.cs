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
        public JsonResult GetCustomers()
        {
            CustomerData data = new CustomerData();

            var output = data.GetCustomers().ToList();

            var customers = mapper.Map<List<Customer>>(output);

            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Details(int? id)
        {

            CustomerData data = new CustomerData();

            var output = data.GetCustomerById(id).FirstOrDefault();

            var customer = mapper.Map<Customer>(output);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerData data = new CustomerData();
                data.SaveCustomer(mapper.Map<CustomerModel>(customer));
            }

            return Json(null);
        }

        [HttpPost]
        public JsonResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerData data = new CustomerData();

                data.UpdateCustomer(mapper.Map<CustomerModel>(customer));
            }

            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            CustomerData data = new CustomerData();

            data.DeleteCustomer(id);

            return Json(null);
        }
    }
}
