using LibraryCloud.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryCloud.Controllers
{
    public class BookController : Controller
    {
        public static string URL = "http://library-on-cloud-2020.azurewebsites.net/";
        IEnumerable<BookViewModel> books = null;
        // GET: Book
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
 
                var responseTask =  await client.GetAsync("api/books");
                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsStringAsync().Result;
                    books = JsonConvert.DeserializeObject<IEnumerable<BookViewModel>>(readTask);
                }
                else
                {
                    books = Enumerable.Empty<BookViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            ViewBag.books = books;
            return View();
      
        }
        public ActionResult CreateBook(BookViewModel book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                var postTask = client.PostAsJsonAsync<BookViewModel>("book", book);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");


            return View();
        }
        public ActionResult DeleteBook(int id)
        {
            return View();
        }
        public ActionResult UpdateBook(BookViewModel book)
        {
            return View();

        }
        public ActionResult SearchBook(string searchValue)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                var responseTask = client.GetAsync("book/" + searchValue);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookViewModel>>();

                    readTask.Wait();

                    books = readTask.Result;
                }
                else
                {


                    books = Enumerable.Empty<BookViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(books);


        }
    }
}