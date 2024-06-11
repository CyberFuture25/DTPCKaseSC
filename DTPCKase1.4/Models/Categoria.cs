using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DTPCKase1._4.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Nombre Categoria")]
        public string? nom_categoria { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Este campo solo admite valores entre 1-100")]
        public int DisplayOrder { get; set; }
    }
}
