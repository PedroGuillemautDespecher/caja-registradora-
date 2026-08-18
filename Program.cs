const string NombreComercio = "KIOSCO EL RECREO";
const decimal DescuentoAlto = 0.10m;
const decimal DescuentoMedio = 0.05m;
const decimal DescuentoEfectivo = 0.10m; // 10% adicional
const decimal RecargoCredito = 0.15m;    // 15% recargo

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

            decimal montoDescuentoMonto = subtotal * porcentajeDescuentoMonto;
            decimal totalConDescuentoMonto = subtotal - montoDescuentoMonto;

            // --- ELECCIÓN DE MEDIO DE PAGO ---
            string medioPago;
            bool opcionValida = false;
            decimal ajusteMedioPago = 0; // Guardará el descuento o recargo
            string detalleMedioPago = "";

            do
            {
                Console.WriteLine("\nMedio de pago:");
                Console.WriteLine("1 – Efectivo (10% desc. adicional)");
                Console.WriteLine("2 – Débito");
                Console.WriteLine("3 – Crédito (15% recargo)");
                Console.Write("Seleccione opción: ");
                medioPago = Console.ReadLine();

                switch (medioPago)
                {
                    case "1":
                        ajusteMedioPago = -(totalConDescuentoMonto * DescuentoEfectivo);
                        detalleMedioPago = "Efectivo (Desc. 10%)";
                        opcionValida = true;
                        break;
                    case "2":
                        ajusteMedioPago = 0;
                        detalleMedioPago = "Débito";
                        opcionValida = true;
                        break;
                    case "3":
                        ajusteMedioPago = totalConDescuentoMonto * RecargoCredito;
                        detalleMedioPago = "Crédito (Recargo 15%)";
                        opcionValida = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            } while (!opcionValida); // Se repite hasta que ingrese 1, 2 o 3

            decimal totalFinal = totalConDescuentoMonto + ajusteMedioPago;

            // --- RESUMEN FINAL ---
            Console.WriteLine($"\n=== RESUMEN DE VENTA ===");
            Console.WriteLine($"Cantidad de productos: {cantidadProductos}");
            Console.WriteLine($"Subtotal: {subtotal:C}");
            Console.WriteLine($"Descuento por monto ({porcentajeDescuentoMonto * 100}%): -{montoDescuentoMonto:C}");
            Console.WriteLine($"Medio de pago: {detalleMedioPago}");
            Console.WriteLine($"Ajuste medio de pago: {ajusteMedioPago:C}");
            Console.WriteLine($"Total final a pagar: {totalFinal:C}");
            break;

        default:
            Console.WriteLine("Opción inválida. Intente de nuevo.\n");
            break;
    }

} while (opcion != "2");

Console.ReadLine();
