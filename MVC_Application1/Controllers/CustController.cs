using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application1.Models;
using System.Data.Entity;

namespace MVC_Application1.Controllers
{
    [Authorize]
    public class CustController : Controller
    {
        // GET: Cust
        private ApplicationDbContext dbContext = null;
        public CustController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                dbContext.Dispose();
            }
           
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var customers = dbContext.tblCustomers.Include(m=>m.Member).ToList();
            return View("Index",customers);
        }
        public ActionResult details(int id)
        {
            var c = dbContext.tblCustomers.Include(d=>d.Member).ToList().SingleOrDefault(a => a.Id == id);
            return View(c);
        }
        public List<CustomerDetails> GetCustomer()
        {
            List<CustomerDetails> details = new List<CustomerDetails>
               {
                    new CustomerDetails{Id=1,Name="Tejaswini",Birthdate=Convert.ToDateTime("14/01/1998"),Gender="fem"},
                    new CustomerDetails{Id=1,Name="Ziya",Birthdate=Convert.ToDateTime("15/02/1997"),Gender="fem"},
                    new CustomerDetails{Id=1,Name="Jovika",Birthdate=Convert.ToDateTime("16/03/1996"),Gender="fem"}

               };

            return details;
        }
        [HttpGet]
        
        public ActionResult Create()
        {
            var customers = new CustomerDetails();
            //var gender = new List<SelectListItem>
            //{
            //    new SelectListItem{Text="select a gender",Disabled=true,Selected=true},
            //    new SelectListItem{Text="Male" },
            //    new SelectListItem{Text="Female" },
            //    new SelectListItem{Text="Others"},

            //};
            ViewBag.Gender = ListGender();
            ViewBag.MembershipType1Id = ListMembership();
            return View(customers);
        }
       [HttpPost]
        public ActionResult Create(CustomerDetails customerFromView)
        {
            if(!ModelState.IsValid)
            {
                //var customerObj = new CustomerDetails();
                ViewBag.Gender = ListGender();
                ViewBag.MembershipType1Id = ListMembership();
                return View(customerFromView);

            }
            dbContext.tblCustomers.Add(customerFromView);//insert operation
            dbContext.SaveChanges();//update to database
            return RedirectToAction("Index", "Cust");
            //return View();
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customers = dbContext.tblCustomers.SingleOrDefault(c => c.Id == id);
            if (customers != null)
            {


                ViewBag.Gender = ListGender();
                ViewBag.MembershipType1Id = ListMembership();
                return View(customers);
            }
            return HttpNotFound("customer doesnt exists!!!!!!");
        }
        [HttpPost]
        
        public ActionResult EditCustomer(CustomerDetails customerFromView)
        {
            if (ModelState.IsValid)
            {


                var customerInDB = dbContext.tblCustomers.FirstOrDefault(c => c.Id == customerFromView.Id); ;
                customerInDB.Name = customerFromView.Name;
                customerInDB.Gender = customerFromView.Gender;
                customerInDB.Birthdate = customerFromView.Birthdate;
                customerInDB.MembershipType1Id = customerFromView.MembershipType1Id;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Cust");
            }
            else
            {
                ViewBag.Gender = ListGender();
                ViewBag.MembershipType1Id = ListMembership();
                return View(customerFromView);
            }
        }
        [HttpGet]
        public ActionResult DeleteConfirmed(int? id)
        {
            var customerss = dbContext.tblCustomers.SingleOrDefault(c => c.Id == id);
            if (id == null)
            {
                return HttpNotFound("not found!");
            }
            CustomerDetails cd = dbContext.tblCustomers.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }
        [HttpPost]
        
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerDetails cd = dbContext.tblCustomers.Find(id);
            dbContext.tblCustomers.Remove(cd);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Cust");
        }





        [NonAction]
        public IEnumerable<SelectListItem> ListGender()
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="select a gender",Disabled=true,Selected=true},
                new SelectListItem{Text="Male" },
                new SelectListItem{Text="Female" },
                new SelectListItem{Text="Others"},

            };
            return gender;
        }


        [NonAction]
            public IEnumerable<SelectListItem> ListMembership()
        {
            var membership = (from m in dbContext.MembershipType1.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.Type,
                                  Value = m.Id.ToString()
                              }).ToList();
            membership.Insert(0, new SelectListItem { Text = "--select--", Value = "0" });
            return membership;
        }
        
    }
}