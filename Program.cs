using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2._0
{
    class Item
    {
        public string Name;
        public int Healing;
        public int ManaRestore;

        public Item(string nombre, int curacion, int mana)
        {
            Name = nombre; 
            Healing = curacion; 
            ManaRestore = mana; 
        }
    }

    class Poder
    {
        public string nombreDelPoder; 
        public int Damage;
        public int mana;

        public Poder(string name, int damage, int costoMana)
        {
            nombreDelPoder = name; 
            Damage = damage; 
            mana = costoMana; 
        }
    }
}
