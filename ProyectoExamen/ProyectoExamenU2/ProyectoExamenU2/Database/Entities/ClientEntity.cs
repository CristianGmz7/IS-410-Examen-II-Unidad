using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoExamenU2.Database.Entities;

[Table("clients", Schema = "dbo")]
public class ClientEntity : BaseEntity
{
    [StringLength(100)]
    [Required]
    [Column("name")]
    public string Name { get; set; }

    [RegularExpression("^[0-9]{13}$")]
    [Required]
    [Column("identity")]
    public int Identity { get; set; }
}
