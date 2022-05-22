using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsIdentity.Models
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options)
        {
        }
        //public PeopleContext(DbContextOptions options) : base(options) { }

    }
}
