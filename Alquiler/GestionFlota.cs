using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public class GestionFlota
    {
        public List<Vehiculo> Flota { get; private set; }
        public List<Reserva> HistorialReservas { get; private set; }

        public GestionFlota()
        {
            Flota = new List<Vehiculo>();
            HistorialReservas = new List<Reserva>();
        }

        public void RegistrarVehiculo(Vehiculo vehiculo)
        {
            Flota.Add(vehiculo);
            Console.WriteLine($"Vehículo registrado: {vehiculo.Marca} {vehiculo.Modelo}");
        }

        public void RegistrarReserva(Cliente cliente, Vehiculo vehiculo, int diasAlquiler)
        {
            if (vehiculo.Estado == Estado.DISPONIBLE)
            {
                vehiculo.Estado = Estado.ALQUILADO;
                Reserva reserva = new Reserva(cliente, vehiculo, DateTime.Now, diasAlquiler);
                HistorialReservas.Add(reserva);
                Console.WriteLine($"Reserva realizada con éxito para el cliente {cliente.Name}");
            }
            else
            {
                Console.WriteLine("El vehículo no está disponible para reserva o es nulo.");
            }
        }

        public void DevolverVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo != null && vehiculo.Estado == Estado.ALQUILADO)
            {
                vehiculo.Estado = Estado.DISPONIBLE;
                Console.WriteLine("El vehículo ha sido devuelto.");
            }
            else
            {
                Console.WriteLine("El vehículo no se puede devolver o es nulo.");
            }
        }

        public void ActualizarDatosVehiculo(Vehiculo vehiculo)
        {
            Console.WriteLine("\n--- Actualizar Datos del Vehículo ---");

            Console.WriteLine("¿Desea actualizar la marca? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Write("Ingrese la nueva marca: ");
                vehiculo.Marca = Console.ReadLine();
            }

            Console.WriteLine("¿Desea actualizar el modelo? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Write("Ingrese el nuevo modelo: ");
                vehiculo.Modelo = Console.ReadLine();
            }

            Console.WriteLine("¿Desea actualizar el año de fabricación? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.Write("Ingrese el nuevo año de fabricación: ");
                vehiculo.AñoDeFabricacion = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("¿Desea actualizar el estado del vehículo? (S/N)");
            if (Console.ReadLine().ToUpper() == "S")
            {
                Console.WriteLine("Ingrese el nuevo estado (0 - DISPONIBLE, 1 - ALQUILADO, 2 - ENMANTENIMIENTO): ");
                vehiculo.Estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());
            }

            if (vehiculo is Motocicleta moto)
            {
                Console.WriteLine("¿Desea actualizar el cilindraje? (S/N)");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    Console.Write("Ingrese el nuevo cilindraje: ");
                    moto.Cilindraje = int.Parse(Console.ReadLine());
                }
            }
            else if (vehiculo is Automovil auto)
            {
                Console.WriteLine("¿Desea actualizar el kilometraje? (S/N)");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    Console.Write("Ingrese el nuevo kilometraje: ");
                    auto.Kilometraje = int.Parse(Console.ReadLine());
                }
            }
            else if (vehiculo is Camion camion)
            {
                Console.WriteLine("¿Desea actualizar la capacidad de carga? (S/N)");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    Console.Write("Ingrese la nueva capacidad de carga: ");
                    camion.CapacidadDeCarga = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Datos del vehículo actualizados con éxito.");
        }


        public void MostrarFlota()
        {
            if (Flota.Count == 0)
            {
                Console.WriteLine("No hay vehículos en la flota.");
                return;
            }

            for (int i = 0; i < Flota.Count; i++)
            {
                Vehiculo vehiculo = Flota[i];
                Console.WriteLine($"{i + 1}. {vehiculo.GetType().Name}: {vehiculo.Marca} {vehiculo.Modelo}, Año: {vehiculo.AñoDeFabricacion}, Estado: {vehiculo.Estado}");
            }
        }

        public void MostrarHistorialReservas()
        {
            if (HistorialReservas.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
                return;
            }

            foreach (Reserva reserva in HistorialReservas)
            {
                Console.WriteLine($"Reserva de {reserva.Cliente.Name} ({reserva.Cliente.Id})");
                Console.WriteLine($"Vehículo: {reserva.Vehiculo?.Marca} {reserva.Vehiculo?.Modelo}, Año: {reserva.Vehiculo?.AñoDeFabricacion}");
                Console.WriteLine($"Fecha de Reserva: {reserva.Fecha}");
                Console.WriteLine($"Días de Alquiler: {reserva.DiasAlquiler}");
                Console.WriteLine($"Precio del Alquiler: {reserva.PrecioAlquiler:C}");
            }
        }
    }
}
