using ClaimsIdentity.Models;
using ClaimsIdentity.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsIdentity.Pages
{
    [Authorize]

  
    public class OstatnioSzukane : PageModel
    {
        public Person Person { get; set; }
        public IList<Person> People { get; set; }
        private PeopleContext _context { get; set; }

        public OstatnioSzukane(PeopleContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            if (People != null)
                _context.Person.Add(Person);
            People = _context.Person.OrderByDescending(e => e.data).Take(3).ToList();
        }

    }
}
