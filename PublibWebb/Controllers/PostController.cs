using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgCmsPad.Infrastructure;
using DgCmsPad.Models;
using Microsoft.AspNetCore.Mvc;
using Polly;

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


        public IActionResult Index()
        {


            // return View(await context.Posts.OrderByDescending(x => x.Id).Include(x => x.Term).ToListAsync());
            var posts = context.Posts.OrderByDescending(x => x.Id);
            
            return View(posts.ToList());


        }


        public  IActionResult Details(int id)
        {
            Post post = context.Posts.Include(x => x.PostTypeId).FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }



    }
}
