using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClaimsIdentity.Models;

namespace ClaimsIdentity.Pages.People
{
    public class DeleteModel : PageModel
    {
        private readonly ClaimsIdentity.Models.PeopleContext _context;

        public DeleteModel(ClaimsIdentity.Models.PeopleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            if (Person == null)
            {
                return NotFound();
            }
            if(Person.email != User.Identity.Name)
            {
                return NotFound();

            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FindAsync(id);

            if (Person != null && Person.email == User.Identity.Name)
            {
                _context.Person.Remove(Person);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
