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

decimal totalVenta = 0;
int cantidadProductos = 0;
string opcion;

do
{
    Console.WriteLine("¿Qué desea hacer?");
    Console.WriteLine("1 – Cargar un producto");
    Console.WriteLine("2 – Cerrar la venta");
    Console.Write("Seleccione una opción: ");
    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese producto: ");
            string producto = Console.ReadLine();

            Console.Write("Ingrese precio: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine());

            totalVenta += precio;
            cantidadProductos++;
            break;

        case "2":
            Console.WriteLine($"\nCantidad de productos: {cantidadProductos}");
            Console.WriteLine($"Total a pagar: {totalVenta:C}");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.\n");
            break;
    }

} while (opcion != "2");

