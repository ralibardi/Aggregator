namespace Aggregator.Domain.Tests.Services;

public class QuotationSystem2Tests
{
    [Test]
    public void QuotationSystem2_ReturnsException_WhenURLisNull()
    {
        // Act and Assert
        Assert.Throws<Exception>(() => new QuotationSystem2(null, "10"));
    }

    [Test]
    public void QuotationSystem2_ReturnsException_WhenPortIsNull()
    {
        // Act and Assert
        Assert.Throws<Exception>(() => new QuotationSystem2("test", null));
    }

    [Test]
    public void QuotationSystem2_ReturnsSystem()
    {
        // Act
        var systemObj = new QuotationSystem2("test", "10");

        // Assert
        Assert.That(systemObj, Is.Not.Null);
    }
}