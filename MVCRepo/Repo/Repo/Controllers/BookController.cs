﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
 
using Repo.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace Repo.Controllers
{
    public class BookController : Controller
    {
        private IRepository<Author> repoAuthor;
        private IRepository<Book> repoBook;
        public BookController(IRepository<Author> repoAuthor, IRepository<Book> repoBook)
        {
            this.repoAuthor = repoAuthor;
            this.repoBook = repoBook;
        }

        public IActionResult Index()
        {
            List<BookListingViewModel> model = new List<BookListingViewModel>();
            repoBook.GetAll().ToList().ForEach(b =>
            {
                BookListingViewModel book = new BookListingViewModel
                {
                    Id = b.Id,
                    BookName = b.Name,
                    Publisher = b.Publisher,
                    ISBN=b.ISBN
                };
                Author author = repoAuthor.Get(b.AuthorId);
                book.AuthorName = $"{author.FirstName} {author.LastName}";
                model.Add(book);
            });
            return View("Index", model);
        }

        public PartialViewResult EditBook(int id)
        {
            EditBookViewModel model = new EditBookViewModel();
            model.Authors = repoAuthor.GetAll().Select(a => new SelectListItem
            {
                Text = $"{a.FirstName} {a.LastName}",
                Value = a.Id.ToString()
            }).ToList();
            Book book = repoBook.Get(id);
            if(book != null)
            {
                model.BookName = book.Name;
                model.ISBN = book.ISBN;
                model.Publisher = book.Publisher;
                model.AuthorId = book.AuthorId;
            }
            return PartialView("_EditBook",model);
        }
        [HttpPost]
        public ActionResult EditBook(int id, EditBookViewModel model)
        {
            Book book = repoBook.Get(id);
            if (book != null)
            {
                book.Name = model.BookName;
                book.ISBN = model.ISBN;
                book.Publisher = model.Publisher;
                book.AuthorId = model.AuthorId;
                book.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                book.ModifiedDate = DateTime.UtcNow;
                repoBook.Update(book);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public PartialViewResult DeleteBook(int id)
        {
            Book book = repoBook.Get(id);            
            return PartialView("_DeleteBook",book?.Name);
        }
        [HttpPost]
        public ActionResult DeleteBook(int id, FormCollection form)
        {
            Book book = repoBook.Get(id);
            if(book != null)
            {
                repoBook.Delete(book);
            }            
            return RedirectToAction("Index");
        }

    }
}
