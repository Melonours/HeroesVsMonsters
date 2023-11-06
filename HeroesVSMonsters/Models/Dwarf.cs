using System;
namespace HeroesVSMonsters.Models
{
	public class Dwarf : Heroes
	{
        private const int BONUS_STAMINA = 2;

        #region Props
        public override int Stamina
        {
            get { return base.Stamina + BONUS_STAMINA; }
        }
        #endregion

        #region Constructor
        public Dwarf(string name) : base(name) { }
        #endregion

    }
}

