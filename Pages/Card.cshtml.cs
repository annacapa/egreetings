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
    public class CardModel : PageModel
    {

        // BRIDGE TO GREETTINGS MODEL
        [BindProperty]
        public greetings bridgegreetings { get; set; }

        // DB-RELATED: CONNECT MY DATABASE TOT THIS MODEL
        private DbBuilder _myDB;
        public CardModel(DbBuilder myDB)
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

                var toName = bridgegreetings.toFirstName + " " + bridgegreetings.toLastName;
                var fromName = bridgegreetings.fromFirstName + " " + bridgegreetings.fromLastName;



                try
                {
                    // SEND
                    MailMessage Mailer = new MailMessage();

                    Mailer.To.Add(new MailAddress(bridgegreetings.toEmail, toName));
                    Mailer.Subject = bridgegreetings.title;
                    Mailer.Body = bridgegreetings.message;
                    Mailer.From = new MailAddress(bridgegreetings.fromEmail, fromName);

                    Mailer.IsBodyHtml = true;

                    using (SmtpClient smtpServer = new SmtpClient())
                    {
                        smtpServer.EnableSsl = true;
                        smtpServer.Host = "smtp.wowoco.org"; //CHANGE
                        smtpServer.Port = 25; //CHANGE
                        smtpServer.UseDefaultCredentials = false;
                        smtpServer.Send(Mailer);
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
                    Message = "Sorry, but you're lost!";
                }
            }

            return Page();
        }


    }
}

