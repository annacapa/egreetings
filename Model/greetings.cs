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

        // ADD A UNIQUE IDENTIFIER
        [Key]
        public int? ID { get; set; }

        [DisplayName("Send To")]
        [Required(ErrorMessage = "Required")]
        public string sendTo { get; set; }

        [DisplayName("First Name")]
        [Display(Prompt = "Name")]
        [Required(ErrorMessage = "Required")]
        public string toFirstName { get; set; }

        [DisplayName("Last Name")]
        [Display(Prompt = "Last Name")]

        public string toLastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string toEmail { get; set; }

        [DisplayName("Sent From")]
        [Required(ErrorMessage = "Required")]
        public string sentFrom { get; set; }

        [DisplayName("F Name")]
        [Display(Prompt = "Name")]
        [Required(ErrorMessage = "Required")]
        public string fromFirstName { get; set; }

        [DisplayName("Last Name")]

        public string fromLastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string fromEmail { get; set; }
       
        [DisplayName("Title and Message")]
        [Display(Prompt = "Enter scary title")]
        [Required(ErrorMessage = "Required")]
        public string title { get; set; }

        [DisplayName("Message")]
        [Display(Prompt = "Write your scary message")]
        [Required(ErrorMessage = "Required")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Enter between 3 and 150 characters.")]
        public string message { get; set; }

        [DisplayName("Terms and Conditions")]
        public string agree { get; set; }

        public string createDate { get; set; }
        public string createIP { get; set; }

        public string sendDate { get; set; }
        public string sendIP { get; set; }

        public string reCaptcha { get; set; }

    }
}
