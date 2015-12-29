using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookReader.Models;
using System.IO;

namespace BookReader.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Name,Year,ImagePath,ContentPath,Description,Rating,language,CreateTime")] Book book, int[] selectedAuthors, int[] selectedCategories, HttpPostedFileBase contentFile, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid && contentFile!=null && imageFile!=null)
            {
                string imageFileName = Path.GetFileName(imageFile.FileName);
                string imageExtension = Path.GetExtension(imageFile.FileName);
                List<string> imageExtensions = new List<string>() { ".jpg", ".png" };

                string contentFileName = Path.GetFileName(contentFile.FileName);
                string contentExtension = Path.GetExtension(contentFile.FileName);
                List<string> contentExtensions = new List<string>() { ".pdf", ".txt",".xml" };
                if (imageExtensions.Contains(imageExtension) && contentExtensions.Contains(contentExtension))
                {
                    imageFile.SaveAs(Server.MapPath("/Content/BookImage/" + imageFileName));
                    contentFile.SaveAs(Server.MapPath("/Content/Books/" + contentFileName));
                    ViewBag.Message = "Файл сохранен";
                }
                else
                {
                    ViewBag.Message = "Ошибка расширения файлов ";
                }
            if (selectedAuthors != null)
            {
               
                foreach (var c in db.Authors.Where(co => selectedAuthors.Contains(co.AuthorId)))
                {
                    book.Authors.Add(c);
                }
            }
                if (selectedCategories != null)
                {

                    foreach (var c in db.Categories.Where(co => selectedCategories.Contains(co.CategoryId)))
                    {
                        book.Categories.Add(c);
                    }
                }
                book.CreateTime = DateTime.Now;
                book.ImagePath = "/Content/BookImage/" + imageFileName;
                book.ContentPath = "/Content/Books/" + contentFileName;
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Categories = db.Categories.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Name,Year,ImagePath,ContentPath,Description,Rating,language,CreateTime")] Book book, int[] selectedAuthors, int[] selectedCategories, HttpPostedFileBase contentFile, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid && contentFile != null && imageFile != null)
            {
                string imageFileName = Path.GetFileName(imageFile.FileName);
                string imageExtension = Path.GetExtension(imageFile.FileName);
                List<string> imageExtensions = new List<string>() { ".jpg", ".png" };

                string contentFileName = Path.GetFileName(contentFile.FileName);
                string contentExtension = Path.GetExtension(contentFile.FileName);
                List<string> contentExtensions = new List<string>() { ".pdf", ".txt", ".xml" };
                if (imageExtensions.Contains(imageExtension) && contentExtensions.Contains(contentExtension))
                {
                    imageFile.SaveAs(Server.MapPath("/Content/BookImage/" + imageFileName));
                    contentFile.SaveAs(Server.MapPath("/Content/Books/" + contentFileName));
                    ViewBag.Message = "Файл сохранен";
                }
                else
                {
                    ViewBag.Message = "Ошибка расширения файлов ";
                }
                if (selectedAuthors != null)
                {

                    foreach (var c in db.Authors.Where(co => selectedAuthors.Contains(co.AuthorId)))
                    {
                        book.Authors.Add(c);
                    }
                }
                if (selectedCategories != null)
                {

                    foreach (var c in db.Categories.Where(co => selectedCategories.Contains(co.CategoryId)))
                    {
                        book.Categories.Add(c);
                    }
                }
                book.CreateTime = DateTime.Now;
                book.ImagePath = "/Content/BookImage/" + imageFileName;
                book.ContentPath = "/Content/Books/" + contentFileName;

                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid && contentFile == null && imageFile == null)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
