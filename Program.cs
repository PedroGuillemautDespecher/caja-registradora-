const string NombreComercio = "KIOSKO DEL RECREO";
Console.WriteLine(NombreComercio);
Console.Write("Nombre del Cajero");
string NombreCajero = Console.ReadLine();
Console.WriteLine($"Bienvenida {NombreCajero}, Caja Abierta");

Console.WriteLine("Ingrese Producto:");
string Producto = Console.ReadLine();
Console.Write("Ingrese Precio");
decimal precio = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine($"Producto {Producto} Precio {precio}");

