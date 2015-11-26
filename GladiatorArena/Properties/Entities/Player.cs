using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    //Class dédiée aux joueurs
	public class Player : Entity
	{
		private string _Lastname;
		private string _Pseudo;
		private DateTime _InscrDate;
		private List<Team> _Teams;

		public List<Team> Teams {
			get { return _Teams; }
		}

        public string Lastname
        {
            get { return _Lastname; }
            set { _Lastname = value; }
        }

        public string Pseudo
        {
            get { return _Pseudo; }
            set { _Pseudo = value; }
        }

        public DateTime InscrDate
        {
            get { return _InscrDate; }
        }

        public Player (string name, string lastname, string pseudo)
		{
			this._Name = name;
			this.Lastname = lastname;
			this._Pseudo = pseudo;
			this._InscrDate = new DateTime ();
			this._Teams = new List<Team> ();
		}

        public void addTeam(Team team)
        {
            if(this._Teams.Count < 5)
            {
                this._Teams.Add(team);
            } else
            {
                Console.WriteLine("You can't have more than 5 teams !");
            }
        }
	}
}

