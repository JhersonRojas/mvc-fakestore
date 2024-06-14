using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_fakestore.Models;

public class Ventas
{
    [Key]
    public int IdVenta { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(20)]
    public required string Cantidad { get; set; }

    [Required(ErrorMessage = "El Total es obligatorio")]
    [StringLength(20)]
    public required string Total { get; set; }

    [Required]
    public DateTime Creado { get; set; }

    [ForeignKey("Productos")]
    public int Productos { get; set; }
    public required Productos Producto { get; set; }


    [ForeignKey("Usuario")]
    public int FkUsuario { get; set; }
    public required Usuarios Usuarios { get; set; }

}
