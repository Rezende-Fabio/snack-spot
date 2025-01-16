
namespace snack_spot.Utils;

public static class StringUtils
{
    public static string Capitalize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1);
    }
}