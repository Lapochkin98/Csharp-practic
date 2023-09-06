using System;

namespace Day10Tasks.Tasks
{
    public class Day10Class
    {
        
    }
    
    interface IEnemy
    {
        int Hp { get; set; }
        int Lvl { get; set; }
        void DealDamage(Hero hero);
    }

    class Hero
    {
        public readonly string Name;
        public int Hp;

        public Hero(string name, int hp)
        {
            Name = name;
            Hp = hp;
        }

        public void RestoreHealth()
        {
            Random rnd = new Random();
            int healthRestored = rnd.Next(10, 21);
            Hp += healthRestored;
            Console.WriteLine("{0} restored {1} health points", Name, healthRestored);
        }
    }

    class Zombie : IEnemy
    {
        public int Hp { get; set; }
        public int Lvl { get; set; }

        public Zombie(int level, int healthPoints)
        {
            Lvl = level;
            Hp = healthPoints;
        }

        public void DealDamage(Hero hero)
        {
            double damage = Lvl * 1.3 + 0.1 * Hp;
            Console.WriteLine("Zombie dealt {0} damage to {1}", damage, hero.Name);
            hero.Hp -= (int)damage;
        }
    }

    class Gargoyle : IEnemy
    {
        public int Hp { get; set; }
        public int Lvl { get; set; }

        public Gargoyle(int level, int healthPoints)
        {
            Lvl = level;
            Hp = healthPoints;
        }

        public void DealDamage(Hero hero)
        {
            double damage = Lvl * 2 + 0.2 * Hp;
            Console.WriteLine("Gargoyle dealt {0} damage to {1}", damage, hero.Name);
            hero.Hp -= (int)damage;
        }
    }

    class Vampire : IEnemy
    {
        public int Hp { get; set; }
        public int Lvl { get; set; }

        public Vampire(int level, int healthPoints)
        {
            Lvl = level;
            Hp = healthPoints;
        }

        public void DealDamage(Hero hero)
        {
            double damage = Lvl * 1.5 + 0.15 * Hp - 10;
            Console.WriteLine("Vampire dealt {0} damage to {1}", damage, hero.Name);
            hero.Hp -= (int)damage;
        }
    }
}