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

    // Método 5: Actualizar unidades valorativas de un curso
    public bool ActualizarUnidadesValorativas(int cursoId, int nuevasUnidades)
    {
        var curso = Cursos.FirstOrDefault(c => c.Id == cursoId);
        if (curso == null)
        {
            Console.WriteLine("Curso no encontrado.");
            return false;
        }

        if (nuevasUnidades < 1 || nuevasUnidades > 4)
        {
            Console.WriteLine("Las unidades valorativas deben estar entre 1 y 4.");
            return false;
        }

        curso.UnidadesValorativas = nuevasUnidades;
        Console.WriteLine($"Curso '{curso.Nombre}' actualizado correctamente.");
        return true;
    }
}

// Clases básicas necesarias para el contexto

public class Estudiante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public bool Activo { get; set; }
}

public class Profesor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Especializacion { get; set; }
}

public class Curso
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int UnidadesValorativas { get; set; }
    public int ProfesorId { get; set; }
}
}
    public void agregar(Estudiante estudiante)
    {
        estudiante.Id = Estudiantes.Count + 1; // Auto-incremento ID
        Estudiantes.Add(estudiante);
    }
}