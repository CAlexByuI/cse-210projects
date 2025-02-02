using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the shopping cart program\n");

        Cart cart = new Cart();

        cart.Add();
        cart.Add();

        cart.Display();
    }
}

class Item
{
    public string _name;
    public double _amount;
    public bool _checked = false;

    public void Display()
    {
        Console.WriteLine($"{_name}, {_amount}, {_checked}");
    }
}


class Cart 
{
    public string _name = "TBD";
    public List<Item> _items = new List<Item>();

    public void Display()
    {
        Console.WriteLine($"Welcome to {_name}!");

        foreach (var item in _items)
        {
            item.Display();
        }
    }

    public void Add()
    {
        Item newItem = new Item();

        Console.Write("Enter item Name: ");
        string name = Console.ReadLine();
        newItem._name = name;

        Console.Write("Enter Item Amount: ");
        string amount = Console.ReadLine();
        newItem._amount = double.Parse(amount);

        _items.Add(newItem);
    }

    public double CalcTotal()
    {
        double total = 0;

        foreach (var item in _items)
        {
            total += item._amount;
        }
    }
}