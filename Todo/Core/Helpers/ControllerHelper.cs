using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Todo.Core
{

    public static class ControllerHelpers
    {
        public static List<string> GetFullErrorMessage(this ModelStateDictionary modelState)
        {
            List<string> messages = new();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }
            return messages;
        }
    }
}