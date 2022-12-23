using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal static class Reader
{
    public static int[] ReadFile(string fileName)
    {
        var text = File.ReadAllText(fileName);
        var words = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return words.ToList().Select(x => int.Parse(ParseNumber(x))).ToArray();
    }
    
    public static string ParseNumber(string word)
    {
        word = new string(word.Where(x => !char.IsLetter(x)).ToArray());

        // Split word by digits 0-9 without removing them
        var parts = SplitWithoutRemovingSeparators(word, "0123456789".ToCharArray());
        // Remove all non-digit parts except the first one
        parts = parts.Where((x, i) => i == 0 || x.All(char.IsDigit)).ToArray();
        parts = parts.Select(x => ContainsDigit(x) ? x : ParseSignSequence(x)).ToArray();
        return string.Join("", parts);
    }

    private static string ParseSignSequence(string signs)
    {
        var minusCount = signs.Count(x => x == '-');
        return minusCount % 2 == 0 ? "" : "-";
    }
    
    private static bool ContainsDigit(string word)
    {
        return word.Any(char.IsDigit);
    }
    
    private static IEnumerable<string> SplitWithoutRemovingSeparators(string word, params char[] separators)
    {
        var parts = new List<string>();
        var sb = new StringBuilder();
        foreach (var c in word)
        {
            if (separators.Contains(c))
            {
                if (sb.Length > 0)
                {
                    parts.Add(sb.ToString());
                    sb.Clear();
                }
                parts.Add(c.ToString());
            }
            else
            {
                sb.Append(c);
            }
        }
        if (sb.Length > 0)
        {
            parts.Add(sb.ToString());
        }
        return parts;
    }
}
