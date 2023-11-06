using HeroesVSMonsters.Models;

void StartGame()
{
    Dice d2 = new Dice(2);

    Heroes hero = new Dwarf("Alixe");
    hero.OnAttackEvent += AfficherDetailCombat;
    hero.OnDeadEvent += (hero) =>
    {
        Console.WriteLine($"Le héro {hero.Name} a été vaincu !");
    };
    hero.OnDeadEvent += (hero) =>
    {
        Console.WriteLine($"Game over !!!");
    };

    Console.WriteLine($"L'aventure commence pour notre héro {hero.Name}");
    Console.WriteLine($"\nStatique du héro :");
    Console.WriteLine($"Force : {hero.Strength}");
    Console.WriteLine($"End   : {hero.Stamina}");
    Console.WriteLine($"Pdv   : {hero.HealthMax}");
    Console.WriteLine();

    while (hero.IsAlive)
    {
        Monsters ennemi = GenerateMonster();
        ennemi.OnAttackEvent += AfficherDetailCombat;
        ennemi.OnDeadEvent += (ennemi) => Console.WriteLine("Le monstre est mort !");

        Console.WriteLine($"Combat contre un « {ennemi.Name} » !");
        bool heroInitiative = (d2.Roll() == 1);
        while (hero.IsAlive && ennemi.IsAlive)
        {
            if (heroInitiative)
            {
                hero.Attack(ennemi);
            }
            else
            {
                ennemi.Attack(hero);
            }

            heroInitiative = !heroInitiative;
        }

        if (hero.IsAlive)
        {
            hero.Loot(ennemi);
            hero.RestoreHealth();
        }

        Console.WriteLine();
    }


    Console.WriteLine("\nRésultat de l'expedition :");
    Console.WriteLine($" - Or   : {hero.Gold}");
    Console.WriteLine($" - Cuir : {hero.Leather}");
}

void AfficherDetailCombat(Character attacker, Character defender, int dommage)
{
    Console.WriteLine($" - {attacker.Name} attaque {defender.Name} de {dommage} dégâts !");
}

Monsters GenerateMonster()
{
    Dice d3 = new Dice(3);

    Monsters monster;

    switch (d3.Roll())
    {
        case 1:
            monster = new Wolf();
            break;
        case 2:
            monster = new Orc();
            break;
        default:
            monster = new Dragonet();
            break;
    }

    return monster;
}


StartGame();

Console.ReadLine();