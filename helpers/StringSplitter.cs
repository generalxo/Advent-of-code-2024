namespace Advent_of_code;

public class StringSplitter
{
	public static List<string>? NewLineSplitter(string input)
	{
		try
		{
			List<string> result = new();
			char newLineChar = '\n';
			int start = 0;
			int end = 0;

			for(int i = 0; i < input.Length; i++)
			{
				if(input[i] == newLineChar)
				{
					end = i - 1;
					string word = input[start..end];
					result.Add(word);
					start = i + 1;
				}
			}

			return result;
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}
		return null;
	}
}
