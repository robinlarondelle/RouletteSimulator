using Domain.Players;
using UseCases.Players.Interfaces;

namespace UseCases.Players;

public class CreatePlayerUseCase : ICreatePlayerUseCase
{
    private readonly string _name;
    private readonly int _balance;

    public CreatePlayerUseCase(string name, int balance)
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