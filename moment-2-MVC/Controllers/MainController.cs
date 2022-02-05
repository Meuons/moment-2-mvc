using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moment_2_MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace moment_2_MVC.Controllers



{
    public class MainController : Controller
    {
        


     
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Todo()
        {

            //If data exist in the session storage deserialize it and save it in the List.Item property. If not, save a new list. 
            if (HttpContext.Session.GetString("items") != null)
            {
                var localJson = HttpContext.Session.GetString("items");
                List.Item = JsonSerializer.Deserialize<List<string>>(localJson);

            }
            else
            {
                List.Item = new List<string>();
            }

            ViewBag.item = List.Item;
            return View();
        }
       

        public IActionResult Converter()
        {
            return View();
        }

        public IActionResult Pancake()
        {
            //Set the default values to the properties
            var pancake = new Pancake();
            pancake.flour = 1.25 ;
            pancake.salt = 0.25 ;
            pancake.milk = 0.25 ;
            pancake.eggs = 1.5 ;
            pancake.portions = 1;

            return View(pancake);

           
        }

        [HttpPost]
        public ActionResult Converter(string degreeValue, bool fToC)
        {
            //Use the farenheit to celcius formula or vice versa depending on the vlaue of the checkbox
            double result  = 0;
            if(fToC == true)
            {
                result = Int32.Parse(degreeValue) - 32 * 0.5556;
            }
            else { 
            result = Int32.Parse(degreeValue) * 1.8 + 32;
            }
            //Store the data in a view data variable
            ViewData["temperature"] = result;
            return View();
        }

        [HttpPost]
        public ActionResult Pancake(double amountValue)
        {
            //Multiply the default values by the amount of portions

            var pancake = new Pancake();

                pancake.flour = 1.25 * amountValue;
                pancake.salt = 0.25 * amountValue;
                pancake.milk = 0.25 * amountValue;
                pancake.eggs = 1.5 * amountValue;
                pancake.portions = amountValue;

                return View(pancake);
           
            
        }
 
        public ActionResult _Menu()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Todo(string itemValue)
        {
            //Add the new item to the list, serialise it and save it to session
            List<string> items = List.Item;

            items.Add(itemValue);

            var json = JsonSerializer.Serialize(items);
            HttpContext.Session.SetString("items", json);

            ViewBag.item = items;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
