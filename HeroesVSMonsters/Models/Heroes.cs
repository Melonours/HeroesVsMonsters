using System;
using HeroesVSMonsters.Interfaces;
using System.Threading;

namespace HeroesVSMonsters.Models
{
	public class Heroes : Character, IGold, ILeather
	{
        #region Props
        public int Gold { get; private set; }
        public int Leather { get; private set; }
        #endregion

        #region Ctor
        public Heroes(string name) : base(name)
        {
            Gold = 0;
            Leather = 0;
        }
        #endregion

        #region Methods
        public void RestoreHealth()
        {
            Healing(HealthMax - Health);
        }

        public void Loot(Monsters monster)
        {
            if (monster is IGold)
            {
                // Cast Manuel
                Gold += ((IGold)monster).Gold;
            }

            if (monster is ILeather element)
            {
                // Cast automatique (Nouvelle syntaxe)
                Leather += element.Leather;
            }
        }
        #endregion
    }
}