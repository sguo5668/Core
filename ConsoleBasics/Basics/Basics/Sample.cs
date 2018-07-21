﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics
{
    public class Sample
    {
        public static void Run()
        {
            using (var context = new BloggingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            #region Add
            using (var context = new BloggingContext())
            {
                var blog = new Blog { Url = "http://sample.com" };
                context.Blogs.Add(blog);
                context.SaveChanges();

                Console.WriteLine(blog.BlogId + ": " +  blog.Url);
            }
            #endregion

            #region Update
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.First();
                blog.Url = "http://sample.com/blog";
                context.SaveChanges();
            }
            #endregion

            #region Remove
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.First();
                context.Blogs.Remove(blog);
                context.SaveChanges();
            }
            #endregion

            #region MultipleOperations
            using (var context = new BloggingContext())
            {
                // seeding database
                context.Blogs.Add(new Blog { Url = "http://sample.com/blog" });
                context.Blogs.Add(new Blog { Url = "http://sample.com/another_blog" });
                context.SaveChanges();
            }

            using (var context = new BloggingContext())
            {
                // add
                context.Blogs.Add(new Blog { Url = "http://sample.com/blog_one" });
                context.Blogs.Add(new Blog { Url = "http://sample.com/blog_two" });

                // update
                var firstBlog = context.Blogs.First();
                firstBlog.Url = "";

                // remove
                var lastBlog = context.Blogs.Last();
                context.Blogs.Remove(lastBlog);

                context.SaveChanges();
            }
            #endregion
        }
    }
}
