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
        public string sendTo { get; set; }

        [DisplayName("To Name")]
        [Required(ErrorMessage = "Required")]
        public string toName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string toEmail { get; set; }

        [DisplayName("Title")]
        [Display(Prompt = "Enter scary title")]
        [Required(ErrorMessage = "Required")]
        public string title { get; set; }

        [DisplayName("Message")]
        [Display(Prompt = "Write your scary message")]
        [Required(ErrorMessage = "Required")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Enter between 3 and 150 characters.")]
        public string message { get; set; }

        [DisplayName("Sent From")]
        public string sentFrom { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("From Name")]

        public string fromName { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Email")]

        public string fromEmail { get; set; }
 
        [DisplayName("I agree")]
        public string agree { get; set; }

        public string createDate { get; set; }
        public string createIP { get; set; }

        public string sendDate { get; set; }
        public string sendIP { get; set; }

        public string reCaptcha { get; set; }
        
    }
}