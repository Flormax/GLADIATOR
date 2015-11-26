using System;

namespace GladiatorArena
{
    //Class abstraite pour définir les différents affrontements
    public abstract class Match
    {
        protected Entity _Part1;
        protected Entity _Part2;

        public Entity Part1
        {
            get
            { return _Part1; }
            set
            { _Part1 = value; }
        }

        public Entity Part2
        {
            get
            { return _Part2; }
            set
            { _Part2 = value; }
        }

        public Match(Entity p1, Entity p2)
        {
            this._Part1 = p1;
            this._Part2 = p2;
        }

        public Match()
        { }

        public virtual Entity Winner(Entity entity)
        {
            if (entity == this._Part1)
            {
                this._Part1.Victories++;
                this._Part2.Defeats++;
                Console.WriteLine("WINNER " + this._Part1.Name + " (win rate: " + this._Part1.WinRate + "%)");
                return this._Part1;
            }
            else
            {
                this._Part2.Victories++;
                this._Part1.Defeats++;
                Console.WriteLine("WINNER " + this._Part2.Name + " (win rate: " + this._Part2.WinRate + "%)");
                return this._Part2;
            }
        }

        public abstract Entity PlayMatch();
    }
}

