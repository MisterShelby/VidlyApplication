using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VidlyApplication.Models;
using VidlyApplication.ViewModels;

namespace VidlyApplication.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _contex;

        public CustomersController()
        {
            _contex = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }

        public ActionResult New()
        {
            var membershiptypes = _contex.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershiptypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _contex.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);

            }
            

            
            if (customer.Id==0)
            {
                _contex.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _contex.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _contex.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        

        public ViewResult Index()
        {
     
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _contex.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _contex.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _contex.MembershipTypes.ToList(),
                Customer = customer
            };
            return View("CustomerForm",viewModel);
        }


    }
}