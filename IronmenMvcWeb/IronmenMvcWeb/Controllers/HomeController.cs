using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IronmenMvcWeb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IronmenMvcWeb.Controllers
{
    public class CustomModelBInder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var values = bindingContext.ValueProvider.GetValue("abc");

            //var value = Int32.Parse(values.FirstValue);
            //if (values > 10)
            bindingContext.Result = ModelBindingResult.Success(values + "10");
            //else
            //    bindingContext.Result = ModelBindingResult.Success(values + "100");

            return Task.CompletedTask;
        }
    }
    [Route("MyHome/[Action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            /*ViewData["Message"] = "Your application description page HiHi.";
            ViewBag['haha'] = "這個是ViewBag";
            Pokemon[] pokemon = new Pokemon[2];
            pokemon[0] = new Pokemon()
            {
                Id = 1,
                Name = "水箭龜",
                Property = "水系"
            };

            pokemon[1] = new Pokemon()
            {
                Id = 2,
                Name = "小火龍",
                Property = "火系"
            };
            Test[] test = new Test[2];
            test[0] = new Test() { ID = 1 };
            test[1] = new Test() { ID = 2 };*/

            var items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "火系",
                    Value = "火系"
                },
                    new SelectListItem()
                {
                    Text = "水系",
                    Value = "水系"
                },
                    new SelectListItem()
                {
                    Text = "草系",
                    Value = "草系"
                }
            };
            ViewData["items"] = items;

            return View(items);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("SubContact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        [HttpPost]
        public IActionResult Hello(Pokemon pokemon)
        {
            
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
