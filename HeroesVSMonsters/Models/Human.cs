using System;
namespace HeroesVSMonsters.Models
{
	public class Human : Heroes
	{
        private const int BONUS_STAMINA = 1;
        private const int BONUS_STRENGTH = 1;

        #region Props
        public override int Stamina
        {
            get { return base.Stamina + BONUS_STAMINA; }
        }
        public override int Strength
        {
            get { return base.Strength + BONUS_STRENGTH; }
        }
        #endregion

        #region Constructor
        public Human(string name) : base(name) { }
        #endregion
    }

}

