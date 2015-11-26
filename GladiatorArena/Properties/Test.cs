using System;
using System.Collections.Generic;

namespace GladiatorArena
{
    public class Test
    {
        public Test()
        {
            //Instanciation des joueurs avec des matchs pour le winRate
            Player Max = new Player("FLORILE", "Maxime", "Zywo");
            Player Cam = new Player("ALLES", "Camille", "Kaoumlya");
            Player Ben = new Player("DESMET", "Benjamin", "Yela");
            Player Kwi = new Player("QUERON", "Quentin", "Kwintyn");
            Max.Victories = 5;
            Max.Defeats = 3;
            Cam.Victories = 2;
            Cam.Defeats = 1;
            Ben.Victories = 3;
            Ben.Defeats = 0;
            Kwi.Victories = 5;
            Kwi.Defeats = 3;

            //Instanciation des teams avec des matchs pour le winRate et le matchMaking
            Team ZyT1 = new Team("Team Zywo", "La team de Zywo alias Maxime");
            Team KaT1 = new Team("Team Kamoulya", "La team de Kamoulya alias Camille");
            Team YeT1 = new Team("Team Yela", "La team de Yela alias Benjamin");
            Team KwT1 = new Team("Team Kwintyn", "La team de Kwintyn alias Quentin");
            ZyT1.Victories = 2;
            ZyT1.Defeats = 1;
            KaT1.Victories = 2;
            KaT1.Defeats = 3;
            YeT1.Victories = 5;
            YeT1.Defeats = 1;
            KwT1.Victories = 0;
            KwT1.Defeats = 3;

            //Instanciation des gladiateurs
            Gladiator ZyGla1 = new Gladiator("Zywo_Glad_1", 1);
            Gladiator ZyGla2 = new Gladiator("Zywo_Glad_2", 2);
            Gladiator ZyGla3 = new Gladiator("Zywo_Glad_3", 3);
            Gladiator KaGla1 = new Gladiator("Kamoulya_Glad_1", 1);
            Gladiator KaGla2 = new Gladiator("Kamoulya_Glad_2", 2);
            Gladiator KaGla3 = new Gladiator("Kamoulya_Glad_3", 3);
            Gladiator YeGla1 = new Gladiator("Yela_Glad_1", 1);
            Gladiator YeGla2 = new Gladiator("Yela_Glad_2", 2);
            Gladiator YeGla3 = new Gladiator("Yela_Glad_3", 3);
            Gladiator KwGla1 = new Gladiator("Kwintyn_Glad_1", 1);
            Gladiator KwGla2 = new Gladiator("Kwintyn_Glad_2", 2);
            Gladiator KwGla3 = new Gladiator("Kwintyn_Glad_3", 3);

            //Equipement gladiateurs Zywo
            ZyGla1.AddItem("Dagger");
            ZyGla1.AddItem("Sword");
            ZyGla1.AddItem("Net");
            ZyGla2.AddItem("Big shield");
            ZyGla2.AddItem("Dagger");
            ZyGla3.AddItem("Dagger");
            ZyGla3.AddItem("Helmet");
            //Equipement gladiateurs Kamoulya
            KaGla1.AddItem("Helmet");
            KaGla1.AddItem("Lance");
            KaGla2.AddItem("Helmet");
            KaGla2.AddItem("Lance");
            KaGla3.AddItem("Trident");
            KaGla3.AddItem("Dagger");
            //Equipement gladiateurs Yela
            YeGla1.AddItem("Sword");
            YeGla1.AddItem("Net");
            YeGla2.AddItem("Sword");
            YeGla2.AddItem("Dagger");
            YeGla2.AddItem("Helmet");
            YeGla3.AddItem("Lance");
            YeGla3.AddItem("Helmet");
            //Equipement gladiateurs Kwintyn
            KwGla1.AddItem("Helmet");
            KwGla1.AddItem("Lance");
            KwGla2.AddItem("Helmet");
            KwGla2.AddItem("Lance");
            KwGla3.AddItem("Trident");
            KwGla3.AddItem("Dagger");

            //Ajout des gladiateurs aux équipes
            ZyT1.AddGlad(ZyGla1);
            ZyT1.AddGlad(ZyGla2);
            ZyT1.AddGlad(ZyGla3);
            KaT1.AddGlad(KaGla1);
            KaT1.AddGlad(KaGla2);
            KaT1.AddGlad(KaGla3);
            YeT1.AddGlad(YeGla1);
            YeT1.AddGlad(YeGla2);
            YeT1.AddGlad(YeGla3);
            KwT1.AddGlad(KwGla1);
            KwT1.AddGlad(KwGla2);
            KwT1.AddGlad(KwGla3);

            //Ajout des équipes aux joueurs
            Max.Teams.Add(ZyT1);
            Cam.Teams.Add(KaT1);
            Ben.Teams.Add(YeT1);
            Kwi.Teams.Add(KwT1);

            //Formation du tournois
            List<Team> Teams = new List<Team>();
            Teams.Add(Max.Teams[0]);
            Teams.Add(Cam.Teams[0]);
            Teams.Add(Kwi.Teams[0]);
            Teams.Add(Ben.Teams[0]);
            Tournament match = new Tournament(Teams);

            match.StartTournament();

            Console.Read();
        }
    }
}