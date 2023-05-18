namespace Aggregator.Domain.Tests.Factories;

public class QuotationSystemFactoryTests
{
    [Test]
    public void QuotationSystemFactory_ReturnsNull_WhenTypeIsNotDefined()
    {
        // Act
        var systemObj = new QuotationSystemFactory().GetQuotationSystem(0);

        // Assert
        Assert.That(systemObj, Is.Null);
    }

    [Test]
    [TestCase(QuotationSystemType.Type1, "Test Name")]
    [TestCase(QuotationSystemType.Type2, "qewtrywrh")]
    [TestCase(QuotationSystemType.Type3, "zxcvbnm")]
    public void QuotationSystemFactory_ReturnsSystem(QuotationSystemType type, string insurerName)
    {
        //Arrange
        var request = new ExpandoObject();
        // Act
        var systemObj = new QuotationSystemFactory().GetQuotationSystem(type);

        // Assert
        Assert.That(systemObj, Is.Not.Null);
        Assert.AreEqual(insurerName, systemObj.GetPrice(request).Name);
    }
}