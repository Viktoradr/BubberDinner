using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class GeneralErrors
    {
        public static Error Unexpected => Error.Conflict(
            code: "General.Unexpected",
            description: "Object not found.");
    }
}

