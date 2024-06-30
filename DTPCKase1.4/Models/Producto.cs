using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTPCKase1._4.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? nom_prod { get; set; }
        public string? desc_prod { get; set; }
        public int stck_prod { get; set; }
        [Required]
        [Display(Name = "Precio")]
        [Range(1, 2000)]
        public double prec_prod { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        [ValidateNever]
        public Categoria? Categoria { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}
