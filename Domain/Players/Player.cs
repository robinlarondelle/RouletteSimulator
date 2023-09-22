namespace Domain.Players;

public record Player
{
    public required string Name { get; init; }
    public required decimal Balance { get; set; }
}