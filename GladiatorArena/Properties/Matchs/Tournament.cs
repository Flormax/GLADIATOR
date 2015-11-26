using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    //Class tournoi, organise les matchs entre les équipes les plus fortes jusqu'a l'obtention du vainqueur
    public class Tournament
    {
        private List<Team> _Teams = new List<Team>();
        private List<Match> _Matchs;

        public Tournament(List<Team> teams)
        {
            foreach (Team team in teams)
            {
                if (team.Gladiators.Count != 3)
                {
                    ErrorMessage(team.Name + " needs to get more gladiators to start a tournament");
                }
                this.addTeamToTournament(team);
            }
            if (this._Teams.Count % 4 != 0)
            {
                ErrorMessage("Tournament needs at least 4 teams, or a 4 multiple !");
            }

            //Si tout est OK, on crée le tournoi
            this._Teams = SortTeamByWinrate(this._Teams);
            this._Matchs = new List<Match>();
        }

        public Tournament()
        {

        }

        //Fonction d'ajout d'une équipe au tournoi
        public void addTeamToTournament(Team team)
        {
            if (this._Teams.IndexOf(team) == -1)
            {
                this._Teams.Add(team);
            }
            else
            {
                Console.WriteLine(team.Name + " is already registred in this tournament");
            }

        }

        //Fonction de tri d'équipe par taux de victoire
        private List<Team> SortTeamByWinrate(List<Team> teams)
        {
            int teamsCount = teams.Count;
            bool end = false;

            while (!end)
            {
                end = true;
                for (int i = 0; i < teamsCount - 1; i++)
                {
                    if (teams[i].WinRate < teams[i + 1].WinRate)
                    {
                        Team temp = teams[i];
                        teams[i] = teams[i + 1];
                        teams[i + 1] = temp;
                        end = false;
                    }
                }
                teamsCount--;
            }
            return teams;
        }

        //Création de la liste de match, les équipes sont déjà ordonnées, on génère les matchs avec chaque duo d'équipe à la suite
        private void GenerateMatchsList(List<Team> teams)
        {
            this._Matchs.Clear();
            if (teams.Count == 2)
            {
                this._Matchs.Add(new TvT(teams[0], teams[1]));
            }
            else
            {
                for (int i = 0; i < teams.Count; i += 2)
                {
                    this._Matchs.Add(new TvT(teams[i], teams[i + 1]));
                }
            }
        }

        //Déroulement du tournois
        public void StartTournament()
        {
            Team Loser = new Team("loser", "bouuuuh, L");

            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤_GLADIATOR ARENA TOURNAMENT_¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤\n");
            for (int i = 0; i < this._Teams.Count; i++)
            {
                Console.WriteLine("             Team n°" + (i + 1) + ": " + this._Teams[i].Name + " (winrate: " + this._Teams[i].WinRate + "%)");
            }

            int cptMatch = 1;

            //Tant qu'il reste plus d'un équipe, on les fais s'affronter
            while (this._Teams.Count >= 2)
            {
                //On met a jour la liste de match à chaque tour, avec la liste d'équipe à laquelle ont été soustrait les perdants
                GenerateMatchsList(this._Teams);

                //On joue chaque match en retirant le perdant de la liste d'équipe
                foreach (TvT tvt in this._Matchs)
                {
                    Console.WriteLine("\n**************************************************************");
                    Console.WriteLine("\n              Match n°" + cptMatch + ": " + tvt.Part1.Name + " vs " + tvt.Part2.Name);
                    Loser = (Team)(tvt.PlayMatch() == tvt.Part1 ? tvt.Part2 : tvt.Part1);
                    this._Teams.Remove(Loser);
                    cptMatch++;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤\n");
            Console.WriteLine("          ...;*'°¤$WINNER OF THE TOURNAMENT$¤°'*;...\n");
            Console.WriteLine("                          " + this._Teams[0].Name);

        }

        private void ErrorMessage(string Message)
        {
            Console.WriteLine(Message);
            Console.WriteLine("For the moment, you can modify tournament in Test.cs !\nPress any key to quit.");
            Console.Read();
            Environment.Exit(0);
        }
    }
}