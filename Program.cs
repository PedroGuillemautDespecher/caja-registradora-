const string NombreComercio = "KIOSCO EL RECREO";
const decimal DescuentoAlto = 0.10m;
const decimal DescuentoMedio = 0.05m;
const decimal DescuentoEfectivo = 0.10m;
const decimal RecargoCredito = 0.15m;

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
            // --- CÁLCULO DE DESCUENTO POR MONTO ---
            decimal subtotal = totalVenta;
            decimal porcentajeDescuentoMonto = 0;

            if (subtotal > 50000)
            {
                porcentajeDescuentoMonto = DescuentoAlto;
            }
            else if (subtotal > 20000)
            {
                porcentajeDescuentoMonto = DescuentoMedio;
            }

            decimal montoDescuento = subtotal * porcentajeDescuentoMonto;
            decimal totalConDescuentoMonto = subtotal - montoDescuento;

            // --- ELECCIÓN DE MEDIO DE PAGO ---
            string medioPago;
            bool opcionValida = false;
            decimal montoRecargo = 0;

            do
            {
                Console.WriteLine("\nMedio de pago:");
                Console.WriteLine("1 – Efectivo");
                Console.WriteLine("2 – Débito");
                Console.WriteLine("3 – Crédito");
                Console.Write("Seleccione opción: ");
                medioPago = Console.ReadLine();

                switch (medioPago)
                {
                    case "1":
                        // Si paga en efectivo, sumamos el 10% extra al descuento total
                        montoDescuento += totalConDescuentoMonto * DescuentoEfectivo;
                        opcionValida = true;
                        break;
                    case "2":
                        opcionValida = true;
                        break;
                    case "3":
                        montoRecargo = totalConDescuentoMonto * RecargoCredito;
                        opcionValida = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            } while (!opcionValida);

            decimal totalFinal = subtotal - montoDescuento + montoRecargo;

            // --- IMPRESIÓN DEL TICKET FINAL ---
            Console.WriteLine();
            ImprimirLineaGuiones();
            Console.WriteLine($"      {NombreComercio}");
            ImprimirLineaGuiones();
            Console.WriteLine($"Cajero: {cajero}");
            Console.WriteLine($"Productos: {cantidadProductos}");
            Console.WriteLine($"Subtotal: {subtotal}");
            Console.WriteLine($"Descuento: {montoDescuento}");
            Console.WriteLine($"Recargo: {montoRecargo}");
            ImprimirLineaGuiones();
            Console.WriteLine($"TOTAL: {totalFinal}");
            ImprimirLineaGuiones();
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.\n");
            break;
    }

} while (opcion != "2");

Console.ReadLine();


static void ImprimirLineaGuiones()
{
    for (int i = 0; i < 30; i++)
    {
        Console.Write("-");
    }
    Console.WriteLine();
}