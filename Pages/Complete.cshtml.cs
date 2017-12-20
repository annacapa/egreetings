using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class CompleteModel : PageModel
    {
        private greetings bridgegreetings;

        public DbBuilder _myDB { get; private set; }

        public void OnGet(int ID = 0)
        {
            if (ID > 0)
            {
                bridgegreetings = _myDB.greetings.Find(ID);
            }

        }

    }
}