using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CleanRazorUI.Models;


namespace CleanRazorUI.Pages.Forms
{
    public class AddAddressModel : PageModel
    {
        [BindProperty]
        public Address address { get; set; }
        public void OnGet()
        {
        }
    }
}
