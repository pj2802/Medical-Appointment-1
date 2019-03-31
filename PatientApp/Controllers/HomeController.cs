using PatientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new DataContext())
            {

                var joinData = (from s1 in db.Patients join s2 in db.Appointments on s1.PatientID equals s2.PatientID select new PatientVM { Patients = s1, Appointments = s2 }).ToList();

                return View(joinData);
            }
        }

        [HttpPost]
        public ActionResult Index(string PatientName, PatientVM patient)
        {
            using (var db = new DataContext())
            {

                var joinData = (from s1 in db.Patients join s2 in db.Appointments on s1.PatientID equals s2.PatientID where s1.PatientName.StartsWith(PatientName) select new PatientVM { Patients = s1, Appointments = s2 }).ToList();

                return View(joinData);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

               

    }
}