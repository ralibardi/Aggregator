namespace Aggregator.Domain.Entities.RiskDataAggregate;

public interface IRiskData
{
    string FirstName { get; }
    string LastName { get; }
    decimal Value { get; }
    string Make { get; }
    DateTime DOB { get; }
}