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
            Console.WriteLine($"{adventurer.GetName()} the {adventurer.GetSubclass()} - Status: {adventurer.CheckStatus()}");
        }
    }
}
