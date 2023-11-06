using System;
using HeroesVSMonsters.Interfaces;
namespace HeroesVSMonsters.Models
{
	public class Dragonet : Monsters, IGold, ILeather
	{
        private const int BONUS_STAMINA = 1;

        #region Props
        public int Gold { get; init; }
        public int Leather { get; init; }
        public override int Stamina
        {
            get { return base.Stamina + BONUS_STAMINA; }
        }
        #endregion

        #region Constructor
        public Dragonet() : base("Dragonnet")
        {
            Gold = D6.Roll();
            Leather = D4.Roll();
        }
        #endregion
    }
}

