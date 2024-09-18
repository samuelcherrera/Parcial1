using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public class Automovil : Vehiculo, IGestionReservas
    {
        public int Kilometraje { get; set; }

        public Automovil(string Marca, string Modelo, int AñoDeFabricacion, Estado Estado, int Kilometraje)
            : base(Marca, Modelo, AñoDeFabricacion, Estado)
        {
            this.Kilometraje = Kilometraje;
        }

        public override double CalcularPrecioAlquiler(int dias)
        {
            return 65.59 * dias;
        }

        public void reservar()
        {
            if (Estado == Estado.DISPONIBLE)
            {
                Estado = Estado.ALQUILADO;
            }
            else
            {
                Console.WriteLine("El automóvil no está disponible para ser alquilado.");
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
                Console.WriteLine("El automóvil no se puede devolver.");
            }
        }
    }
}
