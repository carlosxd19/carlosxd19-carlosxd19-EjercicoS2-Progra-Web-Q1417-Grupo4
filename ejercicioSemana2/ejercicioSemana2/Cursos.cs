using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cursos
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int unidadesValorativas { get; set; }

    // The number of credit units for the course.
    public int ProfesorId { get; set; }
    public Profesor Profesor { get; set; }

}

// This class represents a course with properties for ID, name, credit units, and associated professor.