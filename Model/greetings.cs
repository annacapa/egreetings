using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace halloween.Model
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class greetings

    { 
        
        [DisplayName("Scary card title goes here")]
        [Required(ErrorMessage = "Required")]
        public string title { get; set; }

        [DisplayName("Say something scary here...boo!")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Enter between 3 and 100 characters.")]
        public string message { get; set; }

        [DisplayName("Send To Testing 1 2 3")]
        [Required(ErrorMessage = "Required")]
        public string sendTo { get; set; }

        [DisplayName("First Name")]
        [Display(Prompt = "Enter First Name")]
        [Required(ErrorMessage = "Required")]
        public string toFirstName { get; set; }

        [DisplayName("Last Name")]
        [Display(Prompt = "Enter Last Name")]
        [Required(ErrorMessage = "Required")]
        public string toLastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string toEmail { get; set; }

        [DisplayName("Sent From Test")]
        [Required(ErrorMessage = "Required")]
        public string sentFrom { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Required")]
        public string fromFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Required")]
        public string fromLastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string fromEmail { get; set; }

        [DisplayName("Terms and Conditions")]
        [Required(ErrorMessage = "Required")]
        public string agree { get; set; }

    }
}
