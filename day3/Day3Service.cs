using System.Text.RegularExpressions;
namespace Advent_of_code;

public class Day3Service
{
	/* Part 2 Steps
	Select all text from don't() to but not including do()
	don't\(\)(.*?)(?=do\(\))
	This will be done recursefly until we dont find anything. While loop maybe?
	Last select all text after don't() until the end 
	*/
	
	public MatchCollection PatternMatch(string input)
	{
		string regexPattern = @"mul\((\d+),(\d+)\)";
		MatchCollection matches = Regex.Matches(input, regexPattern);

		return matches;
	}
	
	public string? RemoveAllTextBeforeDo(string input)
	{
		try
		{
			string regexPattern = @"^(.*?)(?=do\(\))";
			//var text = Regex.Match(input, regexPattern).ToString();
			string? result = Regex.Replace(input, regexPattern, "");

			//string result = input.Remove(0, text.Length);

			return result;
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}
		return null;
	}

	public string? RemoveNewLine(string input)
    {
        try
        {
            string regexPattern = @"\n";
			bool noMoreTextFound = false;
            while (!noMoreTextFound)
			{
				var isMatch = Regex.IsMatch(input, regexPattern, RegexOptions.Singleline);
                if (isMatch is true)
                    input = Regex.Replace(input, regexPattern, "", RegexOptions.Singleline);
                else
                    noMoreTextFound = true;
            }
			
			return input;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return null;
    }

    public string? RemoveDontToDo(string input)
	{
		try
		{
            string? result = input;
            string regexPattern = @"don't\(\)(.*?)(?=do\(\))";
			bool noMoreTextFound = false;

			while (!noMoreTextFound)
			{
				var match = Regex.IsMatch(result, regexPattern, RegexOptions.Singleline);

				if (match is true)
					result = Regex.Replace(result, regexPattern, "", RegexOptions.Singleline);
				else
                    noMoreTextFound = true;
			}
			return result;
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}
		return null;
	}

	public string? RemoveAllTextAfterDont(string input)
	{
		try
		{
			string regexPattern = @"(?=don't\(\)).*";
            var result = Regex.Replace(input, regexPattern, "", RegexOptions.Singleline);

            return result;
        }
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
        return null;
    }

	public List<Tuple<int,int>> GetNumbersFromMatches(MatchCollection matches)
	{
		List<Tuple<int,int>> result = new();

		foreach(Match match in matches)
		{
			var str1 = match.Groups[1].Value;
			var str2 = match.Groups[2].Value;

			//Console.WriteLine($"str1: {str1} str2: {str2}");

			int num1 = int.Parse(str1);
			int num2 = int.Parse(str2);

			Tuple<int, int> item = new Tuple<int, int>(num1, num2);
			result.Add(item);
		}

		return result;
	}

	public int Multiply(List<Tuple<int, int>> input)
	{
		int result = 0;

		foreach(Tuple<int,int> tuple in input)
		{
			int temp = tuple.Item1 * tuple.Item2;
			result += temp;
		}

		return result;
	}
}
