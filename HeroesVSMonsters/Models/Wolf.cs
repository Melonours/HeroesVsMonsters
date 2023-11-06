using System;
using HeroesVSMonsters.Interfaces;
namespace HeroesVSMonsters.Models
{
	public class Wolf : Monsters, ILeather
	{
        #region Props
        public int Leather { get; init; }
        #endregion

        #region Constructor
        public Wolf() : base("Loup")
        {
            Leather = D4.Roll();
        }
        #endregion
    }
}

