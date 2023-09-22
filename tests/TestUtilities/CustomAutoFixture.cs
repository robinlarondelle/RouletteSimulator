using System.Linq.Expressions;
using AutoFixture;

namespace TestUtilities;

public class CustomAutoFixture : Fixture
{
    public CustomAutoFixture()
    {
        Behaviors.Remove(new ThrowingRecursionBehavior());
        Behaviors.Add(new OmitOnRecursionBehavior(1));
    }

    public void ExcludeNestedNavigationProperties<T>() where T : class
    {
        var directProperties = typeof(T).GetProperties()
            .Select(prop => prop.PropertyType)
            .Where(type => type.Namespace?.StartsWith("Jex", StringComparison.Ordinal) == true);

        var genericProperties = typeof(T).GetProperties()
            .Where(prop => prop.PropertyType.IsGenericType)
            .SelectMany(prop => prop.PropertyType.GenericTypeArguments)
            .Where(type => type.Namespace?.StartsWith("Jex", StringComparison.Ordinal) == true);

        foreach (var type in directProperties.Union(genericProperties).Distinct()
                     .Where(type => type != typeof(T) && type.IsClass))
        {
            var constructedType = typeof(GenericNavigationPropertyCustomizer<>).MakeGenericType(type);
            var customization = (ICustomization)Activator.CreateInstance(constructedType);

            Customize(customization);
        }
    }
}

public class GenericNavigationPropertyCustomizer<T> : ICustomization
{
    public void Customize(IFixture fixture)
    {
        var allowedProperties = new[] { "Id", "Name", "Type" };

        fixture.Customize<T>(c =>
        {
            var result = c.OmitAutoProperties();

            foreach (var propInfo in typeof(T).GetProperties().Where(prop => allowedProperties.Contains(prop.Name)))
            {
                var parameter = Expression.Parameter(typeof(T));
                var property = Expression.Property(parameter, propInfo);
                var conversion = Expression.Convert(property, typeof(object));
                var lambda = Expression.Lambda<Func<T, object>>(conversion, parameter);

                result = result.OmitAutoProperties().With(lambda);
            }

            return result;
        });
    }
}
