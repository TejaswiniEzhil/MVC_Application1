using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application1.Models;

namespace MVC_Application1.Controllers
{
    [Authorize]
    public class Movie1Controller : Controller
    {
        // GET: Movies
        private ApplicationDbContext dbContext = null;
        public Movie1Controller()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }

        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var mov = dbContext.tblMovies.ToList();
            return View("Index", mov);
           
        }
        public ActionResult details1(int id)
        {
            var c1 = dbContext.tblMovies.ToList().SingleOrDefault(b => b.Id == id);
            return View(c1);
        }
        public List<ListOfMovies> GetMovies()
        {
            List<ListOfMovies> det = new List<ListOfMovies>
            {
                new ListOfMovies{Id=1,MovieName="Theri",ReleaseDate=Convert.ToDateTime("2017/09/09")},
                new ListOfMovies{Id=2,MovieName="singam",ReleaseDate=Convert.ToDateTime("2010/08/12")},
                new ListOfMovies{Id=3,MovieName=" Bigil",ReleaseDate=Convert.ToDateTime("2019/11/28")}
            };
            return det;
        }
        public ActionResult Create1()
        {
            var movies = new ListOfMovies();
            return View(movies);
        }
        [HttpPost]
        public ActionResult Create1(ListOfMovies movieFromView)
        {
            if (!ModelState.IsValid)
            {
                //var customerObj = new CustomerDetails();
                
               
                return View(movieFromView);

            }
            return View();
        }

    }
}