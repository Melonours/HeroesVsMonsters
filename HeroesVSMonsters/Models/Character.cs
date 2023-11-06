using System;
using HeroesVSMonsters.Helpers;

namespace HeroesVSMonsters.Models
{
    public delegate void AttackEvent(Character attacker, Character target, int dommage);

    public abstract class Character
	{

        #region Events
        // public event Action<Character, Character, int>? OnAttackEvent = null;
        public event AttackEvent? OnAttackEvent = null;

        public event Action<Character>? OnDeadEvent = null;
        #endregion

        #region Field
        private int _Stamina;
        private int _Strength;
        private int _Health;
        #endregion

        #region Props
        public string Name { get; init; }
        public virtual int Stamina
        {
            get { return _Stamina;  }
        }
        public virtual int Strength
        {
            get { return _Strength; }
        }
        public virtual int Health
        {
            get { return _Health; }
        }
        public int HealthMax
        {
            get { return CalculateHealthMax(); }
        }
        public bool IsAlive
        {
            get { return Health > 0; }
        }

        protected Dice D4 { get; init; }
        protected Dice D6 { get; init; }

        #endregion
        
        #region Ctor
        public Character(string name)
        {
            Name = name;

            D4 = new Dice(4);
            D6 = new Dice(6);

            _Strength = GameHelper.GenerateStats();
            _Stamina = GameHelper.GenerateStats();
            _Health = CalculateHealthMax();
        }
        #endregion

        #region Methods
        private int CalculateHealthMax()
        {
            return Stamina + GameHelper.GetModifier(Stamina);
        }

        public void Attack(Character target)
        {
            int dmg = D4.Roll() + GameHelper.GetModifier(Strength);

            // Déclancher l'event
            OnAttackEvent?.Invoke(this, target, dmg);

            target.TakeDammage(dmg);
        }

        protected void TakeDammage(int dmg)
        {
            if (dmg <= 0) { return; }

            _Health -= dmg;

            if (!IsAlive)
            {
                OnDeadEvent?.Invoke(this);
            }
        }

        protected void Healing(int value)
        {
            if (value <= 0) { return; }

            _Health = Math.Min(Health + value, HealthMax);
        }
        #endregion
    }
}

