using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Models
{
    public abstract class Model : IValidatableObject
    {
        
        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null));
        }
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
