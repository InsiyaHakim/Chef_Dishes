using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Chef_Dishes.Models;
using System;
using System.Collections.Generic;

namespace Chef_Dishes
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
 
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("createChef")]
        public IActionResult CreateChef(Chef chef)
        {
            
            if(chef.dob == null)
            {
                ModelState.AddModelError("dob","Date of Birth is required");
                return View("Index");
            }
            if(chef.dob == DateTime.Today)
            {
                ModelState.AddModelError("dob","Date must be from past");
                return View("Index");
            }
            if(ModelState.IsValid)
            {
                dbContext.chef.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }

        [HttpGet("add_dish")]
        public IActionResult AddDish()
        {
            List<Chef> Chefs = dbContext.chef.ToList();
            ViewBag.Chefs= Chefs;
            return View();
        }

        [HttpPost("createDish")]
        public IActionResult CreateDish(Dishes dishes)
        {
            List<Chef> Chefs = dbContext.chef.ToList();

            if(ModelState.IsValid)
            {
                if(dishes.Tastiness == 0)
                {
                    ModelState.AddModelError("Tastiness","No any field should be empty");
                }
                if(dishes.calories == 0)
                {
                    ModelState.AddModelError("calories","Calories must be more than 0");
                }
                if(dishes.Tastiness < 1 || dishes.Tastiness > 5)
                {
                    ModelState.AddModelError("Tastiness","Tastiness must be more than 0 and less then 6");
                }
                if(ModelState.IsValid == false)
                {
                    ViewBag.Chefs= Chefs;
                    return View("AddDish");
                }
                return RedirectToAction("AddDish");
            }
           
            ViewBag.Chefs= Chefs;
            return View("AddDish");
        }
    }
}