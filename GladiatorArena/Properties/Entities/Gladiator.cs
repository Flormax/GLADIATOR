using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    //Class dédiée aux gladiateurs
    public class Gladiator : Entity
    {
        private List<string> _Weapons;
        private List<string> _Armors;
        private int _StuffWeight;
        private int _FightOrder;
        private double _HitRate = 1; //Si il y a utilisation d'un filet, on viendra modifier cette valeur

        public List<string> Weapons
        {
            get { return _Weapons; }
        }


        public Gladiator(string name, int fightOrder)
        {
            this._Name = name;
            this._FightOrder = fightOrder;
            this._StuffWeight = 0;
            this._Weapons = new List<string>();
            this._Armors = new List<string>();
        }

        //Classement décroissant des armes par initiative
        public void SortWeaponByIni()
        {
            bool end = false;
            int WeaponsCount = this.Weapons.Count;

            while (!end)
            {
                end = true;
                for (int i = 0; i < WeaponsCount - 1; i++)
                {
                    if (Stuff.Initiative[this.Weapons[i]] < Stuff.Initiative[this.Weapons[i + 1]])
                    {
                        string temp = this.Weapons[i];
                        this.Weapons[i] = this.Weapons[i + 1];
                        this.Weapons[i + 1] = temp;
                        end = false;
                    }
                }
                WeaponsCount--;
            }
        }

        //Fonction d'ajout d'un équipement
        public void AddItem(string item)
        {
            if (this._StuffWeight + Stuff.Pods[item] > 10)
            {
                /*
                * Si on avait un menu de création de gladiateur, 
                * renvoi vers la liste d'équipement sans ajouter "item"
                */
                ErrorMessage("'s stuff is too heavy");
            }
            else
            {
                //Si c'est une arme, ajout à la liste d'arme
                if (Stuff.HitRate.ContainsKey(item))
                {
                    //Si le gladiateur a moins de deux armes, ou 2 armes en comptant un filet
                    if (this._Weapons.Count < 2 || (this._Weapons.Count == 2 && this._Weapons.Contains("Net")))
                    {
                        this._Weapons.Add(item);
                    }
                    //Sinon, le gladiateur a donc 2 armes et pas de filet, si l'item est un filet on l'ajoute
                    else if (item == "Net")
                    {
                        this._Weapons.Add("Net");
                    }
                    //Si ce n'est pas un filet, le gladiateur à son compte d'arme, message d'erreur
                    else
                    {
                        ErrorMessage(" already got 2 weapons, he can't have more");
                    }
                }
                //Sinon, c'est une armure, ajout à la liste d'armures
                else if (Stuff.BlockRate.ContainsKey(item))
                {
                    //Si le gladiateur possède déjà ce type d'armure
                    if (this._Armors.Contains(item))
                    {
                        ErrorMessage(" can't get 2 same armors");
                    }
                    else
                    {
                        this._Armors.Add(item);
                    }
                }

                //Incrémentation du poids total des équipements
                this._StuffWeight += Stuff.Pods[item];
            }
        }

        //Fonction passe d'arme, on génère des attaques jusqu'a obtenir un gagnant
        public Entity Trade(Entity entity)
        {
            Entity winner = null;
            Gladiator ennemy = (Gladiator)entity;
            bool firstRound = true; //Si premier tour, utilisation des filets

            while (winner == null)
            {
                if (firstRound) this.UseNet(ennemy);
                if (this.Attack(ennemy) == ennemy)
                {
                    if (firstRound) ennemy.UseNet(this);
                    if (ennemy.Attack(this) == ennemy)
                    {
                        winner = ennemy;
                    }
                }
                else
                {
                    winner = this;
                }
                firstRound = false;
            }
            return winner;
        }

        //Fonction d'utilisation du filet
        private void UseNet(Gladiator ennemy)
        {
            if (this._Weapons.Contains("Net"))
            {
                Console.WriteLine(this.Name + " uses Net ! \n" + ennemy.Name + " gets 50% hite rate malus.");
                ennemy._HitRate = 0.5;
            }
        }

        //Fonction attaque, le gladiateur attaquant attaque le défenseur avec chacune de son/ses arme(s)
        public Entity Attack(Entity entity)
        {
            Gladiator ennemy = (Gladiator)entity;

            /*
            * On boucle sur les armes de l'attaquant
            * Si l'attaquant à un filet, on l'ignore, le filet étant géré dans la passe d'arme (une seule utilisation par passe d'arme)
            * On déclenche la capacité de blocage ici
            */
            for (int i = (this.Weapons.Contains("Net") ? 1 : 0); i < this.Weapons.Count; i++)
            {
                Console.WriteLine(this._Name + " attack " + ennemy.Name + " with " + this.Weapons[i] + "!");
                //Console.WriteLine ("Hit rate: " + Stuff.HitRate [this.Weapons[i]] * this._DamageRate + "%");
                if (Stuff.getPercentage() <= Stuff.HitRate[this.Weapons[i]] * this._HitRate)
                {
                    if (ennemy.Block(this))
                    {
                        Console.WriteLine(ennemy.Name + " blocked the attack !");
                    }
                    else
                    {
                        Console.WriteLine("It's super effective !  " + ennemy.Name + " dies..\n");
                        //Retourne le gladiateur courant (attaquant) s'il tue l'ennemi
                        return this;
                    }
                }
                else
                {
                    Console.WriteLine(this._Name + " missed his attack..\n");
                }
            }
            //Retourne l'ennemi si l'attaquant n'est pas parvenu à le tuer
            return ennemy;
        }


        //Fonction blocage, retourne TRUE si l'attaque est bloquée, sinon FALSE
        public bool Block(Gladiator ennemy)
        {
            if (this._Armors.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (string armor in this._Armors)
                {
                    //Console.WriteLine ("BlockRate: " + Stuff.BlockRate [armor] + "%");
                    if (Stuff.getPercentage() <= Stuff.BlockRate[armor])
                    {
                        Console.WriteLine(this.Name + " uses " + armor + " !");
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

