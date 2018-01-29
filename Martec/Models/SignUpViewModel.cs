using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Martec.Web.Models
{
    public class SignUpViewModel : Model
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string  Password { get; set; }
        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Password != ConfirmPassword)
            {
                yield return new ValidationResult("The Password does not match", new[] { nameof(Password) });
            }
        }
    }
}