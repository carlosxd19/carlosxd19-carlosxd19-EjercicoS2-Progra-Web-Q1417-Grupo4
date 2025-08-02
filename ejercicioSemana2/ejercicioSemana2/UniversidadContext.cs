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

        // Método 1: Agregar profesor
        public void AgregarProfesor(Profesor profesor)
        {
            profesor.Id = Profesores.Count + 1;
            Profesores.Add(profesor);
        }

        // Método 2: Agregar curso
        public void AgregarCurso(Curso curso)
        {
            curso.Id = Cursos.Count + 1;
            Cursos.Add(curso);
        }
    // Método 3: Buscar estudiante por email (insensible a mayúsculas)
    public Estudiante BuscarEstudiantePorEmail(string email)
    {
        return Estudiantes
            .FirstOrDefault(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    // Método 4: Obtener profesores por especialización
    public List<Profesor> ObtenerProfesoresPorEspecializacion(string especializacion)
    {
        return Profesores
            .Where(p => p.Especializacion != null &&
                        p.Especializacion.IndexOf(especializacion, StringComparison.OrdinalIgnoreCase) >= 0)
            .OrderBy(p => p.Nombre)
            .ToList();
    }

    // Método: Agregar estudiante
    public void agregar(Estudiante estudiante)
    {
        estudiante.Id = Estudiantes.Count + 1; // Auto-incremento ID
        Estudiantes.Add(estudiante);
    }
}