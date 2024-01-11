using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class DinnerErrors
    {
        public static Error DinnerNotFound => Error.Validation(
            code: "Dinner.DinnerNotFound",
            description: "Dinner not found");
    }
}
