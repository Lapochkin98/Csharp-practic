using System.Collections.Generic;
using Day12Tasks.Tasks;
using static System.Console;

namespace Day12Tasks
{
    internal static class Program
    {
        private static void Show(string message)
        {
            WriteLine(message);
        }
        public static void Main(string[] args)
        {
            Hero hero = new Hero ("Nikitos", 50);
            hero.CriticalHealthLevelReached += Show;
            hero.SufficientlyHealed += Show;
            List<IEnemy> enemies = new List<IEnemy>
            {
                new Zombie(5, 50),
                new Gargoyle(7, 70),
                new Vampire(10, 100)
            };

            while (hero.Hp > 0)
            {
                foreach (IEnemy enemy in enemies)
                {
                    enemy.DealDamage(hero);
                    if (hero.Hp <= 0)
                        break;
                }
                hero.RestoreHealth();
            }

            WriteLine("{0} has died", hero.Name);
        }
    }
}