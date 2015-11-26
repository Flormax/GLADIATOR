using System;

namespace GladiatorArena
{
    //Class générique pour les entités utilisées dans le programme
    public abstract class Entity
    {
        protected string _Name;
        protected int _Matchs;
        protected int _Victories;
        protected int _Defeats;
        protected decimal _WinRate;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Matchs
        {
            get { return (_Victories + _Defeats); }
            set { _Matchs = value; }
        }

        public int Victories
        {
            get { return _Victories; }
            set { _Victories = value; }
        }

        public int Defeats
        {
            get { return _Defeats; }
            set { _Defeats = value; }
        }

        //On calcule directement le winrate dans l'accesseur
        public decimal WinRate
        {
            get { return (_Victories > 0 ? Math.Round((((decimal)_Victories / Matchs) * 100), 0) : 0); }
        }

        public Entity()
        { }

        protected void ErrorMessage(string Message)
        {
            Console.WriteLine(this.Name + Message);
            Console.WriteLine("For the moment, you can modify " + this.Name + " in Test.cs !\nPress any key to quit.");
            Console.Read();
            Environment.Exit(0);
        }
    }
}

//GJONIK@GMAIL.COM