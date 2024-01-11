using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public float Latitude { get; private set; }
    public float Longitude { get; private set; }

    private Location(
        string name, 
        string address,
        float latitude,
        float longtude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longtude;
    }

    public static Location CreateNew(
        string name, 
        string address, 
        float latitude = 0, 
        float longtude = 0)
    {
        return new Location(name, address, latitude, longtude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}
