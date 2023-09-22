using Domain.Players;

namespace UseCases.Players.Interfaces;

public interface ICreatePlayerUseCase
{
    Player Execute();
}