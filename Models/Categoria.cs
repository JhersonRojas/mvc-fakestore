using System.ComponentModel.DataAnnotations;

namespace mvc_fakestore.Models;

public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(20)]
    public required string IdProveedor { get; set; }

}