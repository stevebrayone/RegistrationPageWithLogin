using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using RegisterationForm.Entities;
using RegisterationForm.Models;
using System.Diagnostics;

namespace RegisterationForm.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly EntityDbContext dbContext;
        public HomeController(EntityDbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        //insert DATA To a database
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegTable emp)
        {
            var register = new RegModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                PhNo = emp.PhNo,
                Password = emp.Password,
                ConformPass = emp.ConformPass
            };
            if (ModelState.IsValid)
            {
                dbContext.RegistrationTable.Add(register);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Login(Loging obj)
        //{
        //    var log = dbContext.RegistrationTable.ToList();
        //    foreach (var item in log)
        //    {
        //        if (item.Name == obj.Name)
        //        {

        //            foreach (var items in log)
        //            {
        //                if (item.Password == obj.Password)
        //                {

        //                    return RedirectToAction("Privacy");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("Login");
        //        }
        //        return RedirectToAction("Privacy");
        //    }
        //    return View();
        //}

        //public IActionResult Privacy()
        //{

        //    return View();
        //}

        [HttpPost]
        public IActionResult Login(Loging obj)
        {
            var log = dbContext.RegistrationTable.ToList();
            foreach (var item in log)
            {
                if (item.Name == obj.Name && item.Password == obj.Password)
                {
                    TempData["ab"]= item.Name;
                    return RedirectToAction("Privacy");
                }
            }

            return View();
        }
        public IActionResult Privacy()
        {
            ViewBag.data = TempData["ab"] as string;
            return View();
        }
       
    }

}