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
        
        [DisplayName("Title Test")]
        [Display(Prompt = "Enter scary title")]
        [Required(ErrorMessage = "Required")]
        public string title { get; set; }

        [DisplayName("Message")]
        [Display(Prompt = "Write your scary message")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Enter between 3 and 100 characters.")]
        public string message { get; set; }

        [DisplayName("Send To")]
        [Required(ErrorMessage = "Required")]
        public string sendTo { get; set; }

        [DisplayName("First Name")]
        [Display(Prompt = "First Name")]
        [Required(ErrorMessage = "Required")]
        public string toFirstName { get; set; }

        [DisplayName("Last Name")]
        [Display(Prompt = "Last Name")]
        [Required(ErrorMessage = "Required")]
        public string toLastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string toEmail { get; set; }

        [DisplayName("Sent From")]
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
