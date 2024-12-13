namespace Advent_of_code;

public class Day4Service
{
	public static char[][] CreateData(List<string> input)
	{
		var result = input.Select(x => x.ToCharArray()).ToArray();

		return result;
	}

	public static int FindXmasHorAndVer (char[][] input)
	{
		int result = 0;

		for(int i = 0; i < input.Length; i++)
		{
			for(int j = 0; j < input.LongLength; j++)
			{
				//Console.WriteLine($"i: {i} j: {j} char: {input[i][j]}");
				if(input[i][j] == 'X')
				{
					// Horizontal
					if(j + 3 < input.LongLength)
					{
						if(input[i][j + 1] == 'M' && input[i][j + 2] == 'A' && input[i][j + 3] == 'S')
						{
							result += 1;
						}
					}
					// Vertical
					if(i + 3 < input.Length)
					{
						if(input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i + 3][j] == 'S')
						{
							result += 1;
						}
					}
					// Diagonal Right Down
					if(i + 3 < input.Length && j + 3 < input.LongLength)
					{
						if(input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' && input[i + 3][j + 3] == 'S')
						{
							result += 1;
						}
					}
					// Diagonal Left Down
					if(i + 3 < input.Length && j - 3 >= 0)
					{
						if(input[i +1][j - 1] == 'M' && input[i + 2][j - 2] == 'A' && input[i + 3][j - 3] == 'S')
						{
							result += 1;
						}
					}
					// Horizontal Reverse
					if(j - 3 >= 0)
					{
						if(input[i][j - 1] == 'M' && input[i][j - 2] == 'A' && input[i][j - 3] == 'S')
						{
							result += 1;
						}
					}
					// Vertical Reverse
					if(i - 3 >= 0)
					{
						if(input[i - 1][j] == 'M' && input[i - 2][j] == 'A' && input[i - 3][j] == 'S')
						{
							result += 1;
						}
					}
					// Diagonal Up Left
					if(i - 3 >= 0 && j - 3 >= 0) // should trigger at i3,j9
					{
						if(input[i - 1][j - 1] == 'M' && input[i - 2][j - 2] == 'A' && input[i - 3][j - 3] == 'S')
						{
							result += 1;
						}
					}
					// Diagonal Up Right
					if(i - 3 >= 0 && j + 3 < input.LongLength)
					{
						if(input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' && input[i - 3][j + 3] == 'S')
						{
							result += 1;
						}
					}
				}
			}
		}

		return result;
	}

	public static int FindMasInShapeOfX(char[][] input)
	{
		int result = 0;

		for(int i = 1; i < input.Length - 1; i++)
		{
			for(int j = 1; j < input.LongLength - 1; j++)
			{
				if(input[i][j] == 'A')
				{
					// Both M on bottom row & both S on top row
					if(input[i + 1][j + 1] == 'M' && input[i + 1][j - 1] == 'M' && input[i - 1][j - 1] == 'S' && input[i - 1][j + 1] == 'S')
					{
						result += 1;
					}
					// Both S on bottom eow & both M on top row
					if(input[i + 1][j + 1] == 'S' && input[i + 1][j - 1] == 'S' && input[i - 1][j - 1] == 'M' && input[i - 1][j + 1] == 'M')
					{
						result += 1;
					}
					// Botn M on right side & both S on left side
					if(input[i + 1][j + 1] == 'M' && input[i + 1][j - 1] == 'S' && input[i - 1][j - 1] == 'S' && input[i - 1][j + 1] == 'M')
					{
						result += 1;
					}
					// Both S on right side & both M on left side
					if(input[i + 1][j + 1] == 'S' && input[i + 1][j - 1] == 'M' && input[i - 1][j - 1] == 'M' && input[i - 1][j + 1] == 'S')
					{
						result += 1;
					}
				}
			}
		}

		return result;
	}
}
//MSMSMAXXAXXXXAXXA XMAS MXS XMAS MXMXMASMSSXASAMXSAMXXSAMXXMAMMSSMSSSMXSAMXXXXXSXSXSMSMMMMSXMASMMMSMSSSSMMMSAXSSSSSS XMAS AMXMSSMMSMMMSAMSAMXAMAMXS
