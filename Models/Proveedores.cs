using System.ComponentModel.DataAnnotations;

namespace mvc_fakestore.Models;

public class Proveedores
{
    [Key]
    public int IdProveedor { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public required string Nombre { get; set; }

    [Required(ErrorMessage = "El Telefono es obligatorio")]
    public required string Telefono { get; set; }
}
