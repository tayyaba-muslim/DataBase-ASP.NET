using System.ComponentModel.DataAnnotations;

namespace _2301B2TempEmbedding.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name{ get; set; }
        //[EmailAddress]
        [RegularExpression("^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$")]
        public string Description{ get; set; }
        [Required]
        // [DataType(DataType.PhoneNumber)]
        public int Price{ get; set; }
        [Required]
        public int Qty{ get; set; }
        [Required]
        public string Image{ get; set; }

    }
}
