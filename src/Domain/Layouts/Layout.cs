namespace Domain.Layouts;

public record Layout
{   
    public required IList<Field> Fields { get; set; } 
}