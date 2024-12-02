namespace Advent_of_code;

public class Day1Main
{
    public static void Day1MainFunc()
    {
        var data = Day1Service.CreateModel(InputDay1.input);

        var totalLength = Day1Service.TotalDistance(data);
		Console.WriteLine("totalLength " + totalLength);

		var similarityScore = Day1Service.SimilarityScore(data);
		Console.WriteLine("similarityScore " + similarityScore);
        Console.ReadKey();
    }
}
