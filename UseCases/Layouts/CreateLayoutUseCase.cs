using Domain.Bets;
using Domain.Layouts;
using Domain.Numbers;
using UseCases.Layouts.Interfaces;

namespace UseCases.Layouts;

public class CreateLayoutUseCase : ICreateLayoutUseCase
{
    public Layout CreateEuropeanLayout()
    {
        var fields = NumberConstants.EuropeanNumbers.Select(n => new Field(n)).ToList();

        var layout = new Layout
        {
            Fields = fields,
            Bets = new List<Bet>()
        };
        
        return layout;
    }

    public Layout CreateAmericanLayout()
    {
        var fields = NumberConstants.AmericanNumbers.Select(n => new Field(n)).ToList();

        var layout = new Layout
        {
            Fields = fields,
            Bets = new List<Bet>()
        };
        return layout;
    }
}