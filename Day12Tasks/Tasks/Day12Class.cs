using System;
using static System.Console;

namespace Day12Tasks.Tasks
{
    public class Day12Class
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
        private bool _criticalState;
        public readonly string Name;
        private int _hp;

        public delegate void CriticalHealth(string message);
        public event CriticalHealth CriticalHealthLevelReached;
        public event CriticalHealth SufficientlyHealed;

        public int Hp
        {
            get => _hp;
            set
            {
                if (value != _hp)
                {
                    _hp = value;
                    if (_hp <= 10 && _criticalState == false)
                    {
                        _criticalState = true;
                        BackgroundColor = ConsoleColor.Red;
                        ForegroundColor = ConsoleColor.White;
                        CriticalHealthLevelReached?.Invoke( $"{Name} reached critical health level ({_hp})");
                    }
                    else if (_hp >= 20)
                    {
                        _criticalState = false;
                        ResetColor();
                        SufficientlyHealed?.Invoke($"{Name} has been sufficiently healed ({_hp})");
                    }
                }
            }
        }

        public Hero(string name, int hp)
        {
            Name = name;
            Hp = hp;
        }

        public void RestoreHealth()
        {
            Random rnd = new Random();
            int healthRestored = rnd.Next(10, 50);
            Hp += healthRestored;
            WriteLine("{0} restored {1} health points", Name, healthRestored);
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
            WriteLine("Zombie dealt {0} damage to {1}", damage, hero.Name);
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
            WriteLine("Gargoyle dealt {0} damage to {1}", damage, hero.Name);
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
            WriteLine("Vampire dealt {0} damage to {1}", damage, hero.Name);
            hero.Hp -= (int)damage;
        }
    }
}