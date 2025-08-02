using System;
using Universidad;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var contexto = new UniversidadContext();

        // -------------------------------
        // Agregar estudiantes (como el original)
        // -------------------------------
        var estudiante1 = new Estudiante
        {
            Nombre = "Juan Perez",
            Email = "juan@test.com",
            Activo = true
        };
        contexto.agregar(estudiante1);
        Console.WriteLine($"Estudiante creado: {estudiante1.Nombre} (ID: {estudiante1.Id}) (Estado: {estudiante1.Activo}) (Email: {estudiante1.Email})");
        Console.WriteLine($"Total de estudiantes registrados: {contexto.Estudiantes.Count}");

        var estudiante2 = new Estudiante
        {
            Nombre = "Carlos Cruz",
            Email = "carlos@test.com",
            Activo = false
        };
        contexto.agregar(estudiante2);
        Console.WriteLine($"Estudiante creado: {estudiante2.Nombre} (ID: {estudiante2.Id}) (Estado: {estudiante2.Activo}) (Email: {estudiante2.Email})");
        Console.WriteLine($"Total de estudiantes registrados: {contexto.Estudiantes.Count}");

        var estudiante3 = new Estudiante
        {
            Nombre = "Ana Torres",
            Email = "ana@test.com",
            Activo = true
        };
        contexto.agregar(estudiante3);
        Console.WriteLine($"Estudiante creado: {estudiante3.Nombre} (ID: {estudiante3.Id}) (Estado: {estudiante3.Activo}) (Email: {estudiante3.Email})");
        Console.WriteLine($"Total de estudiantes registrados: {contexto.Estudiantes.Count}");

        // -------------------------------
        // Agregar profesores
        // -------------------------------
        var profesor1 = new Profesor { Nombre = "Pedro Martínez", Especializacion = "Programación Avanzada" };
        var profesor2 = new Profesor { Nombre = "Sandra López", Especializacion = "Matemáticas" };
        var profesor3 = new Profesor { Nombre = "María Rivera", Especializacion = "Introducción a la Programación" };

        contexto.AgregarProfesor(profesor1);
        contexto.AgregarProfesor(profesor2);
        contexto.AgregarProfesor(profesor3);

        Console.WriteLine("\nProfesores agregados:");
        foreach (var p in contexto.Profesores)
        {
            Console.WriteLine($"- {p.Nombre} (ID: {p.Id}, Especialización: {p.Especializacion})");
        }

        // -------------------------------
        // Agregar cursos
        // -------------------------------
        var curso1 = new Curso { Nombre = "C# Básico", UnidadesValorativas = 3, ProfesorId = 1 };
        var curso2 = new Curso { Nombre = "Álgebra Lineal", UnidadesValorativas = 4, ProfesorId = 2 };
        var curso3 = new Curso { Nombre = "Estructuras de Datos", UnidadesValorativas = 2, ProfesorId = 1 };
        var curso4 = new Curso { Nombre = "Lógica de Programación", UnidadesValorativas = 5, ProfesorId = 3 };

        contexto.AgregarCurso(curso1);
        contexto.AgregarCurso(curso2);
        contexto.AgregarCurso(curso3);
        contexto.AgregarCurso(curso4);

        Console.WriteLine("\nCursos agregados:");
        foreach (var c in contexto.Cursos)
        {
            Console.WriteLine($"- {c.Nombre} (ID: {c.Id}, UV: {c.UnidadesValorativas}, ProfesorId: {c.ProfesorId})");
        }

        // -------------------------------
        // Buscar estudiante por email
        // -------------------------------
        Console.WriteLine("\nBuscar estudiante por email (ana@test.com):");
        var buscado = contexto.BuscarEstudiantePorEmail("ANA@test.com");
        if (buscado != null)
        {
            Console.WriteLine($"Estudiante encontrado: {buscado.Nombre} - Estado: {(buscado.Activo ? "Activo" : "Inactivo")}");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado");
        }

        // -------------------------------
        // Buscar profesores por especialización
        // -------------------------------
        Console.WriteLine("\nBuscar profesores con especialización que contiene 'programación':");
        var encontrados = contexto.ObtenerProfesoresPorEspecializacion("programación");
        foreach (var prof in encontrados)
        {
            Console.WriteLine($"- {prof.Nombre} ({prof.Especializacion})");
        }

        // -------------------------------
        // Actualizar unidades valorativas de un curso
        // -------------------------------
        Console.WriteLine("\nActualizar UV del curso con ID 4 a 3:");
        bool resultado = contexto.ActualizarUnidadesValorativas(4, 3);
        Console.WriteLine($"¿Actualización exitosa?: {resultado}");

        // Mostrar cursos después de actualizar
        Console.WriteLine("\nCursos después de la actualización:");
        foreach (var c in contexto.Cursos)
        {
            Console.WriteLine($"- {c.Nombre} (ID: {c.Id}, UV: {c.UnidadesValorativas})");
        }
    }
}
