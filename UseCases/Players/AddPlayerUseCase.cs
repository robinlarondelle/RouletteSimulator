using Domain.Games;
using Domain.Players;

namespace UseCases.Players;

public class AddPlayerUseCase
{
    private readonly Game _game;
    private readonly Player _player;

    public AddPlayerUseCase(Game game, Player player)
    {
        _game = game;
        _player = player;
    }
    
    public void Execute()
    {
        _game.Players.Add(_player);
    }
}