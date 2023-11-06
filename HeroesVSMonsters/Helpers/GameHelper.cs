using System;
using HeroesVSMonsters.Models;

namespace HeroesVSMonsters.Helpers
{
	public static class GameHelper
	{
		public static int GenerateStats()
		{
			Dice d6 = new Dice(6);
			List<int> results = new List<int>();

			// lancer des 4 dés appelés i 
			for (int i = 0; i < 4; i++)
			{
				int res = d6.Roll();

				//rajout des resultats dans la liste int results
				results.Add(res);
			}

			// trouver le pire résultat en comparant les tableaux et en réaffectant la valeur de i via la condition
			int indexWorstResult = 0;
			for (int i = 1; i < results.Count(); i++)
			{
				if (results[i] < results[indexWorstResult])
				{
					indexWorstResult = i;
				}
			}

			// enlever le pire résultat
			results.RemoveAt(indexWorstResult);


			//faire la somme des dés restants
			int stats = 0;
			foreach (int res in results)
			{
				stats += res;
			}

			return stats;
		}

		public static int GetModifier(int stat)
		{
			// Méthode alternative, sans "if"
			int modifierMax = 2;
			int modifier = (stat / 5) - 1;

			return Math.Min(modifier, modifierMax);
		}


	}
}

