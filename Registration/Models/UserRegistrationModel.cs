﻿using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class UserRegistrationModel
    {
        public int Id { get; set; }
        [Display(Name ="Имя")]
        [Required(ErrorMessage ="Please Enter Your Name")]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name ="Email-Address")]
        [UIHint("EmailAddress")]
        [EmailAddress]
        [Required(ErrorMessage ="Please Enter Your Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [UIHint("Password")]
        [Required(ErrorMessage ="Please Enter Your Password")]
        [Compare("ConfirmPassword",ErrorMessage ="The entered password does not match")]
        [StringLength(16,MinimumLength =6, ErrorMessage ="Your password does not fail within the range of 6 to 16 characters")]
        public string Password { get; set; }

        [Display(Name ="Confirm-Password")]
        [UIHint("Password")]
        [Required(ErrorMessage ="Please enter your password")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Your password does not fail within the range of 6 to 16 characters")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Age")]
        [Range(17,70,ErrorMessage ="Your Age must be from 17 to 70")]
        public int? Age { get; set; }

        [Display(Name ="Do ouy agree with the terms of the agreement?")]
        [Required(ErrorMessage = "Tap on checkbox")]
        public bool IsAgree { get; set; }
    }
}
