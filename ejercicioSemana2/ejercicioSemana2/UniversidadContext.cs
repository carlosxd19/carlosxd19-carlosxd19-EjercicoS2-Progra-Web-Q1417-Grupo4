using System;
using System.Collections.Generic;
using System.Linq;

public class UniversidadContext
{
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    public List<Profesor> Profesores { get; set; } = new List<Profesor>();
    public List<Cursos> Cursos { get; set; } = new List<Cursos>();

    public void AgregarEstudiante(Estudiante estudiante)
    {
        estudiante.Id = Estudiantes.Count + 1;
        Estudiantes.Add(estudiante);
    }

    public void AgregarProfesor(Profesor profesor)
    {
        profesor.Id = Profesores.Count + 1;
        Profesores.Add(profesor);
    }

    public void AgregarCurso(Cursos curso)
    {
        curso.Id = Cursos.Count + 1;
        Cursos.Add(curso);
    }

    public Estudiante BuscarEstudiantePorEmail(string email)
    {
        return Estudiantes
            .FirstOrDefault(e => string.Equals(e.Email, email, StringComparison.OrdinalIgnoreCase));
    }

    public List<Profesor> ObtenerProfesoresPorEspecializacion(string especializacion)
    {
        return Profesores
            .Where(p => !string.IsNullOrEmpty(p.Especializacion) && p.Especializacion.IndexOf(especializacion, StringComparison.OrdinalIgnoreCase) >= 0)
            .OrderBy(p => p.Nombre)
            .ToList();
    }

    public bool ActualizarUnidadesValorativas(int cursoId, int nuevasUnidades)
    {
        if (nuevasUnidades < 1 || nuevasUnidades > 4)
        {
            Console.WriteLine("Error: Las unidades valorativas deben estar entre 1 y 4.");
            return false;
        }

        var curso = Cursos.FirstOrDefault(c => c.Id == cursoId);
        if (curso == null)
        {
            Console.WriteLine($"No se encontró un curso con ID {cursoId}.");
            return false;
        }

        curso.unidadesValorativas = nuevasUnidades;
        Console.WriteLine($"Curso '{curso.Nombre}' actualizado con {nuevasUnidades} unidades valorativas.");
        return true;
    }
}
