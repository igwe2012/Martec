using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Models
{
    public class CategoryModel : Model
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }


        public virtual ICollection<ProductModel> Products { get; set; } = new HashSet<ProductModel>();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategoryId < 0)
            {
                yield return new ValidationResult("invalid Id", new[] { nameof(CategoryId) });
            }
        }
    }
}
