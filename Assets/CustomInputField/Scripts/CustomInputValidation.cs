using System.Text.RegularExpressions;

namespace CustomInputField
{
    public enum CharacterInputValidation
    {
        None,
        Alphanumeric,
        Alphabetic,
        Numeric,
    }
    public static class CustomInputValidation
    {
        public static string GetCharacterInputValidation(string stringInput, CharacterInputValidation characterInputValidation)
        {

            if (characterInputValidation == CharacterInputValidation.Alphanumeric)
            {
                string alphanumeric = Regex.Replace(stringInput, "[^a-zA-Z0-9 ]", "");
                return alphanumeric;
            }
            else if (characterInputValidation == CharacterInputValidation.Numeric)
            {
                string number = Regex.Replace(stringInput, "[^0-9 ]", "");
                return number;
            }
            else if (characterInputValidation == CharacterInputValidation.Alphabetic)
            {

                string name = Regex.Replace(stringInput, "[^a-zA-Z ]", "");

                return name;
            }
            else
            {
                return stringInput;
            }
        }
    }
}
