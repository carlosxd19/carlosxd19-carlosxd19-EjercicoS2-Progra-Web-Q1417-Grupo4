using System;

class Program
{
    static void Main()
    {
        var contexto = new UniversidadContext();

        // Agregar estudiantes
        contexto.AgregarEstudiante(new Estudiante { Nombre = "Ana Perez", Email = "ana.perez@mail.com", Activo = true });
        contexto.AgregarEstudiante(new Estudiante { Nombre = "Luis Gomez", Email = "luis.gomez@mail.com", Activo = false });
        contexto.AgregarEstudiante(new Estudiante { Nombre = "Marta Lopez", Email = "marta.lopez@mail.com", Activo = true });

        // Agregar profesores
        contexto.AgregarProfesor(new Profesor { Nombre = "Carlos Ruiz", Email = "carlos.ruiz@mail.com", Especializacion = "Programación Avanzada" });
        contexto.AgregarProfesor(new Profesor { Nombre = "Elena Díaz", Email = "elena.diaz@mail.com", Especializacion = "Matemáticas" });
        contexto.AgregarProfesor(new Profesor { Nombre = "Pedro Martínez", Email = "pedro.martinez@mail.com", Especializacion = "Programación Básica" });

        // Agregar cursos
        contexto.AgregarCurso(new Cursos { Nombre = "C# Básico", unidadesValorativas = 3, ProfesorId = 3 });
        contexto.AgregarCurso(new Cursos { Nombre = "Algoritmos", unidadesValorativas = 4, ProfesorId = 1 });
        contexto.AgregarCurso(new Cursos { Nombre = "Matemáticas Discretas", unidadesValorativas = 2, ProfesorId = 2 });
        contexto.AgregarCurso(new Cursos { Nombre = "Bases de Datos", unidadesValorativas = 5, ProfesorId = 1 });

        // Buscar estudiante por email (insensible a mayúsculas)
        var estudianteBuscado = contexto.BuscarEstudiantePorEmail("LUIS.GOMEZ@MAIL.COM");
        Console.WriteLine(estudianteBuscado != null
            ? $"Encontrado: {estudianteBuscado.Nombre}, Activo: {estudianteBuscado.Activo}"
            : "Estudiante no encontrado");

        // Obtener profesores por especialización
        Console.WriteLine("\nProfesores con especialización que contiene 'programacion':");
        var profesoresEncontrados = contexto.ObtenerProfesoresPorEspecializacion("programacion");
        foreach (var prof in profesoresEncontrados)
        {
            Console.WriteLine($"- {prof.Nombre} ({prof.Especializacion})");
        }

        // Actualizar unidades valorativas (éxito)
        Console.WriteLine("\nActualizar unidades valorativas del curso ID 4 a 3:");
        bool exito = contexto.ActualizarUnidadesValorativas(4, 3);
        Console.WriteLine(exito ? "Actualización exitosa" : "Actualización fallida");

        // Actualizar unidades valorativas (fallo por valor inválido)
        Console.WriteLine("\nActualizar unidades valorativas del curso ID 2 a 5 (debe fallar):");
        exito = contexto.ActualizarUnidadesValorativas(2, 5);
        Console.WriteLine(exito ? "Actualización exitosa" : "Actualización fallida");

        Console.WriteLine("\nCursos actuales:");
        foreach (var c in contexto.Cursos)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Unidades: {c.unidadesValorativas}, ProfesorId: {c.ProfesorId}");
        }

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
