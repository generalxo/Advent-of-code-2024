namespace Advent_of_code;

public class Day2Service
{
	public static int SafeReports(List<string> input)
	{
		try
		{
			int result = 0;
			char space = ' ';

			for(int i = 0; i < input.Count; i++)
			{
				var numbers = input[i].Split(space).ToList();
				if(numbers == null || numbers.Count == 0)
				{
					return 0;
				}
				bool isSafe = CheckNumbers(numbers);
				if(isSafe is true)
				{
					result += 1;
				}
				else
				{
					bool foundSafe = false;
					var new2dList = Create2dList(numbers);
					foreach(List<string> list in new2dList)
					{
						foundSafe = CheckNumbers(list);
						if(foundSafe is true)
							break;
					}
					if(foundSafe is true)
					{
						result += 1;
					}
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

	// I will create a new 2d List of numbers where one of the numbers has been removed.
	// Then i will run it through the original eval func.
	private static List<List<string>> Create2dList(List<string> numbers)
	{
		List<List<string>> newList = new();
		for(int i = 0; i < numbers.Count; i++)
		{
			List<string> tempList = new(numbers);
			tempList.RemoveAt(i);
			newList.Add(tempList);
		}
		return newList;
	}

	private static bool CheckNumbers(List<string> numbers)
	{
		int num = 0;
		int prevNum = 0;
		Direction direction = new();

		for(int i = 1; i < numbers.Count; i++)
		{
			num = int.Parse(numbers[i]);
			prevNum = int.Parse(numbers[i - 1]);

			if(i == 1)
			{
				if(prevNum == num)
				{
					return false;
				}
				else if(prevNum < num)
				{
					direction = Direction.increasing;
					if((num - prevNum) > 3)
					{
						return false;
					}
				}
				else if (prevNum > num)
				{
					direction = Direction.decreasing;
					if ((prevNum - num) > 3)
					{
						return false;
					}
				}
			}
			else
			{
				if(direction == Direction.increasing)
				{
					if(prevNum > num || prevNum == num || (num - prevNum) > 3)
					{
						return false;
					}
				}
				else if(direction == Direction.decreasing)
				{
					if(prevNum < num || prevNum == num || (prevNum - num) > 3)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private enum Direction
	{
		increasing,
		decreasing
	}
}
