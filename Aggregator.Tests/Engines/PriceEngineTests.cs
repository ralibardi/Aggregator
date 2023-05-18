namespace Aggregator.Presentation.Tests.Engines;

public class Tests
{
    [Test]
    public void PriceEngine_ReturnsError_WhenRequestRiskDataIsNull()
    {
        // Arrange
        var request = new PriceRequest(null);
        const string expectedResponse = "Risk Data is missing";

        // Act
        var engine = new PriceEngine(new QuotationSystemFactory());

        // Assert
        Assert.That(engine.GetPrice(request).Error, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void PriceEngine_ReturnsError_WhenRequesterFirstNameIsNull()
    {
        // Arrange
        var riskData = new RiskData(null, "test", 0, "test", DateTime.UtcNow);
        var request = new PriceRequest(riskData);
        const string expectedResponse = "First name is required";

        // Act
        var engine = new PriceEngine(new QuotationSystemFactory());

        // Assert
        Assert.That(engine.GetPrice(request).Error, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void PriceEngine_ReturnsError_WhenRequesterSurnameIsNull()
    {
        // Arrange
        var riskData = new RiskData("test", null, 0, "test", DateTime.UtcNow);
        var request = new PriceRequest(riskData);
        const string expectedResponse = "Surname is required";

        // Act
        var engine = new PriceEngine(new QuotationSystemFactory());

        // Assert
        Assert.That(engine.GetPrice(request).Error, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void PriceEngine_ReturnsError_WhenRequestValueIsNull()
    {
        // Arrange
        var riskData = new RiskData("test", "test", 0, "test", DateTime.UtcNow);
        var request = new PriceRequest(riskData);
        const string expectedResponse = "Value is required";

        // Act
        var engine = new PriceEngine(new QuotationSystemFactory());

        // Assert
        Assert.That(engine.GetPrice(request).Error, Is.EqualTo(expectedResponse));
    }

    [Test]
    public void PriceEngine_ReturnsPriceResponse()
    {
        // Arrange
        var riskData = new RiskData("test", "test", 10, "test", DateTime.UtcNow);
        var request = new PriceRequest(riskData);

        // Act
        var engine = new PriceEngine(new QuotationSystemFactory());
        var response = engine.GetPrice(request);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response, Is.InstanceOf<PriceResponse>());
        Assert.That(response.Error, Is.Null);
    }
}