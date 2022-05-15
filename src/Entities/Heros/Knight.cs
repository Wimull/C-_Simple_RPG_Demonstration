namespace RPG_Game.src.Entities
{
    public class Knight : Hero
    {
        public Knight(string Name, int Level, string HeroType)
        {
            this.Name = Name;
            this.Level = Level;
            this.HeroType = HeroType;
            this.BaseAttack = (int)Math.Floor(Level * 2.5);
            this.MaxHealth = Level * 12;
            this.Health = MaxHealth;
            this.MaxMana = (int)Math.Floor(Level * 1.1);
            this.Mana = MaxMana;
        }

    }
}