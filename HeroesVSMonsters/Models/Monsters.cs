using System;
namespace HeroesVSMonsters.Models
{
    public abstract class Monsters : Character
    {
        protected Monsters(string name) : base(name) { }
    }
}

