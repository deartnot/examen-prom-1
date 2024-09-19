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


    class Jugador : Personaje
    {
        public int Mana;
        public List<Poder> Poderes;

        public Jugador(string name, int vida, int ataque, int mana)
            : base(name, vida, ataque)
        {
            Mana = mana;
            Poderes = new List<Poder>();
        }

        public void UsarItem(Item item)
        {
            Vida += item.Healing;
            Mana += item.ManaRestore;
            if (Vida > 100) Vida = 100; 
            if (Mana > 100) Mana = 100; 
            Console.WriteLine(Nombre + " usó " + item.Name + ", recuperó " + item.Healing + " de vida y " + item.ManaRestore + " de mana.");
        }

        public void UsarPoder(Poder poder, Personaje enemigo)
        {
            if (Mana >= poder.mana)
            {
                Mana -= poder.mana;
                enemigo.Vida -= poder.Damage;
                Console.WriteLine(Nombre + " usó " + poder.nombreDelPoder + " en " + enemigo.Nombre + ", hizo " + poder.Damage + " de daño. Vida restante de " + enemigo.Nombre + ": " + enemigo.Vida);
            }
            else
            {
                Console.WriteLine("No tienes suficiente mana.");
            }
        }
    }


    class Enemigo : Personaje
    {
        public string tipo; 

        public Enemigo(string name, int vida, int ataque, string tipoDeEnemigo)
            : base(name, vida, ataque)
        {
            tipo = tipoDeEnemigo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Crea tu jugador:");
            Console.Write("Nombre del jugador: ");
            string jugadorNombre = Console.ReadLine();
            Console.Write("Vida del jugador (máx 100): ");
            int jugadorVida = int.Parse(Console.ReadLine());
            if (jugadorVida > 100) jugadorVida = 100;
            Console.Write("Ataque del jugador: ");
            int jugadorAtaque = int.Parse(Console.ReadLine());
            Console.Write("Maná del jugador (máx 100): ");
            int jugadorMana = int.Parse(Console.ReadLine());
            if (jugadorMana > 100) jugadorMana = 100;

            Jugador jugador = new Jugador(jugadorNombre, jugadorVida, jugadorAtaque, jugadorMana);

            
            Console.WriteLine("Crea poderes para tu jugador:");
            Console.Write("¿Cuántos poderes quieres crear?: ");
            int numPoderes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numPoderes; i++)
            {
                Console.Write("Nombre del poder: ");
                string poderNombre = Console.ReadLine();
                Console.Write("Daño del poder: ");
                int poderDaño = int.Parse(Console.ReadLine());
                Console.Write("Costo de maná: ");
                int poderMana = int.Parse(Console.ReadLine());
                jugador.Poderes.Add(new Poder(poderNombre, poderDaño, poderMana));
            }

            
            Console.WriteLine("Crea items:");
            Console.Write("¿Cuántos items quieres crear?: ");
            int numItems = int.Parse(Console.ReadLine());
            for (int i = 0; i < numItems; i++)
            {
                Console.Write("Nombre del item: ");
                string itemNombre = Console.ReadLine();
                Console.Write("Curación del item: ");
                int itemHealing = int.Parse(Console.ReadLine());
                Console.Write("Recuperación de mana: ");
                int itemManaRestore = int.Parse(Console.ReadLine());
                jugador.Items.Add(new Item(itemNombre, itemHealing, itemManaRestore));
            }

            
            Console.WriteLine("Crea enemigos:");
            Console.Write("¿Cuántos enemigos?: ");
            int numEnemigos = int.Parse(Console.ReadLine());
            List<Enemigo> enemigos = new List<Enemigo>();
            for (int i = 0; i < numEnemigos; i++)
            {
                Console.Write("Nombre del enemigo: ");
                string enemigoNombre = Console.ReadLine();
                Console.Write("Vida del enemigo (máx 100): ");
                int enemigoVida = int.Parse(Console.ReadLine());
                if (enemigoVida > 100) enemigoVida = 100;
                Console.Write("Ataque del enemigo: ");
                int enemigoAtaque = int.Parse(Console.ReadLine());
                Console.Write("Tipo del enemigo (melee/rango): ");
                string tipoDeEnemigo = Console.ReadLine();
                enemigos.Add(new Enemigo(enemigoNombre, enemigoVida, enemigoAtaque, tipoDeEnemigo));
            }

            
            while (jugador.Vida > 0 && enemigos.Count > 0)
            {
                
                Console.WriteLine("Es tu turno. ¿Qué quieres hacer?");
                Console.WriteLine("1. Usar un item");
                Console.WriteLine("2. Atacar a un enemigo");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("Elige un item:");
                    for (int i = 0; i < jugador.Items.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + jugador.Items[i].Name);
                    }
                    int itemIndex = int.Parse(Console.ReadLine()) - 1;
                    jugador.UsarItem(jugador.Items[itemIndex]);
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("Elige un enemigo para atacar:");
                    for (int i = 0; i < enemigos.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + enemigos[i].Nombre + " (Vida: " + enemigos[i].Vida + ")");
                    }
                    int enemigoIndex = int.Parse(Console.ReadLine()) - 1;
                    Enemigo enemigo = enemigos[enemigoIndex];

                    Console.WriteLine("Elige tu ataque:");
                    Console.WriteLine("1. Ataque normal");
                    Console.WriteLine("2. Usar un poder");
                    string ataque = Console.ReadLine();

                    if (ataque == "1")
                    {
                        jugador.Atacar(enemigo);
                    }
                    else if (ataque == "2")
                    {
                        Console.WriteLine("Elige un poder:");
                        for (int i = 0; i < jugador.Poderes.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + jugador.Poderes[i].nombreDelPoder);
                        }
                        int poderIndex = int.Parse(Console.ReadLine()) - 1;
                        jugador.UsarPoder(jugador.Poderes[poderIndex], enemigo);
                    }

                    if (enemigo.EstaMuerto())
                    {
                        Console.WriteLine(enemigo.Nombre + " ha muerto.");
                        enemigos.RemoveAt(enemigoIndex);
                    }
                }

                if (enemigos.Count == 0)
                {
                    Console.WriteLine("¡Has ganado!");
                    break;
                }

                
                foreach (var enemigo in enemigos)
                {
                    if (!jugador.EstaMuerto())
                    {
                        enemigo.Atacar(jugador);
                    }
                    else
                    {
                        Console.WriteLine(jugador.Nombre + " ha muerto. Fin del juego.");
                        break;
                    }
                }

                if (jugador.EstaMuerto())
                {
                    Console.WriteLine("Has perdido.");
                    break;
                }
            }

            Console.WriteLine("Presiona una tecla para salir.");
            Console.ReadKey();
        }
    }
}
