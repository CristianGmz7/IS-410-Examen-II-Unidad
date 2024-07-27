using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU2.Dtos.Loans;

public class LoanCreateDto
{
    [Display(Name = "Monto del prestamo")]
    [Range(1, double.MaxValue, ErrorMessage = "El {0} debe ser mayor o igual a 1")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    public double LoanAmount { get; set; }

    [Display(Name = "Porcentaje de comision")]
    [Range(1, 100, ErrorMessage = "El {0} debe estar entre {1} y {2} %")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    public double CommissionRate { get; set; }

    [Display(Name = "Tasa de interes anual (corriente)")]
    [Range(1, 100, ErrorMessage = "El {0} debe estar entre {1} y {2} %")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    public double InterestRate { get; set; }

    [Display(Name = "Plazo")]
    [Range(1, int.MaxValue, ErrorMessage = "El {0} debe ser mayor o igual a 1")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    public int Term { get; set; }

    [Display(Name = "Fecha de desembolso")]
    [Required(ErrorMessage = "La {0} es obligatorio")]
    public DateTime DisbursementDate { get; set; }

    [Display(Name = "Fecha de primer pago")]
    [Required(ErrorMessage = "La {0} es obligatorio")]
    public DateTime FirstPaymentDate { get; set; }

    [Display(Name = "Id")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    public Guid ClientId { get; set; }
}
