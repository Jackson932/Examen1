using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  Se utiliza el metodo de matrices para almacenar el horario de estudiantes por día y materia
namespace Examen1
{
    internal class Program
    {
        static string[,,] horario = new string[5, 4, 10]; // [día, materia, estudiante]
        static string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };
        static string[] materias = { "Español", "Matemáticas", "Ciencias", "Ciencias Sociales" };

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Eliminar estudiante");
                Console.WriteLine("3. Consultar estudiantes");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: RegistrarEstudiante(); break;
                    case 2: EliminarEstudiante(); break;
                    case 3: Consultar(); break;
                    case 4: Console.WriteLine("Saliendo..."); break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            } while (opcion != 4);
        }

        static void RegistrarEstudiante()
        {
            int dia = PedirDia();
            int materia = PedirMateria();

            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            
            for (int m = 0; m < 4; m++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (horario[dia, m, i] == nombre)
                    {
                        Console.WriteLine($"El estudiante ya está registrado en otra materia el {dias[dia]}.");
                        return;
                    }
                }
            }

            // Registrar 1 materia
            for (int i = 0; i < 10; i++)
            {
                if (horario[dia, materia, i] == null)
                {
                    horario[dia, materia, i] = nombre;
                    Console.WriteLine("Estudiante registrado exitosamente.");
                    return;
                }
            }

            Console.WriteLine("No hay espacio disponible en esta materia para ese día.");
        }

        static void EliminarEstudiante()
        {
            int dia = PedirDia();
            int materia = PedirMateria();

            Console.Write("Nombre del estudiante a eliminar: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                if (horario[dia, materia, i] == nombre)
                {
                    horario[dia, materia, i] = null;
                    Console.WriteLine("Estudiante eliminado.");
                    return;
                }
            }

            Console.WriteLine("Estudiante no encontrado en esa materia y día.");
        }

        static void Consultar()
        {
            Console.WriteLine("1. Consultar por materia");
            Console.WriteLine("2. Consultar por día");
            Console.WriteLine("3. Consultar día completo");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                int materia = PedirMateria();
                for (int d = 0; d < 5; d++)
                {
                    Console.WriteLine($"\n{dias[d]} - {materias[materia]}:");
                    for (int i = 0; i < 10; i++)
                    {
                        if (horario[d, materia, i] != null)
                            Console.WriteLine($"- {horario[d, materia, i]}");
                    }
                }
            }
            else if (opcion == 2)
            {
                int dia = PedirDia();
                for (int m = 0; m < 4; m++)
                {
                    Console.WriteLine($"\n{materias[m]}:");
                    for (int i = 0; i < 10; i++)
                    {
                        if (horario[dia, m, i] != null)
                            Console.WriteLine($"- {horario[dia, m, i]}");
                    }
                }
            }
            else if (opcion == 3)
            {
                int dia = PedirDia();
                Console.WriteLine($"\nHorario completo del {dias[dia]}:");
                for (int m = 0; m < 4; m++)
                {
                    Console.WriteLine($"\n{materias[m]}:");
                    for (int i = 0; i < 10; i++)
                    {
                        if (horario[dia, m, i] != null)
                            Console.WriteLine($"- {horario[dia, m, i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

        static int PedirDia()
        {
            Console.WriteLine("Seleccione el día:");
            for (int i = 0; i < dias.Length; i++)
                Console.WriteLine($"{i}. {dias[i]}");
            int dia = int.Parse(Console.ReadLine());
            return dia >= 0 && dia < 5 ? dia : 0;
        }

        static int PedirMateria()
        {
            Console.WriteLine("Seleccione la materia:");
            for (int i = 0; i < materias.Length; i++)
                Console.WriteLine($"{i}. {materias[i]}");
            int materia = int.Parse(Console.ReadLine());
            return materia >= 0 && materia < 4 ? materia : 0;

        }
    }
}
