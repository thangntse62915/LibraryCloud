using LibraryCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;


namespace LibraryCloud.Controllers
{
    public class UserController : Controller
    {
        public static string URL = Data.URL;
    
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
      
        
    }
}