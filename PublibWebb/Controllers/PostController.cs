using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgCmsPad.Infrastructure;
using DgCmsPad.Models;
using Microsoft.AspNetCore.Mvc;
using Polly;
using ClassLibrary1;
using System.Data.Entity;

namespace PublicWebb.Controllers
{
    public class PostController : Controller
    {

        public PostController(DgCmsPadContext context)
        {
            this.context = context;
          
        }


        private readonly DgCmsPadContext context;


        public async Task<IActionResult> Index()
        {
            IQueryable<Post> posts = from p in context.Posts select p;
            List<Post> pageList = await posts.ToListAsync();
            return View(pageList);


         

        }


         public async Task<IActionResult> Details(int id)
        {
            Post post = await context.Posts.Include(x => x.PostTypeId).FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }



    }
}
