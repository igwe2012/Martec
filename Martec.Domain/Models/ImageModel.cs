using System.ComponentModel.DataAnnotations;

namespace Martec.Domain.Models
{
    public class ImageModel : Model
    {
        [Key]
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string URL { get; set; }

    }
}