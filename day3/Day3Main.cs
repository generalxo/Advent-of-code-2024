namespace Advent_of_code;

public class Day3Main
{
	public static void Day3MainFunc()
	{
		Day3Service service = new Day3Service();
		
		string? text = service.RemoveNewLine(Day3Input.Input);

        if (!string.IsNullOrEmpty(text))
            text = service.RemoveDontToDo(text);

        if (!string.IsNullOrEmpty(text))
            text = service.RemoveAllTextAfterDont(text);

        if (!string.IsNullOrEmpty(text))
        {
            var matches = service.PatternMatch(text);
            var lstIntTuple = service.GetNumbersFromMatches(matches);

            var result = service.Multiply(lstIntTuple);
            Console.WriteLine($"result: {result}");
        }
    }
}
