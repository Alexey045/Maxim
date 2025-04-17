using System.Text;

namespace Maxim
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();

			Console.WriteLine(input.Length % 2 == 0
				? string.Concat(Reverse(input[..(input.Length / 2)]), Reverse(input[(input.Length / 2)..]))
				: string.Concat(Reverse(input), input));
		}

		static string Reverse(string input)
		{
			var sb = new StringBuilder(input.Length);

			for (int i = input.Length - 1; i > -1; i--)
			{
				sb.Append(input[i]);
			}

			return sb.ToString();
		}
	}
}
