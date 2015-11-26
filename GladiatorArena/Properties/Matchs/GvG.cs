using System;

namespace GladiatorArena
{
    //Class de combat entre gladiateur
    public class GvG : Match
    {
        public GvG(Gladiator g1, Gladiator g2)
            : base(g1, g2)
        { }

        public GvG()
        { }

        //Execution du match avec détermination du premier tour en fonction de l'initiative des armes
        public override Entity PlayMatch()
        {
            Gladiator g1 = (Gladiator)this._Part1;
            Gladiator g2 = (Gladiator)this._Part2;

            //Si g1 à une arme plus haute en initiative, il commence
            if (Stuff.Initiative[g1.Weapons[0]] > Stuff.Initiative[g2.Weapons[0]])
            {
                return (Winner(g1.Trade(g2)));
                //Sinon c'est g2
            }
            else if (Stuff.Initiative[g1.Weapons[0]] < Stuff.Initiative[g2.Weapons[0]])
            {
                return (Winner(g2.Trade(g1)));
            }
            else
            {
                //Si les deux gladiateurs ont la même armes, tirage au sort équitable pour le premier tour
                Console.WriteLine(g1.Name + " and " + g2.Name + " both have a " + g1.Weapons[0]);
                Console.WriteLine("->Random choice for first");
                if (Stuff.getPercentage() > 50)
                {
                    Console.WriteLine(g1.Name + " first:\n");
                    return (Winner(g1.Trade(g2)));
                }
                else
                {
                    Console.WriteLine(g2.Name + " first:\n");
                    return (Winner(g2.Trade(g1)));
                }
            }
        }
    }
}

