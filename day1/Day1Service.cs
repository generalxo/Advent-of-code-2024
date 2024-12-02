namespace Advent_of_code;

public class Day1Service
{
	public static Day1Model? CreateModel(string input)
	{
		try
		{
			Day1Model result = new();
			int start = 0;
			int end = 0;
			char newLine = '\n';
			for(int i = 0; i < input.Length; i++)
			{
				if(input[i] == newLine)
				{
					end = i - 1;
					var leftSide = int.Parse(input[start..(start + 5)]);
					var rightSide = int.Parse(input[(end - 5)..end]);
					result.LeftSide.Add(leftSide);
					result.RightSide.Add(rightSide);
					start = i + 1;
				}
			}
			return result;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
		return null;
	}

	public static int TotalDistance(Day1Model? input)
	{	
		try
		{
			if(input == null || input.LeftSide == null || input.RightSide == null)
				return 0;

			var l = input.LeftSide.OrderBy(i => i).ToList();
			var r = input.RightSide.OrderBy(i => i).ToList();

			int result = 0;
			for(int i = 0; i < l.Count; i++)
			{
				if (l[i] > r[i])
				{
					result += (l[i] - r[i]);
				}
				else if(r[i] > l[i])
				{
					result += (r[i] - l[i]);
				}
			}
			return result;
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}
		return 0;
	}

	public static int SimilarityScore(Day1Model? input)
	{
		try
		{
			if(input == null || input.LeftSide == null || input.RightSide == null)
				return 0;

			int result = 0;
			for(int i = 0; i < input.LeftSide.Count; i++)
			{
				int similarity = input.RightSide.Count(x => x == input.LeftSide[i]);
				//Console.WriteLine("similarity" + similarity);
				if(similarity != 0)
				{
					result += similarity * input.LeftSide[i];
				}
			}
			return result;
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}
		return 0;
	}
}
