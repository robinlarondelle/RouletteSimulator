using Domain.Bets;
using Domain.Layouts;
using Domain.Numbers;
using UseCases.Layouts.Interfaces;

namespace UseCases.Layouts;

public class CreateLayoutUseCase : ICreateLayoutUseCase
{
    public Layout CreateEuropeanLayout()
    {
        return new Layout
        {
            Fields = NumberConstants.EuropeanNumbers.Select(CreateField).ToList()
        };
    }

    public Layout CreateAmericanLayout()
    {
        return new Layout
        {
            Fields = NumberConstants.AmericanNumbers.Select(CreateField).ToList()
        };
    }

    private static Field CreateField(Number number)
    {
        return new Field
        {
            Number = number,
            Bets = new List<Bet>()
        };
    }
}