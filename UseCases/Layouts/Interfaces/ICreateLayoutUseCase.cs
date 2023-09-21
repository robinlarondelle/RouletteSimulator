using Domain.Layouts;

namespace UseCases.Layouts.Interfaces;

public interface ICreateLayoutUseCase
{
    Layout CreateEuropeanLayout();
    Layout CreateAmericanLayout();
}