using System;
using System.IO;
using System.Linq;

internal class Fixer
{
    public static string[] ReadAndFix(string fileName)
    {
        var text = File.ReadAllText(fileName);
        var raw = text.Split(' ');
        return raw.Select(FixWord).ToArray();
    }

    private static string FixWord(string fixingWord)
    {
        try
        {
            // Remove all non-alphabetic characters
            var word = new string(fixingWord.Where(char.IsLetter).ToArray());
            // Remove all lowercase letters while the first letter is not uppercase
            while (word.Length > 0 && !char.IsUpper(word[0]))
            {
                word = word[1..];
            }

            // Remove all capital letters after the first one
            var firstLetter = word[0];
            var letters = word.Skip(1).Where(char.IsLower).ToArray();
            return firstLetter + new string(letters);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
}