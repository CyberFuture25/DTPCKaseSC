using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTPCKase1._4.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        [ValidateNever]
        public Producto Producto { get; set; }
        [Range(1, 1000, ErrorMessage = "Ingrese un valor entre 1 y 1000")]
        public int Count { get; set; }
       
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public bool IsDeleted { get; set; } = false;


    }
}
