namespace ConsoleRPG
{
    public class Hero
    {
        public string Name;
        public string ClassName;
        public int MaxHealth;
        public int Health;
        public int AttackPower;
        public double CritChance;
        public int Experience;
        public int Level;
        public int Wins;
        public int RestoresLeft;

        public Hero(string name, string className, int maxHealth, int attackPower, double critChance)
        {
            Name = name;
            ClassName = className;
            MaxHealth = maxHealth;
            Health = MaxHealth;
            AttackPower = attackPower;
            CritChance = critChance;
            Experience = 0;
            Level = 1;
            Wins = 0;
            RestoresLeft = 5;
        }

        public void LevelUp(int stat)
        {
            if (stat == 1)
            {
                MaxHealth += 30;
            }
            else if (stat == 2)
            {
                AttackPower += 10;
            }
            else if (stat == 3)
            {
                CritChance += 5;
            }
        }

        public void RestoreHealth()
        {
            if (RestoresLeft > 0)
            {
                Console.WriteLine();
                Health = MaxHealth;
                RestoresLeft--;
                Console.WriteLine($"Здоровье восстановлено");
            }
        }

        public void VievStat()
        {
            Console.WriteLine();
            Console.WriteLine("Ваши статы: ");
            Console.WriteLine($"Здоровье: {Health}/{MaxHealth}");
            Console.WriteLine($"Атака: {AttackPower}");
            Console.WriteLine($"Шанс крита: {CritChance}");
        }
    }
}
