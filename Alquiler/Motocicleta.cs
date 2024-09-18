using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public class Motocicleta : Vehiculo, IGestionReservas
    {
        public int Cilindraje { get; set; }

        public Motocicleta(string Marca, string Modelo, int AñoDeFabricacion, Estado Estado, int Cilindraje)
            : base(Marca, Modelo, AñoDeFabricacion, Estado)
        {
            this.Cilindraje = Cilindraje;
        }

        public override double CalcularPrecioAlquiler(int dias)
        {
            return 47.50 * dias;
        }

        public void reservar()
        {
            if (Estado == Estado.DISPONIBLE)
            {
                Estado = Estado.ALQUILADO;
            }
            else
            {
                Console.WriteLine("La motocicleta no está disponible para ser alquilada.");
            }
        }

        public void devolver()
        {
            if (Estado == Estado.ALQUILADO)
            {
                Estado = Estado.DISPONIBLE;
            }
            else
            {
                Console.WriteLine("La motocicleta no se puede devolver.");
            }
        }
    }
}
