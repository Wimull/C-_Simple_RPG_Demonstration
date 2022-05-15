namespace RPG_Game.src.Entities
{
    public class Wizard : Hero
    {
        public Wizard(string Name, int Level, string HeroType)
        {
            this.Name = Name;
            this.Level = Level;
            this.HeroType = HeroType;
            this.BaseAttack = (int)Math.Floor(Level * 1.2);
            this.MaxHealth = Level * 8;
            this.Health = MaxHealth;
            this.MaxMana = Level * 13;
            this.Mana = MaxMana;
            this.Spells = new double[4][];
        }




        public override string Attack(Hero Target)
        {
            int damage = this.BaseAttack;
            Target.UpdateHP(damage);
            return $"{this.Name} lançou uma magia comum dando {damage} de dano em {Target.Name}.\n";
        }
        public string CastSpell(Hero Target, int SpellSlot)
        {
            var CastSpell = Spells[SpellSlot];
            string name = Enum.GetName(typeof(SpellName), (int)CastSpell[0])!;
            double damage = CastSpell[1];
            double Bonus = CastSpell[2];

            Target.UpdateHP((int)Math.Floor(damage));
            this.UpdateMP((int)CastSpell[3]);
            if (Bonus > 2)
            {
                return $"{this.Name} lançou uma magia super efetiva com bonus de {Bonus}X dando {damage} de dano em {Target.Name}.\n";
            }
            else if (Bonus < 1)
            {
                return $"{this.Name} lançou uma magia com força fraca com bonus de {Bonus}X dando {damage} de dano em {Target.Name}.\n";
            }
            else if (Bonus == 1.5)
            {
                return $"{this.Name} lançou uma magia forte com bonus de {Bonus}X dando {damage} de dano em {Target.Name}.\n";
            }
            {
                return $"{this.Name} lançou uma magia normal com bonus de {Bonus}X dando {damage} de dano em {Target.Name}.\n";
            }
        }
        public void AdquireSpell(string name, int damage, int MPCost, int slot, bool targetAllies = false, bool fixedDamage = false)
        {
            if (!Enum.IsDefined(typeof(SpellName), name))
            {
                Console.WriteLine("Spell não existe para esta classe.");
                return;
            }
            var spellName = Enum.Parse(typeof(SpellName), name);

            Spell spell = new Spell((int)spellName, damage, MPCost, targetAllies, fixedDamage);
            Spells[slot] = spell.CastSpell();

        }
        enum SpellName
        {
            Cure,
            Libra,
            Poisona,
            Holy

        }
    }
}