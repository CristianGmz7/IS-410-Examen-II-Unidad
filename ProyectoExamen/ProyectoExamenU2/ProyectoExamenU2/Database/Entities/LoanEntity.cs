using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamenU2.Database.Entities;

[Table("loans", Schema = "dbo")]
public class LoanEntity : BaseEntity
{
    //monto del préstamo
    [Range(1, double.MaxValue)]
    [Column("loan_amount")]
    public double LoanAmount { get; set; }

    //% de comisión: Porcentaje cobrado sobre el monto del préstamo.
    [Range(1, 100)]
    [Column("comission_rate")]
    public double CommissionRate { get; set; }

    //Tasa de interés corriente: Porcentaje anual cobrado por el dinero otorgado en préstamo.
    [Range(1, 100)]
    [Column("interest_rate")]
    public double InterestRate { get; set; }

    //Plazo: Tiempo en meses establecido para la duración del préstamo.
    [Range (1, int.MaxValue)]
    [Column("term")]
    public int Term { get; set; }

    //Fecha de desembolso: Fecha en que se desembolsan al cliente los fondos dados en préstamo.
    [Column("disbursement_date")]
    public DateTime DisbursementDate { get; set; }

    //Fecha de primer pago: Fecha en que el cliente debe realizar su primer pago.
    [Column("first_payment_day")]
    public DateTime FirstPaymentDate { get; set; }

    //Relacion con entidad clientes
    [Column("client_id")]
    public Guid ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public virtual ClientEntity Client { get; set; }

    //Relacion con las amortizaciones
    public IEnumerable<AmortizationPlanEntity> AmortizationPlans { get; set; }
}
