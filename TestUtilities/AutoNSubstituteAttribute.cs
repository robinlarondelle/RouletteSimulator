using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace TestUtilities;

public class AutoNSubstituteDataAttribute : AutoDataAttribute
{
    public AutoNSubstituteDataAttribute()
        : base(() => new CustomAutoFixture().Customize(new AutoNSubstituteCustomization()))
    {
    }
}
