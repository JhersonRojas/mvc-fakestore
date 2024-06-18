using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_fakestore.Models;

public class Productos
{
    [Key]
    public Guid IdProducto { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(150)]
    public required string Nombre { get; set; }

    //este  nos especifica si es activo o inactivo
    [Required(ErrorMessage = "El campo Estado es requerido.")]
    [RegularExpression(
        "Activo|Inactivo",
        ErrorMessage = "El estado debe ser 'Activo' o 'Inactivo'."
    )]
    public required string Estado { get; set; }

    [Required(ErrorMessage = "El nombre de la cantidad es requerido.")]
    [StringLength(10)]
    public required string Cantidad { get; set; }

    [Required(ErrorMessage = "El nombre del precio es rquerido.")]
    [StringLength(10)]
    public required int Precio { get; set; }

    [Required]
    public required DateTime Creado { get; set; }

    [StringLength(100)]
    public DateTime? Actualizado { get; set; }

    [Required(ErrorMessage = "la descripcion es requerida.")]
    [StringLength(500)]
    public required string Descripcion { get; set; }

    [ForeignKey("IdCategoria")]
    public required int FkCategoria { get; set; }
    public required Categorias Categorias { get; set; }

    [ForeignKey("IdProveedor")]
    public required int FkProveedor { get; set; }
    public required Proveedores Proveedores { get; set; }

    // Propiedad de navegación para las ventas
    public required ICollection<Ventas> Ventas { get; set; }
}
