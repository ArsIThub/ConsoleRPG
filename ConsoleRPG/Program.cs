namespace ConsoleRPG
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.Write("Введите имя вашего героя: ");
            string heroName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Выберите класс героя:");
            Console.WriteLine("1 - Воин");
            Console.WriteLine("2 - Маг");
            Console.WriteLine("3 - Лучник");

            int classChoice = Convert.ToInt32(Console.ReadLine());
            Hero hero = null;

            switch (classChoice)
            {
                case 1:
                    hero = new Hero(heroName, "Воин", 100, 50, 5);
                    break;
                case 2:
                    hero = new Hero(heroName, "Маг", 70, 25, 35);
                    break;
                case 3:
                    hero = new Hero(heroName, "Лучник", 120, 40, 10);
                    break;
            }

            hero.VievStat();

            while (hero.Wins < 15 && hero.Health > 0)
            {
                Console.WriteLine();
                Monster monster = CreationMonster();
                Console.WriteLine($"На вас напал {monster.Name}, его здоровье: {monster.Health}, урон: {monster.AttackPower}");

                Battle(hero, monster);

                if (hero.Health <= 0)
                {
                    break;
                }
                else
                {
                    hero.Wins++;
                    int expGained = rnd.Next(1, 100);
                    hero.Experience += expGained;
                    Console.WriteLine($"Вы получили {expGained} опыта, всего опыта: {hero.Experience}");

                    Console.WriteLine("Хотите восстановить часть здоровья? (Да/Нет)");
                    string resp = Console.ReadLine().ToLower();
                    if (resp == "да")
                    {
                        hero.RestoreHealth();
                        hero.VievStat();
                    }
                    CheckLvlUp(hero);
                    Console.WriteLine();
                }
            }

            if (hero.Health <= 0)
            {
                Console.WriteLine("Вы проиграли");
            }
            else if (hero.Wins >= 15)
            {
                Console.WriteLine("Вы выиграли!");
            }
        }

        static Monster CreationMonster()
        {
            string[] monsterNames = { "Вампир", "Призрак", "Скелет" };
            string name = monsterNames[rnd.Next(monsterNames.Length)];
            int health = rnd.Next(50, 100);
            int attack = rnd.Next(10, 30);
            return new Monster(name, health, attack);
        }

        static void Battle(Hero hero, Monster monster)
        {
            while (hero.Health > 0 && monster.Health > 0)
            {
                Console.WriteLine();
                int damage = hero.AttackPower;

                double critRoll = rnd.NextDouble() * 100;
                if (critRoll <= hero.CritChance)
                {
                    damage *= 2;
                    Console.WriteLine("Крит!");
                }

                monster.Health -= damage;
                Console.WriteLine($"Вы атакуете {monster.Name} и наносите {damage} урона, здоровье монстра: {monster.Health}");

                if (monster.Health <= 0)
                {
                    Console.WriteLine($"{monster.Name} убит");
                    break;
                }

                hero.Health -= monster.AttackPower;
                Console.WriteLine($"{monster.Name} атакует и наносит {monster.AttackPower} урона, здоровье героя: {hero.Health}");
            }
            Console.WriteLine();
            hero.VievStat();
        }

        static void CheckLvlUp(Hero hero)
        {
            int[] experienceForLvlUp = { 0, 100, 250, 500, 1000, 2000 };
            int newLevel = hero.Level;
            for (int i = experienceForLvlUp.Length - 1; i > 0; i--)
            {
                if (hero.Experience >= experienceForLvlUp[i])
                {
                    newLevel = i + 1;
                    break;
                }
            }
            if (newLevel > hero.Level)
            {
                Console.WriteLine();
                Console.WriteLine($"Вы достигли {newLevel} уровня!");
                hero.Level = newLevel;

                Console.WriteLine("Улучшите одну характеристику: ");
                Console.WriteLine("1 - Здоровье");
                Console.WriteLine("2 - Сила атаки");
                Console.WriteLine("3 - Шанс критического удара");
                int choice = Convert.ToInt32(Console.ReadLine());
                hero.LevelUp(choice);
                hero.VievStat();
            }
        }
    }
}