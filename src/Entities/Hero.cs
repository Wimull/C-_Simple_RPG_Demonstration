namespace RPG_Game.src.Entities
{
    public abstract class Hero
    {

        public Hero(string Name, int Level, string HeroType)
        {

            this.Name = Name;
            this.Level = Level;
            this.HeroType = HeroType;
            this.BaseAttack = (int)Math.Floor(Level * 1.5);
            this.MaxHealth = Level * 10;
            this.Health = MaxHealth;
            this.MaxMana = (int)Math.Floor(Level * 1.2);
            this.Mana = MaxMana;
            this.Spells = new double[4][]{
                new double[] {},
                new double[] {},
                new double[] {},
                new double[] {},
            };
        }
        public Hero()
        {
            this.Spells = new double[4][]{
                new double[] {},
                new double[] {},
                new double[] {},
                new double[] {},
            };
        }
        public double[][] Spells;
        public string? Name;
        public int? Level;
        public string? HeroType;
        public int BaseAttack;
        public int MaxHealth;
        public int Health;
        public int MaxMana;
        public int Mana;


        public override string ToString()
        {
            return $"Name: {this.Name}\tLevel:{this.Level}\tClass:{this.HeroType}\n{this.Health}/{this.MaxHealth}HP\t{this.Mana}/{this.MaxMana}MP\n";

        }
        public virtual string Attack(Hero Target)
        {
            int damage = this.BaseAttack;
            Target.UpdateHP(damage);
            return $"{this.Name} atacou {Target.Name} dando {damage} de dano.\n";
        }
        public void UpdateHP(int Attack)
        {
            this.Health -= Attack;
        }
        public void UpdateMP(int ManaCost)
        {
            this.Mana -= ManaCost;
        }
        protected class Spell
        {
            public Spell(int name, int damage, int MPCost, bool targetAllies = false, bool fixedDamage = false)
            {
                this.Name = name;
                this.BaseDamage = damage;
                this.MPCost = MPCost;
                this.TargetAllies = targetAllies;
                this.FixedDamage = fixedDamage;
            }
            public int Name;
            private int BaseDamage;
            private int MPCost;
            private bool TargetAllies;
            private bool FixedDamage;

            public double[] CastSpell()
            {
                Random rnd = new Random();
                double Bonus = rnd.Next(1, 4);
                Bonus /= 2;
                if (FixedDamage) Bonus = 1;
                return new double[] { Name, ((double)BaseDamage * Bonus), Bonus, MPCost };
            }
        }
    }
}