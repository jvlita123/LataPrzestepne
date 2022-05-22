using ClaimsIdentity.Areas.Identity.Pages.Account;
using ClaimsIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ClaimsIdentity.Pages
{
    public class IndexModel : PageModel
    {
        // private readonly ILogger<IndexModel> _logger;

        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly PeopleContext _context;
    ////    private readonly UserManager<IdentityUser> _userManager;
    ////    private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _loggeruser;

        public IndexModel(ILogger<LoginModel> logger, PeopleContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _loggeruser = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }


        public IList<Person> People { get; set; }
        public void OnGet()
        {
            People = _context.Person.ToList();
        }

        [BindProperty]
        public Person Person { get; set; }
        public IActionResult OnPost()
        {
            People = _context.Person.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Person.email = User.Identity.Name;
           

            Person.data = System.DateTime.Now;

            _context.Person.Add(Person);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }


    }
}
