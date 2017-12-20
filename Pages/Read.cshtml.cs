using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class ReadModel : PageModel
    {

        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public greetings bridgegreetings { get; set; }

        // DB-RELATED: CONNECT MY DATABASE TOT THIS MODEL
        private DbBuilder _myDB;
        public ReadModel(DbBuilder myDB)
        {
            _myDB = myDB;
        }

        public IActionResult OnGet(int ID = 0)
        {
            if (ID > 0)
            {
                bridgegreetings = _myDB.greetings.Find(ID);
            }
            if (bridgegreetings == null)
            {
                return RedirectToPage("Index");

            }

            return Page();

        }

    }
}

