using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public class Reserva
    {
        public Cliente Cliente { get; private set; }
        public Vehiculo Vehiculo { get; private set; }
        public DateTime Fecha { get; private set; }
        public int DiasAlquiler { get; private set; }
        public double PrecioAlquiler => Vehiculo.CalcularPrecioAlquiler(DiasAlquiler);

        public Reserva(Cliente cliente, Vehiculo vehiculo, DateTime fecha, int diasAlquiler)
        {
            Cliente = cliente;
            Vehiculo = vehiculo;
            Fecha = fecha;
            DiasAlquiler = diasAlquiler;
        }
    }
}
