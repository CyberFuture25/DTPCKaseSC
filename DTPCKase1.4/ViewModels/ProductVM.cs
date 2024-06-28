using DTPCKase1._4.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DTPCKase1._4.ViewModels
{
    public class ProductVM
    {
        public Producto? Producto { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoriaList { get; set; }
        
    }
}
