using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class PreviewModel : PageModel
    {

        // BRIDGE TO GREETTINGS MODEL
        [BindProperty]
        public greetings bridgegreetings { get; set; }

        // DB-RELATED: CONNECT MY DATABASE TOT THIS MODEL
        private DbBuilder _myDB;
        public PreviewModel(DbBuilder myDB)
        {
            _myDB = myDB;
        }

        public void OnGet(int ID = 0)
        {
            if (ID > 0)
            {
                bridgegreetings = _myDB.greetings.Find(ID);
            }
        }
    }
}

