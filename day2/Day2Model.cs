namespace Advent_of_code;

public class Day2Model
{
	public List<string> NumberList { get; set; } = new();
	public int ErrorPos { get; set; } = 0;
	public bool isSafe { get; set; } = false;
	public int FounErrors { get; set; } = 0;
}
