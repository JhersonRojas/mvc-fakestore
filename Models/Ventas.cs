using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_fakestore.Models;

public class Ventas
{
    [Key]
    public Guid IdVenta { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(20)]
    public required string Cantidad { get; set; }

    [Required(ErrorMessage = "El Total es obligatorio")]
    [StringLength(20)]
    public required string Total { get; set; }

    [Required]
    public required DateTime Creado { get; set; }

    public DateTime? Actualizado { get; set; }

    [ForeignKey("Productos")]
    public Guid FkProducto { get; set; }
    public required Productos Productos { get; set; }

    [ForeignKey("Usuario")]
    public Guid FkUsuario { get; set; }
    public required Usuarios Usuarios { get; set; }
}
