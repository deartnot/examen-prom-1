using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2._0
{
    internal class Program
    {
        class Item
        {
            public string Name { get; set; }
            public int Healing { get; set; } // Para recuperar vida
            public int ManaRestore { get; set; } // Para recuperar maná

            public Item(string name, int healing, int manaRestore)
            {
                Name = name;
                Healing = healing;
                ManaRestore = manaRestore;
            }
        }
    }
}
