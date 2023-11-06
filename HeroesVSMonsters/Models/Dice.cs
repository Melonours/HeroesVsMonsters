using System;

namespace HeroesVSMonsters.Models
{
	public sealed class Dice
	{

        #region Field
        private int _Minimum;
        private int _Maximum;
        private Random _Rng;
        #endregion

        #region Props
        public int Mininimum { get { return _Minimum; } }
        public int Maximum { get { return _Maximum; } }
        #endregion

        #region Constructor
        public Dice(int maximum, int minimum = 1)
        {
            _Minimum = minimum;
            _Maximum = maximum;
            _Rng = new Random();

        }
        #endregion

        #region Methods
        public int Roll()
        {
            return _Rng.Next(Mininimum, Maximum + 1);
        }
        #endregion

    }
}

