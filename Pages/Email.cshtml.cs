using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using halloween.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace halloween.Pages
{
    public class EmailModel : PageModel
    {
        

        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public greetings bridgegreetings { get; set; }

        // HEY, CONNECT MY DATABASE TO THIS MODEL
        private DbBuilder _myDB;
        public EmailModel(DbBuilder myDB)
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



        // DEFAULT MODE
        public void OnGet()
        {

        }


    }
}
