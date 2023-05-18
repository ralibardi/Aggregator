namespace Aggregator.Domain.Tests.Services;

public class QuotationSystem1Tests
{
    [Test]
    public void QuotationSystem1_ReturnsException_WhenURLisNull()
    {
        // Act and Assert
        Assert.Throws<Exception>(() => new QuotationSystem1(null, "10"));
    }

    [Test]
    public void QuotationSystem1_ReturnsException_WhenPortIsNull()
    {
        // Act and Assert
        Assert.Throws<Exception>(() => new QuotationSystem1("test", null));
    }

    [Test]
    public void QuotationSystem1_ReturnsSystem()
    {
        // Act
        var systemObj = new QuotationSystem1("test", "10");

        // Assert
        Assert.That(systemObj, Is.Not.Null);
    }
}