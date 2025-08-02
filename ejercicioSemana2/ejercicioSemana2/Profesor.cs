using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Profesor
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Especializacion { get; set; }
   
    public List<Cursos> Cursos { get; set; } = new List<Cursos>();
}
// This class represents a professor with properties for ID, name, email, and specialization.