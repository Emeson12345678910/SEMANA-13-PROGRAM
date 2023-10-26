using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Program_semana_13;
using System.ComponentModel;
using System;
using System.Linq;

using (var context = new Context())
{
    Console.WriteLine("Lista de Estudiantes de la base de datos:");
    foreach (var estudiante in context.ALUMNOS.ToList())
    {
        Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}, Edad: {estudiante.Edad}, Sexo: {estudiante.Sexo}");
    }
}

Console.WriteLine("\n-------------------------------------------------------------------------------");
Console.WriteLine("POR FAVOR LLENAR LOS DATOS QUE SE PIDEN, PARA ALMACENAARLOS EN LA BASE DE DATOS");
Console.WriteLine("\n-------------------------------------------------------------------------------");

using (var context = new Context())
{
    Console.WriteLine();

    int bucle1 = 1;
    while (bucle1 == 1)
    {
        Console.WriteLine("MODIFICACION DE REGISTRO EN PROCESO");
        Console.WriteLine("***********************************");
        Console.WriteLine("Ingrese el Id del estudiante que quiere actualizar");
        Console.WriteLine("************************************");
        int id = Convert.ToInt32(Console.ReadLine());
        var Alumnos = context.ALUMNOS.FirstOrDefault(x => x.Id == id);

        if (Alumnos == null)
        {
            Console.WriteLine("********************************************************************");
            Console.WriteLine("Alumno inexistente, porfavor verificar si puso bien los datos del id");
            Console.WriteLine("********************************************************************");
        }
        else
        {
            Console.WriteLine("Ingresar el id, para modificar la persona con ese id");
            Console.WriteLine("Gracias por usar este programa");
            Console.WriteLine($"  id: {Alumnos.Id}   Nombre: {Alumnos.Nombre} Apellido: {Alumnos.Apellido}  Edad: {Alumnos.Edad}    Sexo: {Alumnos.Sexo}  ");
            Console.WriteLine(" ¿Cual de las 4 opciones presentadas deceas modificar?       ");
            Console.WriteLine("   1. Nombres                   ");
            Console.WriteLine("   2. Apellidos               ");
            Console.WriteLine("   3. Edad                    ");
            Console.WriteLine("   4. Sexo                    ");
            Console.Write("- Eliga una opción a modificar porfavor ");
            var Lector = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (Lector)
                {

                    case 1:
                        Console.WriteLine("Ingrese el nuevo nombre del estudiante:");
                        Alumnos.Nombre = Console.ReadLine();
                        context.Update(Alumnos);
                        context.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el nuevo apellido del estudiante:");
                        Alumnos.Apellido = Console.ReadLine();
                        context.Update(Alumnos);
                        context.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese la nueva edad del estudiante:");
                        Alumnos.Edad = Convert.ToInt32(Console.ReadLine());
                        context.Update(Alumnos);
                        context.SaveChanges();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el sexo del estudiante:");
                        Console.Write("   H. Hombre\n   M. Mujer: ");
                        string? opcion = Console.ReadLine();

                        if (opcion == "H" || opcion.ToLower() == "masculino")
                        {
                            Alumnos.Sexo = Convert.ToString('M');
                        }
                        else if (opcion == "M" || opcion.ToLower() == "femenino")
                        {

                            Alumnos.Sexo =
                                Convert.ToString('F');
                        }
                        else
                        {
                            Console.WriteLine(" Opcion Invalida    Ingrese los datos nuevamente");
                            bucle1 = 1;
                            continue;
                        }
                        context.Update(Alumnos);
                        context.SaveChanges();
                        break;
                }


                Console.WriteLine("   1. Continuar actualizando        ");
                Console.WriteLine("   2. Salir                         ");
                bucle1 = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ingresar los datos correcta mente, gracias, ");
            }
        }
    }
}

using (var context = new Context())
{
    Console.WriteLine("Ingresar el Id del registro que desea eliminar");
    var Id = Console.ReadLine();
    var persona = context.ALUMNOS.SingleOrDefault(p => p.Id == Int32.Parse(Id));
    if (persona != null)
    {
        context.ALUMNOS.Remove(persona);
        context.SaveChanges();
    }
    Console.WriteLine("El registro se elimino con exito");
}