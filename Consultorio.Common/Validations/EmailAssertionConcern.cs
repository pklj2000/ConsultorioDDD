using System.Text.RegularExpressions;

namespace Consultorio.Common.Validations
{
    public class EmailAssertionConcern
    {
        public static void AssertIsValid(string email, string message)
        {
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", RegexOptions.IgnoreCase))
            {
                throw new System.Exception(message);
            }
        }
    }
}
