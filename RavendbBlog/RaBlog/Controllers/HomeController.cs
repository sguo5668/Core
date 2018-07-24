using System;
using System.Collections.Generic;
using System.Data;
 
using System.Linq;
 
using Microsoft.AspNetCore.Mvc;
using RaBlog.Domain.Model;
using RaBlog.Models;
using Raven.Client;
 
namespace RaBlog.Controllers
{

    public class HomeController : Controller
    {

		public new IDocumentSession Session { get; set; }

		private readonly IDocumentStore _store;

		public HomeController(IDocumentStoreHolder documentStoreHolder)
		{
			_store = documentStoreHolder.Store;

			Session = _store.OpenSession();

		}


		public ActionResult Index()
		{
			return View(Session.Query<Blog>().ToList());
		}
		//
		// GET: /Home/Details/5

		public ViewResult Details(int id)
		{
			Blog blog = Session.Load<Blog>(id);
			return View(blog);
		}

		//
		// POST: /Home/Details
		[HttpPost]
		public ActionResult Details(Comment comment)
		{
			Blog blog = Session.Load<Blog>(comment.BlogId);
			if (blog.Comments == null)
			{
				blog.Comments = new List<Comment>();
			}
			blog.Comments.Add(comment);

			Session.Store(blog);
			return RedirectToAction("Details", comment.BlogId);
		}

		//
		// GET: /Home/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Home/Create

		[HttpPost]
		public ActionResult Create(Blog blog)
		{
			if (ModelState.IsValid)
			{
				Session.Store(blog);
				return RedirectToAction("Index");
			}

			return View(blog);
		}

		//
		// GET: /Home/Edit/5

		public ActionResult Edit(int id)
		{
			Blog blog = Session.Load<Blog>(id);
			return View(blog);
		}

		//
		// POST: /Home/Edit/5

		[HttpPost]
		public ActionResult Edit(Blog blog)
		{
			if (ModelState.IsValid)
			{
				Blog currentBlog = Session.Load<Blog>(blog.Id);
				currentBlog.Title = blog.Title;
				currentBlog.Content = blog.Content;
				Session.Store(currentBlog);
				return RedirectToAction("Index");
			}
			return View(blog);
		}

		//
		// GET: /Home/Delete/5

		public ActionResult Delete(int id)
		{
			Blog blog = Session.Load<Blog>(id);
			return View(blog);
		}

		//
		// POST: /Home/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Session.Delete<Blog>(Session.Load<Blog>(id));
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		//
		// GET: /About

		public ActionResult About()
		{
			return View();
		}

	}
}