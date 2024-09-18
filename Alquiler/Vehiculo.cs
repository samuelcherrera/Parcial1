using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public abstract class Vehiculo
    {
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int AñoDeFabricacion { get; set; }
        public Estado Estado { get; set; }

        public Vehiculo(string Marca, string Modelo, int AñoDeFabricacion, Estado Estado)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.AñoDeFabricacion = AñoDeFabricacion;
            this.Estado = Estado;
        }

        public abstract double CalcularPrecioAlquiler(int dias);
    }
}
