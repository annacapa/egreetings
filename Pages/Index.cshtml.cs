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
    public class IndexModel : PageModel
    {
        // DEFAULT MODE
        public void OnGet()
        {          
        }

        // PREVIEW MODE (AFTER SUBMITTING)
        public async Task<IActionResult> OnPost()
        {
            // isPreviewPage = true;

            if (await isValid())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        // DB-RELATED: CUSTOMIZE VALUES TO BE ADDED TO THE DB
                        bridgegreetings.createDate = DateTime.Now.ToString();
                        bridgegreetings.createIP = this.HttpContext.Connection.RemoteIpAddress.ToString();
                        bridgegreetings.fromEmail = bridgegreetings.fromEmail.ToLower();
                        bridgegreetings.toEmail = bridgegreetings.toEmail.ToLower();
                        bridgegreetings.agree = "true";
                        bridgegreetings.message = bridgegreetings.message.ToLower();
                        bridgegreetings.message = bridgegreetings.message.Replace("fuck", "luck");

                        //DB-RELATED: ADD NEW RECORD TO THE DATABASE
                        _myDB.greetings.Add(bridgegreetings);
                        _myDB.SaveChanges();

                        // DB-RELATED: SEND USER TO THE PREVIEW PAGE SHOWING THE NEW RECORD
                        return RedirectToPage("Preview", new { id = bridgegreetings.ID });
                    }
                    catch { }
                }
            }
            else
            {
                ModelState.AddModelError("bridgegreetings.reCaptcha", "Bawaaahaha!");
            }

            return Page();
        }

        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public greetings bridgegreetings { get; set; }

        // HEY, CONNECT MY DATABASE TO THIS MODEL
        private DbBuilder _myDB;
        public IndexModel(DbBuilder myDB)
        {
            _myDB = myDB;
        }


        // TEST IF USER IS LOOKING AT PREVIEW OR FORM
        public bool isPreviewPage { get; set; }


        // RE-CAPTCHA VALIDATION
        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    values.Add("secret", "6LeXTDYUAAAAAJ7Q3oE41YCIZfaCnVAQbwlzQ3gC");
                    values.Add("response", response);
                    //values.Add("remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString());

                    var query = new FormUrlEncodedContent(values);


                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch { }


            return false;
        }



    }
}
