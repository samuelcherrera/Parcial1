using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public class Camion : Vehiculo, IGestionReservas
    {
        public int CapacidadDeCarga { get; set; }

        public Camion(string Marca, string Modelo, int AñoDeFabricacion, Estado Estado, int CapacidadDeCarga)
            : base(Marca, Modelo, AñoDeFabricacion, Estado)
        {
            this.CapacidadDeCarga = CapacidadDeCarga;
        }

        public override double CalcularPrecioAlquiler(int dias)
        {
            return 80.00 * dias;
        }

        public void reservar()
        {
            if (Estado == Estado.DISPONIBLE)
            {
                Estado = Estado.ALQUILADO;
            }
            else
            {
                Console.WriteLine("El camión no está disponible para ser alquilado.");
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
                Console.WriteLine("El camión no se puede devolver.");
            }
        }
    }
}
