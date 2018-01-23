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
    public class PreviewModel : PageModel
    {

        // BRIDGE TO GREETINGS MODEL
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

        // EMAIL-RELATED
        public string Message { get; set; }
        public IActionResult OnPost(int id = 0)
        {
            if (id > 0)
            {
                bridgegreetings = _myDB.greetings.Find(id);



                var toName = bridgegreetings.toName;
                var fromName = bridgegreetings.fromName;



                try
                {
                    // SEND
                    MailMessage Mailer = new MailMessage();

                    Mailer.To.Add(new MailAddress(bridgegreetings.toEmail, bridgegreetings.toName));
                    Mailer.Subject = bridgegreetings.title;
                    // Mailer.Body = bridgegreetings.message;
                    Mailer.From = new MailAddress(bridgegreetings.fromEmail, bridgegreetings.fromName);

                    Mailer.IsBodyHtml = true;

                    Mailer.Body = bridgegreetings.fromName + "has a greeting for you" + "Visit http://anacapa.wowoco.org/read/" + bridgegreetings.ID;

                    using (SmtpClient client = new SmtpClient())
                    {

                        client.EnableSsl = false;
                        client.UseDefaultCredentials = false;
                        // client.Credentials = new System.Net.NetworkCredential("[gmail email]", "[gmail password]");
                        client.Host = "";
                        client.Port = 2525;
                        client.Send(Mailer);


                    }

                    // DB-RELATED: CUSTOMIZE VALUES TO BE ADDED TO THE DB
                    bridgegreetings.sendDate = DateTime.Now.ToString();
                    bridgegreetings.sendIP = this.HttpContext.Connection.RemoteIpAddress.ToString();

                    // DB-RELATED: UPDATE RECORD ON THE DB
                    _myDB.greetings.Update(bridgegreetings);
                    _myDB.SaveChanges();


                    return RedirectToPage("Complete");

                }
                catch
                {
                    Message = "error msg";
                }
            }

            return Page();
        }


    }
}

