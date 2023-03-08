using System;
using AppSignature.Infraestructura.Datos.Contextos;


namespace AppVenta.Infraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            RolContexto db = new RolContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("Listo!!!!!");
            Console.ReadKey();
        }
    }
}