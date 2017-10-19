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
        [DisplayName("Write a Message")]
        [Required(ErrorMessage = "Required")]
        public string title
        {
            get;
            set;
        }

        [DisplayName("Your Message")]
        [Required(ErrorMessage = "Required")]
        public string message
        {
            get;
            set;
        }

        [DisplayName("Send To")]
        [Required(ErrorMessage = "Required")]
        public string sendTo
        {
            get;
            set;
        }

        [DisplayName("First Name Label")]
        [Required(ErrorMessage = "Required")]
        public string labeltoFirstName
        {
            get;
            set;
        }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Required")]
        public string toFirstName
        {
            get;
            set;
        }

        [DisplayName("Last Name Label")]
        [Required(ErrorMessage = "Required")]
        public string labeltoLastName
        {
            get;
            set;
        }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Required")]
        public string toLastName
        {
            get;
            set;
        }

        [DisplayName("Email Label")]
        [Required(ErrorMessage = "Required")]
        public string labeltoEmail
        {
            get;
            set;
        }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string toEmail
        {
            get;
            set;
        }

        [DisplayName("Sent From")]
        [Required(ErrorMessage = "Required")]
        public string sentFrom
        {
            get;
            set;
        }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Required")]
        public string fromFirstName
        {
            get;
            set;
        }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Required")]
        public string fromLastName
        {
            get;
            set;
        }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Required")]
        public string fromEmail
        {
            get;
            set;
        }

        [DisplayName("Terms and Conditions")]
        [Required(ErrorMessage = "Required")]
        public string agree
        {
            get;
            set;
        }

    }
}
