namespace Domain.Players;

public record Player
{
    public required string Name { get; init; }
    public required int Balance { get; set; }
}