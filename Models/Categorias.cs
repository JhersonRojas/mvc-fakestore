using System.ComponentModel.DataAnnotations;

namespace mvc_fakestore.Models;

public class Categorias
{
    [Key]
    public int IdCategoria { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(20)]
    public required string Nombre { get; set; }

    public required ICollection<Productos> Productos { get; set; }
}
