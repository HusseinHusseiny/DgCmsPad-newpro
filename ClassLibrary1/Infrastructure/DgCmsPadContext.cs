using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgCmsPad.Models;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.EntityFrameworkCore;

namespace DgCmsPad.Infrastructure
{
    public class DgCmsPadContext : DbContext
    {
        public DgCmsPadContext(DbContextOptions<DgCmsPadContext> options)
            : base(options)
        {

        }
        public DbSet<Taxonomy> Taxonomies { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Post> Posts { get; set; }


        


        public DbSet<PType> PTypes { get; set; }

       // public DbSet<PostType> PostTypes { get; set; }
        //page 463
    }
}
