using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    //Classe d'équipe contre équipe
    public class TvT : Match
    {
        public TvT(Team t1, Team t2)
            : base(t1, t2)
        { }

        public override Entity PlayMatch()
        {
            //On récupère les 2 équipes et les gladiateurs associés
            Team t1 = (Team)this._Part1;
            Team t2 = (Team)this._Part2;

            List<Gladiator> GladT1 = t1.Gladiators;
            List<Gladiator> GladT2 = t2.Gladiators;
            GvG gvg = new GvG(GladT1[0], GladT2[0]);
            int cptGvg = 1;

            Console.WriteLine("______________________________________________________________\n");

            //On joue chaque combat jusqu'a ce qu'une équipe soit à cours de gladiateurs
            while (GladT1.Count > 0 && GladT2.Count > 0)
            {
                //On joue chaque match GvG, et on efface le perdant, pour lancer le match suivant
                gvg.Part1 = GladT1[0];
                gvg.Part2 = GladT2[0];
                Console.WriteLine("-> Fight n°" + cptGvg + ": " + gvg.Part1.Name + " vs " + gvg.Part2.Name + "\n");
                if (gvg.PlayMatch() == GladT1[0])
                {
                    GladT2.RemoveAt(0);
                }
                else
                {
                    GladT1.RemoveAt(0);
                }
                cptGvg++;
                Console.WriteLine("______________________________________________________________\n");
            }
            return Winner(GladT1.Count == 0 ? this._Part2 : this._Part1);
        }
    }
}