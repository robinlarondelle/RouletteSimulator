namespace Domain.Players;

public class Player
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
    
    public Player(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }
}