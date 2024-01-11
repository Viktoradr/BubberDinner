using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;
using MongoDB.Bson;

namespace BuberDinner.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId, ObjectId>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime CreatedDateTime { get; }
    public DateTime? UpdateDateTime { get; set; } = null!;

    public User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            DateTime.UtcNow);
    }
}
