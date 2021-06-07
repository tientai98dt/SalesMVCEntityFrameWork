using SalesMVCEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesLibrary;

namespace SalesMVCEntityFrameWork.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(string search, int page = 1, int pageSize = 10)
        {
            var list = new CustomerModels();
            var model = list.GetListCustomer(search,page,pageSize);
            return View(model);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var model = new CustomerModels();
                    model.InsertCustomer(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new CustomerModels();
            var list = model.GetListCustomerByID(id);
            return View(list);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new CustomerModels();
                    model.UpdateCustomer(id,customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = new CustomerModels();
                if (ModelState.IsValid)
                {
                    model.DeleteCustomer(id);
                    model.GetListCustomer();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
