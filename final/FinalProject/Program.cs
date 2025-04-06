class Program
{
    static void Main(string[] args)
    {
        List<Adventurer> party = new List<Adventurer>
        {
            new Wizard("Ezra"),
            new Knight("Bran"),
            new Archer("Lia"),
            new Thief("Shade"),
            new Merchant("Marlo")
        };

        Console.WriteLine("Create your own adventurer!");
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Choose class (Wizard, Knight, Archer, Thief, Merchant): ");
        string subclass = Console.ReadLine();

        Adventurer playerCharacter = subclass.ToLower() switch
        {
            "wizard" => new Wizard(name),
            "knight" => new Knight(name),
            "archer" => new Archer(name),
            "thief" => new Thief(name),
            "merchant" => new Merchant(name),
            _ => throw new ArgumentException("Invalid class selection.")
        };

        party.Add(playerCharacter);

        Console.WriteLine("\nYour party:");
        foreach (var adventurer in party)
        {
            Console.WriteLine($"{adventurer.GetName()} the {adventurer.GetSubclass()} - Armor: {adventurer.GetArmor()} - Status: {adventurer.CheckStatus()}");
        }

        Console.WriteLine("\nEntering the dungeon...");
        RunDungeon(party);
    }

    static void RunDungeon(List<Adventurer> party)
    {
        Random rng = new Random();
        string[] encounters = { "Enemy", "Treasure", "Trap", "Healing", "Puzzle", "Merchant" };

        for (int room = 1; room <= 3; room++)
        {
            Console.WriteLine($"\n-- Room {room} --");
            string encounter = encounters[rng.Next(encounters.Length)];
            Console.WriteLine($"You encounter: {encounter}");

            if (encounter == "Enemy")
            {
                foreach (var adventurer in party)
                {
                    if (!adventurer.IsConscious()) continue;

                    Console.WriteLine($"{adventurer.GetName()} ({adventurer.GetSubclass()}) - Action? (attack / heal): ");
                    string action = Console.ReadLine();

                    if (action == "attack")
                    {
                        if (adventurer.HasEnoughStamina(10))
                        {
                            adventurer.UseStamina(10);
                            Console.WriteLine($"{adventurer.GetName()} attacks for {adventurer.CalculateDmg()} damage!");
                        }
                        else
                        {
                            Console.WriteLine($"{adventurer.GetName()} is too tired to attack.");
                        }
                    }
                    else if (action == "heal")
                    {
                        if (adventurer.HasEnoughStamina(8))
                        {
                            adventurer.UseStamina(8);
                            adventurer.Heal(10);
                            Console.WriteLine($"{adventurer.GetName()} heals for 10 HP.");
                        }
                        else
                        {
                            Console.WriteLine($"{adventurer.GetName()} is too tired to heal.");
                        }
                    }
                
                }

                // Enemy retaliates
                Console.WriteLine("Enemy attacks back!");
                foreach (var adventurer in party)
                {
                    if (adventurer.IsConscious())
                    {
                        int damage = rng.Next(5, 15);
                        adventurer.TakeDamage(damage);
                        Console.WriteLine($"{adventurer.GetName()} takes {damage} damage (Health: {adventurer.GetHealth()})");
                    }
                }
            }
            else if (encounter == "Healing")
            {
                foreach (var adventurer in party)
                {
                    adventurer.Heal(15);
                }
                Console.WriteLine("A magical aura restores 15 HP to all adventurers.");
            }
            else if (encounter == "Treasure")
            {
                Console.WriteLine("You found a chest of gold! It doesn’t do anything… yet.");
            }
            else if (encounter == "Trap")
            {
                Console.WriteLine("A trap springs! Everyone takes damage.");
                foreach (var adventurer in party)
                {
                    adventurer.TakeDamage(rng.Next(5, 10));
                }
            }
            else if (encounter == "Puzzle")
            {
                Console.WriteLine("A mysterious puzzle blocks the way. You solve it easily. Somehow.");
            }
            else if (encounter == "Merchant")
            {
                Console.WriteLine("A traveling merchant offers you mysterious wares… but you’re broke.");
            }
        }

        Console.WriteLine("\nDungeon crawl complete!");
    }
}
