using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgCmsPad.Infrastructure;
using DgCmsPad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DgCmsPad.Controllers
{
    public class PostsController : Controller
    {

        private readonly DgCmsPadContext context;
        public PostsController(DgCmsPadContext context)
        {
            this.context = context;

        }

      
        public async Task<IActionResult> Index(int p=1)
        {
            int pageSize = 1;
            var posts = context.Posts.OrderByDescending(x => x.Id).Skip((p - 1) * pageSize).Take(pageSize);
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Posts.Count() / pageSize);
            return View(await posts.ToListAsync());
        }

        //get/posts/term
        public async Task<IActionResult> PostsByTerm(string categorySlug,int p = 1)
        {
            Term term =await context.Terms.Where(x => x.Slug == categorySlug).FirstOrDefaultAsync();
            if (term == null) return RedirectToAction("Index");

            int pageSize = 6;
            var posts = context.Posts.OrderByDescending(x => x.Id).Where(x=>x.PostTypeId ==term.Id).Skip((p - 1) * pageSize).Take(pageSize);
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Posts.Where(x => x.PostTypeId == term.Id).Count() / pageSize);
            ViewBag.CategoryName = term.Name;
            return View(await posts.ToListAsync());
        }
    }
}
