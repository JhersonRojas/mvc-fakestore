using System.ComponentModel.DataAnnotations;

namespace mvc_fakestore.Models;

public class Usuarios
{
    [Key]
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(20)]
    public required string Nombre { get; set; }

    [StringLength(20)]
    public string? Apellido { get; set; }

    //este  nos especifica si es activo o inactivo
    [Required(ErrorMessage = "El campo Estado es requerido.")]
    [RegularExpression(
        "Admin|Cliente|Vendedor",
        ErrorMessage = "El rol debe ser Admin,Cliente o Vendedor "
    )]
    public required string Rol { get; set; }

    [Required(ErrorMessage = "El telefono es obligatorio")]
    [StringLength(20)]
    public required string Telefono { get; set; }

    [Required(ErrorMessage = "El Dni es obligatorio")]
    [StringLength(30)]
    public required string Dni { get; set; }

    [Required]
    public DateTime Creado { get; set; }

    [StringLength(30)]
    public DateTime? Actualizado { get; set; }

        // Propiedad de navegación para las ventas
    public required ICollection<Ventas> Ventas { get; set; }
}
