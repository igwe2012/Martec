using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Martec.Web.Models
{
    public class CreateProductViewModel : Model
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
        private DateTime? _createdDate;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.Now; }
            set { _createdDate = value; }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(ProductName == null)
            {
                yield return new ValidationResult("Product name Required", new[] { nameof(ProductName) });
            }
            
        }
    }
}