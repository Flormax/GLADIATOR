using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    /*Class où sont stockées toutes les données relatives aux armes:
    * poids, pourcentage de réussité/blocage, initiative
    * + une fonction de génération d'un pourcentage aélatoire pour procéder aux tests en fonction des pourcentage des réussite
    */
	public static class Stuff
	{
		public static Dictionary<string,int> Pods = new Dictionary<string,int> () {
			{ "Dagger", 2 },
			{ "Net", 3 },
			{ "Sword", 5 },
			{ "Lance", 7 },
			{ "Trident", 7 },
			{ "Helmet", 2 },
			{ "Small shield", 5 },
			{ "Big shield", 8 }
		};

		public static Dictionary<string,int> HitRate = new Dictionary<string,int> () {
			{ "Dagger", 60 },
			{ "Net", 30 },
			{ "Sword", 70 },
			{ "Lance", 50 },
			{ "Trident", 40 }
		};

		public static Dictionary<string,int> BlockRate = new Dictionary<string,int> () {
			{ "Helmet", 10 },
			{ "Small shield", 20 },
			{ "Big shield", 30 },
			{ "Trident", 10 }
		};

		public static Dictionary<string,int> Initiative = new Dictionary<string,int> () {
			{ "Dagger", 1 },
			{ "Net", 5 },
			{ "Sword", 2 },
			{ "Lance", 4 },
			{ "Trident", 3 }
		};

		public static Random Rate = new Random();

		public static int getPercentage(){
			int res = Rate.Next (101);
			//Console.WriteLine ("Rand: " + res);
			return res;
		}
	}
}

