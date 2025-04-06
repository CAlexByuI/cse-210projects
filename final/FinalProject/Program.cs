class Program
{
    static void Main(string[] args)
    {
        // Create a predefined party of adventurers
        List<Adventurer> party = new List<Adventurer>
        {
            new Wizard("Ezra"),
            new Knight("Bran"),
            new Archer("Lia"),
            new Thief("Shade"),
            new Merchant("Marlo")
        };

        // Prompt user to create their own adventurer
        Console.WriteLine("Create your own adventurer!");
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Choose class (Wizard, Knight, Archer, Thief, Merchant): ");
        string subclass = Console.ReadLine();

        // Create the player's character based on chosen class
        Adventurer playerCharacter = subclass.ToLower() switch
        {
            "wizard" => new Wizard(name),
            "knight" => new Knight(name),
            "archer" => new Archer(name),
            "thief" => new Thief(name),
            "merchant" => new Merchant(name),
            _ => throw new ArgumentException("Invalid class selection.")
        };

        // Add player character to the party
        party.Add(playerCharacter);

        // Display party members and their stats
        Console.WriteLine("\nYour party:");
        foreach (var adventurer in party)
        {
            Console.WriteLine($"{adventurer.GetName()} the {adventurer.GetSubclass()} - Armor: {adventurer.GetArmor()} - Status: {adventurer.CheckStatus()}");
        }

        // Begin the dungeon sequence
        Console.WriteLine("\nEntering the dungeon...");
        RunDungeon(party);
    }

    static void RunDungeon(List<Adventurer> party)
    {
        Random rng = new Random();
        string[] encounters = { "Enemy", "Treasure", "Trap", "Healing", "Puzzle", "Merchant" };

        // The dungeon consists of 3 rooms
        for (int room = 1; room <= 3; room++)
        {
            Console.WriteLine($"\n-- Room {room} --");
            string encounter = encounters[rng.Next(encounters.Length)];
            Console.WriteLine($"You encounter: {encounter}");

            if (encounter == "Enemy")
            {
                // Each conscious adventurer takes an action
                foreach (var adventurer in party)
                {
                    if (!adventurer.IsConscious()) continue;

                    Console.WriteLine($"{adventurer.GetName()} ({adventurer.GetSubclass()}) - Action? (attack / heal): ");
                    string action = Console.ReadLine();

                    if (action == "attack")
                    {
                        // Check stamina before allowing attack
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
                        // Check stamina before allowing heal
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

                // Enemy counterattacks all conscious adventurers
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
                // Heal all adventurers
                foreach (var adventurer in party)
                {
                    adventurer.Heal(15);
                }
                Console.WriteLine("A magical aura restores 15 HP to all adventurers.");
            }
            else if (encounter == "Treasure")
            {
                // Flavor encounter - no mechanical effect yet
                Console.WriteLine("You found a chest of gold! It doesn’t do anything… yet.");
            }
            else if (encounter == "Trap")
            {
                // All adventurers take random damage
                Console.WriteLine("A trap springs! Everyone takes damage.");
                foreach (var adventurer in party)
                {
                    adventurer.TakeDamage(rng.Next(5, 10));
                }
            }
            else if (encounter == "Puzzle")
            {
                // Flavor encounter - no real challenge yet
                Console.WriteLine("A mysterious puzzle blocks the way. You solve it easily. Somehow.");
            }
            else if (encounter == "Merchant")
            {
                // Flavor encounter - could be used for future features
                Console.WriteLine("A traveling merchant offers you mysterious wares… but you’re broke.");
            }
        }

        // End of dungeon run
        Console.WriteLine("\nDungeon crawl complete!");
    }
}
