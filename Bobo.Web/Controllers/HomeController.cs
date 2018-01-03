using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bobo.Web.Models;
using bobo.IService;
using bobo.entity;
using AutofacDemo.Codes;

namespace Bobo.Web.Controllers
{

    public class HomeController : Controller
    {
        public ICategoryService cate;
        public IUserManager User;

        public HomeController(ICategoryService _cate,IUserManager _User)
        {
            cate = _cate;
            User = _User;
        }

        public IActionResult Index()
        {
           // string a = User.Register("hello");
            string t = User.Register("hello");

            Category cateModel = new Category();
            cateModel.Title = "前端";
            cateModel.CallIndex = "fe";
            cate.Add(cateModel);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
