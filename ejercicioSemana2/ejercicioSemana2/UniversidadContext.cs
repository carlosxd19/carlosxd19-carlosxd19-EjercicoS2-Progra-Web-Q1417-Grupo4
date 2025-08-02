using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UniversidadContext
{
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    public List<Profesor> Profesores { get; set; } = new List<Profesor>();
    public List<Cursos> Cursos { get; set; } = new List<Cursos>();
    public void agregar(Estudiante estudiante)
    {
        estudiante.Id = Estudiantes.Count + 1; // Auto-incremento ID
        Estudiantes.Add(estudiante);
    }
}