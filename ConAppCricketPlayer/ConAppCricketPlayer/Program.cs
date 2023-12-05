using System;
using System.Collections.Generic;
using System.Linq;

class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Team
{
    private List<Player> players = new List<Player>();

    public void AddPlayer(int id, string name, int age)
    {
        if (players.Count < 11)
        {
            Player player = new Player { Id = id, Name = name, Age = age };
            players.Add(player);
            Console.WriteLine("Player added successfully!");
        }
        else
        {
            Console.WriteLine("Cannot add more than 11 players to the team!");
        }
    }

    public void RemovePlayer(int id)
    {
        Player playerToRemove = players.FirstOrDefault(p => p.Id == id);
        if (playerToRemove != null)
        {
            players.Remove(playerToRemove);
            Console.WriteLine("Player removed successfully!");
        }
        else
        {
            Console.WriteLine("Player not found!");
        }
    }

    public void GetPlayerDetailsById(int id)
    {
        Player player = players.FirstOrDefault(p => p.Id == id);
        if (player != null)
        {
            Console.WriteLine($"Player Id: {player.Id}, Name: {player.Name}, Age: {player.Age}");
        }
        else
        {
            Console.WriteLine("Player not found!");
        }
    }

    public void GetPlayerDetailsByName(string name)
    {
        Player player = players.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (player != null)
        {
            Console.WriteLine($"Player Id: {player.Id}, Name: {player.Name}, Age: {player.Age}");
        }
        else
        {
            Console.WriteLine("Player not found!");
        }
    }

    public void GetAllPlayerDetails()
    {
        foreach (var player in players)
        {
            Console.WriteLine($"Player Id: {player.Id}, Name: {player.Name}, Age: {player.Age}");
        }
    }
}

class Program
{
    static void Main()
    {
        Team cricketTeam = new Team();
        Console.WriteLine("********* Welcome To Cricket Team **********");
        while (true)
        {
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Remove Player");
            Console.WriteLine("3. Get Player Details by Id");
            Console.WriteLine("4. Get Player Details by Name");
            Console.WriteLine("5. Get All Player Details");
            Console.WriteLine("6. Exit");
            Console.WriteLine("\n");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Player Id: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Player Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Player Age: ");
                    int age = int.Parse(Console.ReadLine());
                    cricketTeam.AddPlayer(id, name, age);
                    break;

                case 2:
                    Console.Write("Enter Player Id to remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    cricketTeam.RemovePlayer(removeId);
                    break;

                case 3:
                    Console.Write("Enter Player Id to get details: ");
                    int getId = int.Parse(Console.ReadLine());
                    cricketTeam.GetPlayerDetailsById(getId);
                    break;

                case 4:
                    Console.Write("Enter Player Name to get details: ");
                    string getName = Console.ReadLine();
                    cricketTeam.GetPlayerDetailsByName(getName);
                    break;

                case 5:
                    cricketTeam.GetAllPlayerDetails();
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        Console.ReadKey();
    }
}
