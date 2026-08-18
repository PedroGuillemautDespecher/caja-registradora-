const string NombreComercio = "KIOSCO EL RECREO";
const decimal DescuentoAlto = 0.10m;
const decimal DescuentoMedio = 0.05m;

Console.WriteLine($"=== {NombreComercio} ===");
Console.Write("Nombre del cajero: ");
string cajero = Console.ReadLine();
Console.WriteLine($"Bienvenida, {cajero}. Caja abierta.\n");

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
            decimal subtotal = totalVenta;
            decimal porcentajeDescuento = 0;

            if (subtotal > 50000)
            {
                porcentajeDescuento = DescuentoAlto;
            }
            else if (subtotal > 20000)
            {
                porcentajeDescuento = DescuentoMedio;
            }

            decimal montoDescuento = subtotal * porcentajeDescuento;
            decimal totalFinal = subtotal - montoDescuento;

            Console.WriteLine($"\nCantidad de productos: {cantidadProductos}");
            Console.WriteLine($"Subtotal: {subtotal:C}");
            Console.WriteLine($"Descuento ({porcentajeDescuento * 100}%): -{montoDescuento:C}");
            Console.WriteLine($"Total a pagar: {totalFinal:C}");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.\n");
            break;
    }

} while (opcion != "2");

Console.ReadLine();
