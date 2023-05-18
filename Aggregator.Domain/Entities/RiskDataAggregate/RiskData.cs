namespace Aggregator.Domain.Entities.RiskDataAggregate;

public class RiskData : IRiskData
{
    public RiskData(string firstName, string lastName, decimal value, string make, DateTime dob)
    {
        FirstName = firstName;
        LastName = lastName;
        Value = value;
        Make = make;
        DOB = dob;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public decimal Value { get; }
    public string Make { get; }
    public DateTime DOB { get; }
}