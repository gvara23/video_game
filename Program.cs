using System.ComponentModel;

namespace video_game
{
    public class Character
    {
        public string Name { get; set; }
        public int HealthPoints { get; set; }
        public int AttackPoints { get; set; }
        public int DefensePoints { get; set; }

        public bool isAlive()
        {
            return HealthPoints > 0;
        }
        public void Attack(Character opponent)
        {
            if (opponent != this)
            {
                int damage = Math.Max(0, AttackPoints - opponent.DefensePoints);
                opponent.HealthPoints -= damage;
                Console.WriteLine($"{Name} attacks {opponent.Name} and inflicts {damage} damage.");

                if (!opponent.isAlive())
                {
                    Console.WriteLine($"{opponent.Name} has been defeated!");
                }
            }
            else
            {
                Console.WriteLine("A character can't attack itself ! ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Character Hercules = new Character
            {
                Name = "Hercules",
                HealthPoints = 100,
                AttackPoints = 30,
                DefensePoints = 10,
            };

            Character Minotaur = new Character
            {
                Name = "Minotaur",
                HealthPoints = 150,
                AttackPoints = 28,
                DefensePoints = 15,
            };

            while (Hercules.isAlive() && Minotaur.isAlive())
            {
                Hercules.Attack(Minotaur);
                if (Minotaur.isAlive())
                {
                    Minotaur.Attack(Hercules);
                }
            }

            if (Hercules.isAlive())
            {
                Console.WriteLine($"{Hercules.Name} wins the battle!");
            }
            else if (Minotaur.isAlive())
            {
                Console.WriteLine($"{Minotaur.Name} wins the battle!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }
}