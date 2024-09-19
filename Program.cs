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

    class Personaje
    {
        public string Nombre;
        public int Vida;
        public int Ataque;
        public List<Item> Items;

        public Personaje(string name, int vida, int ataque)
        {
            Nombre = name;
            Vida = vida;
            Ataque = ataque;
            Items = new List<Item>();
        }

        public bool EstaMuerto()
        {
            return Vida <= 0; // si la vida es menor o igual a 0, está muerto
        }

        public void Atacar(Personaje enemigo)
        {
            enemigo.Vida = enemigo.Vida - Ataque;
            Console.WriteLine(Nombre + " atacó a " + enemigo.Nombre + ", hizo " + Ataque + " de daño. Vida restante de " + enemigo.Nombre + ": " + enemigo.Vida);
        }
    }


    class Enemigo : Personaje
    {
        public string tipo; // si es "melee" o "rango"

        public Enemigo(string name, int vida, int ataque, string tipoDeEnemigo)
            : base(name, vida, ataque)
        {
            tipo = tipoDeEnemigo;
        }
    }
}
