using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Martec.Domain.Models
{
    public class ProductModel : Model
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public decimal UnitPrice { get; set; }
      
        public string Image { get; set; }
       

        public DateTime CreatedDate { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<ImageModel> Images { get; set; } = new HashSet<ImageModel>();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(UnitPrice < 0)
            {
                yield return new ValidationResult("the price cannot be less than 0", new[] { nameof(UnitPrice) });
            }
           
        }
    }
}
