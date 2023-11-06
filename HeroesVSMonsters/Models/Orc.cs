using System;
using HeroesVSMonsters.Interfaces;

namespace HeroesVSMonsters.Models
{
    public class Orc : Monsters, IGold
    {
        private const int BONUS_STRENGTH = 1;

        #region Props
        public int Gold { get; init; }

        public override int Strength
        {
            get { return base.Strength + BONUS_STRENGTH; }
        }
        #endregion

        #region Constructor
        public Orc() : base("Orque")
        {
            Gold = D6.Roll();
        }
        #endregion
    }
}

