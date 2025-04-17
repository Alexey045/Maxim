using System.Text;

namespace Maxim
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();

			var badSymbols = IsLowerAscii(input);

			if (badSymbols.Count > 0)
			{
				Console.WriteLine($"Были введены неподходящие символы: {string.Join("", badSymbols)}");
			}
			else
			{
				var symbolCount = new Dictionary<char, int>();
				foreach (var symbol in input)
				{
					if (symbolCount.ContainsKey(symbol))
					{
						symbolCount[symbol]++;
					}
					else
					{
						symbolCount[symbol] = 1;
					}
				}

				Console.WriteLine(input.Length % 2 == 0
					? string.Concat(Reverse(input[..(input.Length / 2)]), Reverse(input[(input.Length / 2)..]))
					: string.Concat(Reverse(input), input));

				WriteDictionary(symbolCount);
			}
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

		static List<char> IsLowerAscii(string input)
		{
			var result = new List<char>();

			foreach (char c in input)
			{
				if (!char.IsAsciiLetterLower(c))
				{
					result.Add(c);
				}
			}

			return result;
		}

		static void WriteDictionary(Dictionary<char, int> dict)
		{
			Console.WriteLine("Количество входящих символов и их количество:");
			foreach (var item in dict)
			{
				Console.WriteLine($"{item.Key} - {item.Value}");
			}
		}
	}
}
