using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 3;
        BookContext context = new BookContext();
        public ActionResult Index(string author,string category,int page=1)
        {
            ViewBag.Authors = context.Authors.ToList();
            ViewBag.Categories = context.Categories.ToList();
            if (author != null)
            {
                ViewModel model = new ViewModel { books = context.Books.Skip((page - 1) * pageSize).Take(pageSize).Where(x => x.Authors.Any(c => c.Surname == author)), PagingInfo
                return View(context.Books.Where(x => x.Authors.Any(c => c.Surname == author)));
            }
            if (category != null)
            {
                return View(context.Books.Where(x => x.Categories.Any(c => c.Name == category)));
            }

            return View(context.Books);
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
        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Books");
        }

        public ActionResult AuthorDetail(int id=0)
        {
          
            return View(context.Authors.First(x => x.AuthorId == id));
        }

        public ActionResult DownloadFile(int id=0)
        {
            Book book = context.Books.First(x => x.BookId == id);

            string filename = Server.MapPath(book.ContentPath);
            string contentType = "application/pdf";
            string downloadName = null;
           
            return File(filename, contentType, downloadName);
        }

    }
}