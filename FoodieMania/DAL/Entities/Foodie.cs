using System.ComponentModel.DataAnnotations;
using WebAPI.DAL.Entities;

namespace FoodieMania.DAL.Entities
{
    public class Foodie : AuditBase
    {
        [Display(Name = "Comida rapida")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Es campo {0} es obligatorio")]
        public string Name { get; set; }

    }
}
