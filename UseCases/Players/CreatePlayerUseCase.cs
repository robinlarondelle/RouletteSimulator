using Domain.Players;
using UseCases.Players.Interfaces;

namespace UseCases.Players;

public class CreatePlayerUseCase : ICreatePlayerUseCase
{
    private readonly string _name;
    private readonly decimal _balance;

    public CreatePlayerUseCase(string name, decimal balance)
    {
        _name = name;
        _balance = balance;
    }

    public Player Execute()
    {
        return new Player
        {
            Name = _name,
            Balance = _balance
        };
    }
}