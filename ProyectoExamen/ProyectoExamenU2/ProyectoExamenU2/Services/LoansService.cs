using AutoMapper;
using ProyectoExamenU2.Database;
using ProyectoExamenU2.Database.Entities;
using ProyectoExamenU2.Dtos.Common;
using ProyectoExamenU2.Dtos.Loans;
using ProyectoExamenU2.Services.Interfaces;
using System.Xml;

namespace ProyectoExamenU2.Services;

public class LoansService : ILoansService
{
    private readonly ProyectoExamenU2Context _context;
    private readonly IMapper _mapper;
    private readonly ILogger<LoansService> _logger;

    public LoansService(ProyectoExamenU2Context context, IMapper mapper, ILogger<LoansService> logger)
    {
        this._context = context;
        this._mapper = mapper;
        this._logger = logger;
    }

    //FALTA QUE IMPLEMENTAR LOGICA DEL LoanDto
    public async Task<ResponseDto<LoanDto>> CreateLoanAsync(LoanCreateDto dto)
    {
        using(var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                //verificar si el Usuario Existe
                var clientEntity = await _context.Clients.FindAsync(dto.ClientId);

                if (clientEntity == null)
                {
                    return new ResponseDto<LoanDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "El Cliente no existe"
                    };
                }
                //Añadir prestamo a la tabla Loans
                var loanEntity = _mapper.Map<LoanEntity>(dto);

                _context.Loans.Add(loanEntity);
                await _context.SaveChangesAsync();


                //Realizar el Plan de Amortizacion
                var amortizationPlan = new List<AmortizationPlanEntity> { };

                //variables que se usaran en el transcurso del llenado de AmortizationPlanEntity
                int numeroCuota;
                DateTime fechaInicioCuota;
                DateTime fechaProximaCuota;    //referencia
                int dias;
                double interes;
                double principal;
                double cuotaSinSVSD;
                double cuotaConSVSD;
                double saldoPrincipal;
                //variables que sirven solo los calculos respectivos
                double montoComision = dto.LoanAmount * dto.CommissionRate;
                double montoPrestamo = dto.LoanAmount + montoComision;
                double seguroDeVida = 0.0015;
                double tasaMensualIntereses = (dto.InterestRate/100)/dto.Term;
                for(int i = 1; i <= dto.Term; i++)
                {
                    numeroCuota = i;
                    if(i == 1)
                    {
                        fechaInicioCuota = dto.FirstPaymentDate;
                        fechaProximaCuota = fechaInicioCuota.AddMonths(1);
                        dias = (fechaProximaCuota.Subtract(fechaInicioCuota)).Days;
                        interes = (montoPrestamo*(dto.InterestRate/100))/(360*dias);
                        //cuotasinSVSD solo se modifica aqui porque es constante en las tablas
                    }


                    //al final de recorrer cada i añadir los datos calculados a un campo de amorzitationPlan
                }

                //Al final de aqui hacer un AddRange de amortizationPlan en la tabla correspondiente
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();

                _logger.LogError(e, "Error al crear el prestamo");

                return new ResponseDto<LoanDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = "Se produjo error al crear el prestamo"
                };
            }
        }

    }
}
