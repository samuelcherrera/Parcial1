using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    public class Cliente
    {
        public string? Name { get; private set; }
        public int Id { get; private set; }

        public Cliente(string Name, int Id)
        {
            this.Name = Name;
            this.Id = Id;
        }
    }
}
