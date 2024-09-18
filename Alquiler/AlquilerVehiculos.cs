using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public class AlquilerVehiculos
    {
        public static void Main(string[] args)
        {
            GestionFlota gestionFlota = new GestionFlota();
            int opcion;

            do
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Registrar Vehículo");
                Console.WriteLine("2. Realizar Reserva");
                Console.WriteLine("3. Devolver Vehículo");
                Console.WriteLine("4. Mostrar Flota");
                Console.WriteLine("5. Mostrar Historial de Reservas");
                Console.WriteLine("6. Actualizar información de un vehículo");
                Console.WriteLine("7. Salir");
                Console.Write("Elija una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Seleccione tipo de vehículo:");
                        Console.WriteLine("1. Motocicleta");
                        Console.WriteLine("2. Automóvil");
                        Console.WriteLine("3. Camión");
                        int tipoVehiculo = int.Parse(Console.ReadLine());

                        Console.Write("Ingrese la marca: ");
                        string marca = Console.ReadLine();

                        Console.Write("Ingrese el modelo: ");
                        string modelo = Console.ReadLine();

                        Console.Write("Ingrese el año de fabricación: ");
                        int año = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el estado (0 - DISPONIBLE, 1 - ALQUILADO, 2 - ENMANTENIMIENTO): ");
                        Estado estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

                        switch (tipoVehiculo)
                        {
                            case 1:
                                Console.Write("Ingrese el cilindraje: ");
                                int cilindraje = int.Parse(Console.ReadLine());
                                Motocicleta moto = new Motocicleta(marca, modelo, año, estado, cilindraje);
                                gestionFlota.RegistrarVehiculo(moto);
                                break;

                            case 2:
                                Console.Write("Ingrese el kilometraje: ");
                                int kilometraje = int.Parse(Console.ReadLine());
                                Automovil auto = new Automovil(marca, modelo, año, estado, kilometraje);
                                gestionFlota.RegistrarVehiculo(auto);
                                break;

                            case 3:
                                Console.Write("Ingrese la capacidad de carga: ");
                                int capacidad = int.Parse(Console.ReadLine());
                                Camion camion = new Camion(marca, modelo, año, estado, capacidad);
                                gestionFlota.RegistrarVehiculo(camion);
                                break;

                            default:
                                Console.WriteLine("Tipo de vehículo no válido.");
                                break;
                        }
                        break;

                    case 2:
                        if (gestionFlota.Flota.Count == 0) // Verificar si la flota está vacía
                        {
                            Console.WriteLine("No hay vehículos registrados en la flota. Volviendo al menú...");
                            break;
                        }

                        Console.Write("Ingrese el nombre del cliente: ");
                        string nombreCliente = Console.ReadLine();

                        Console.Write("Ingrese el ID del cliente: ");
                        int idCliente = int.Parse(Console.ReadLine());

                        Cliente cliente = new Cliente(nombreCliente, idCliente);

                        gestionFlota.MostrarFlota();
                        Console.Write("Seleccione el número del vehículo para reservar: ");
                        int indexVehiculo = int.Parse(Console.ReadLine()) - 1;

                        if (indexVehiculo >= 0 && indexVehiculo < gestionFlota.Flota.Count)
                        {
                            Vehiculo vehiculoReservar = gestionFlota.Flota[indexVehiculo];
                            Console.Write("Ingrese la cantidad de días de alquiler: ");
                            int diasAlquiler = int.Parse(Console.ReadLine());

                            gestionFlota.RegistrarReserva(cliente, vehiculoReservar, diasAlquiler);
                        }
                        else
                        {
                            Console.WriteLine("Número de vehículo no válido.");
                        }
                        break;

                    case 3:
                        if (gestionFlota.Flota.Count == 0) // Verificar si la flota está vacía
                        {
                            Console.WriteLine("No hay vehículos registrados en la flota. Volviendo al menú...");
                            break;
                        }

                        gestionFlota.MostrarFlota();
                        Console.Write("Seleccione el número del vehículo para devolver: ");
                        int indexDevolver = int.Parse(Console.ReadLine()) - 1;

                        if (indexDevolver >= 0 && indexDevolver < gestionFlota.Flota.Count)
                        {
                            Vehiculo vehiculoDevolver = gestionFlota.Flota[indexDevolver];
                            gestionFlota.DevolverVehiculo(vehiculoDevolver);
                        }
                        else
                        {
                            Console.WriteLine("Número de vehículo no válido.");
                        }
                        break;

                    case 4:
                        gestionFlota.MostrarFlota();
                        break;

                    case 5:
                        gestionFlota.MostrarHistorialReservas();
                        break;

                    case 6:
                        if (gestionFlota.Flota.Count == 0) // Verificar si la flota está vacía
                        {
                            Console.WriteLine("No hay vehículos registrados en la flota. Volviendo al menú...");
                            break;
                        }

                        gestionFlota.MostrarFlota();
                        Console.Write("Seleccione el número del vehículo para actualizar: ");
                        int indexActualizar = int.Parse(Console.ReadLine()) - 1;

                        if (indexActualizar >= 0 && indexActualizar < gestionFlota.Flota.Count)
                        {
                            Vehiculo vehiculoActualizar = gestionFlota.Flota[indexActualizar];
                            gestionFlota.ActualizarDatosVehiculo(vehiculoActualizar);
                        }
                        else
                        {
                            Console.WriteLine("Número de vehículo no válido.");
                        }
                        break;

                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 7);
        }
    }
}
