namespace Advent_of_code;

public class Day2Main
{
	public static void Day2MainFunc()
	{
		var data = StringSplitter.NewLineSplitter(Day2Input.Input);
		if(data is null)
			return;

		foreach(string item in data)
		{
			Console.WriteLine(item);
		}

		int result = Day2Service.SafeReports(data);
		Console.WriteLine($"result1 {result}");

		Console.ReadKey();
	}
}
