namespace ConsoleRPG
{
    public class Monster
    {
        public string Name;
        public int Health;
        public int AttackPower;

        public Monster(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }
    }
}
