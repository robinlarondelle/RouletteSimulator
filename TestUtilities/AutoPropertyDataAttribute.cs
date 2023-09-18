using System.Reflection;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using Xunit.Sdk;

namespace TestUtilities;

public class AutoPropertyDataAttribute : DataAttribute
{
    private readonly string _propertyName;
    private readonly Func<IFixture> _createFixture;

    public AutoPropertyDataAttribute(string propertyName)
        : this(propertyName, () =>
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        })
    { }

    protected AutoPropertyDataAttribute(string propertyName, Func<IFixture> createFixture)
    {
        _propertyName = propertyName;
        _createFixture = createFixture;
    }

    public Type PropertyHost { get; set; }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        foreach (var values in GetAllParameterObjects(testMethod))
        {
            yield return GetObjects(values, testMethod.GetParameters(), _createFixture());
        }
    }

    private IEnumerable<object[]> GetAllParameterObjects(MethodInfo methodUnderTest)
    {
        var type = PropertyHost ?? methodUnderTest.DeclaringType;
        var property = type.GetProperty(_propertyName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);

        if (property == null)
        {
            throw new ArgumentException(string.Format("Could not find public static property {0} on {1}", _propertyName, type.FullName));
        }

        var obj = property.GetValue(null, null);
        if (obj == null)
        {
            return null;
        }

        var enumerable = obj as IEnumerable<object[]>;
        if (enumerable != null)
        {
            return enumerable;
        }

        var singleEnumerable = obj as IEnumerable<object>;
        return singleEnumerable != null
            ? singleEnumerable.Select(x => new[] { x })
            : throw new ArgumentException(string.Format("Property {0} on {1} did not return IEnumerable<object[]>", _propertyName, type.FullName));
    }

    private static object[] GetObjects(object[] parameterized, ParameterInfo[] parameters, IFixture fixture)
    {
        var result = new object[parameters.Length];

        for (var i = 0; i < parameters.Length; i++)
        {
            result[i] = i < parameterized.Length ? parameterized[i] : CustomizeAndCreate(fixture, parameters[i]);
        }

        return result;
    }

    private static object CustomizeAndCreate(IFixture fixture, ParameterInfo p)
    {
        var customizations = p.GetCustomAttributes(typeof(CustomizeAttribute), false)
            .OfType<CustomizeAttribute>()
            .Select(attr => attr.GetCustomization(p));

        foreach (var c in customizations)
        {
            fixture.Customize(c);
        }

        var context = new SpecimenContext(fixture);
        return context.Resolve(p);
    }
}
