namespace Advent_of_code;

public class Day4Main
{
	public static void Day4MainFunc()
	{
		var data = StringSplitter.NewLineSplitter(Day4Input.Input);
		if(data is null)
			return;

		var char2dArr = Day4Service.CreateData(data);
		Console.WriteLine($"length: {char2dArr.Length} longlength: {char2dArr.LongLength}");
		int XmasFound = 0;
		//XmasFound = Day4Service.FindXmasHorAndVer(char2dArr);
		
		XmasFound = Day4Service.FindMasInShapeOfX(char2dArr);

		Console.WriteLine($"XmasFound: {XmasFound}");
	}
}
