using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    //Class dédiée aux équipes
    public class Team : Entity
    {
        private string _Descr;
        private List<Gladiator> _Gladiators;

        public List<Gladiator> Gladiators
        {
            get { return _Gladiators; }
        }

        public string Descr
        {
            get { return _Descr; }
        }

        public Team(string name, string descr)
        {
            this.Name = name;
            this._Descr = descr;
            this._Gladiators = new List<Gladiator>();
        }

        //Fonction d'ajout de gladiateurs pour gérer le nombre de gladiateurs et d'armes qu'ils possèdes
        public void AddGlad(Gladiator glad)
        {
            if (this.Gladiators.Count < 3)
            {
                while (glad.Weapons.Count == 0 || (glad.Weapons.Count == 1 && glad.Weapons[0] == "Net"))
                {
                    ErrorMessage(": " + glad.Name + " must have a least one weapon (he can't either fight with only a net)");
                }
                glad.SortWeaponByIni();
                this.Gladiators.Add(glad);
            }
            else
            {
                ErrorMessage(": You can't have more than 3 gladiators per team !");
            }
        }
    }
}

