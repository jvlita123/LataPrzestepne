using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClaimsIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClaimsIdentity.Pages.People
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ClaimsIdentity.Models.PeopleContext _context;

        public IndexModel(ClaimsIdentity.Models.PeopleContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGet()
        {
            Person =  _context.Person.OrderByDescending(e => e.data).Take(20).ToList();
        }

    }
}
