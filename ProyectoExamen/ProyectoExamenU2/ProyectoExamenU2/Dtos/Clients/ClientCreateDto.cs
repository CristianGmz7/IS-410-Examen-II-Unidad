using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU2.Dtos.Clients;

public class ClientCreateDto
{
    [Display(Name = "nombre")]
    [StringLength(100, ErrorMessage = "El {0} debe tener menos de {1} caracteres")]
    [Required(ErrorMessage = "El {0} es requerido")]
    public string Name { get; set; }

    [Display(Name = "identidad")]
    [RegularExpression("^[0-9]{9}$", ErrorMessage = "La {0} debe tener exactamente 9 dígitos.")]
    [Required(ErrorMessage = "La {0} es requerida")]
    public int Identity { get; set; }
    //antes estaba que 13 pero tiraba error por la cantidad de enteros
}
