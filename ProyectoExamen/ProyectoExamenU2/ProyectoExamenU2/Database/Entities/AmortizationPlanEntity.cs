using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamenU2.Database.Entities;

[Table("amortization_plans", Schema = "dbo")]
public class AmortizationPlanEntity : BaseEntity
{
    //No. de cuota: Consecutivo que indica el número de cuota a ser pagada.
    [Range(1, int.MaxValue)]
    [Column("installment_number")]
    public int InstallmentNumber { get; set; }

    //Fecha: Fecha establecida para el pago de cada cuota mensual. o Fecha de primer pago: Fecha en que el cliente debe realizar su primer pago.
    [Column("payment_date")]
    public DateTime PaymentDate { get; set; }

    //Días: Días exactos transcurridos desde la fecha de pago del mes anterior hasta la fecha de pago del siguiente mes.
    [Range(1, 31)]
    [Column("day")]
    public int Day { get; set; }

    //Interés: Monto de interés a pagar en cada mes.
    [Range(1, double.MaxValue)]
    [Column("interest")]
    public double Interest { get; set; }

    //Principal: Monto que se abono cada mes al saldo de principal.
    [Range(1, double.MaxValue)]
    [Column("principal")]
    public double Principal { get; set; }

    //Cuota nivelada (sin SVSD): Suma de interés más principal a pagar por el cliente mensualmente y a la cual hay que adicionar el seguro de vida
    [Range(1, double.MaxValue)]
    [Column("level_payment_without_SVSD")]
    public double LevelPaymentWithoutSVSD { get; set; }

    //Cuota con SVSD: Suma de interés, principal y SVSD.
    [Range(1, double.MaxValue)]
    [Column("level_payment_with_SVSD")]
    public double LevelPaymentWithSVSD { get; set; }

    //Saldo de principal: Monto del préstamo sin intereses que está pendiente de pago.
    [Range(1, double.MaxValue)]
    [Column("principal_balance")]
    public double PrincipalBalance { get; set; }

    [Column("loan_id")]
    public Guid LoanId { get; set; }

    [ForeignKey(nameof(LoanId))]
    public virtual LoanEntity Loan { get; set; }
}
