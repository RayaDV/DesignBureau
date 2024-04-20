using DesignBureau.Infrastructure.Constants;

namespace DesignBureau.Core.Constants
{
    public class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string PhoneNumberExists = "This Phone number already exists. Enter another one!";

        public const string EmailExists = "This Email already exists. Enter another one!";

        public const string DisciplineDoesNotExist = "This discipline does not exist. Enter another one!";

        public const string CategoryDoesNotExist = "This category does not exist. Enter another one!";

        public const string PhaseDoesNotExist = "This phase does not exist. Enter another one!";

        public const string InvalidDate = $"Invalid date! Format must be: {DataConstants.DateFormat}";

        public const string UserMessageSuccess = "UserMessageSuccess";

        public const string UserMessageError = "UserMessageError";

        public const string UserMessageInfo = "UserMessageInfo";

        public const string UserMessageWarning = "UserMessageWarning";
    }
}
