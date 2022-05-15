using RPG_Game.src.Entities;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            Knight arus = new Knight("Arus", 20, "Knight");
            Wizard wizard = new Wizard("Jennica", 23, "White Wizard");
            wizard.AdquireSpell("Holy", 50, 80, 0, false, false);
            Console.WriteLine(arus.Attack(wizard));
            Console.WriteLine(wizard.CastSpell(arus, 0));
            Console.WriteLine("\nResultado do combate: \n");
            Console.WriteLine(wizard.ToString());
            Console.WriteLine(arus.ToString());

        }
    }
}