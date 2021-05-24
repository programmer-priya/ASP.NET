using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoApp.Models
{
    public class User
    {
        [Required(ErrorMessage = " Name is compulsory field")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = " Email is compulsory field")]
        public string Email { get; set; }

        [Required(ErrorMessage = " MobileNo is compulsory field")]
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Enter ten digit number")]
        public int MobileNo{ get; set; }
        [Required(ErrorMessage = "Please specify wheather you will attend")]
        [Display(Name = "WillAttend")]
        public string WillAttend { get; set; }


    }

   
}
