using System.Text;

namespace Maxim
{
	internal class Program
	{
		static void Main(string[] args)
		{

			var vowels = new HashSet<char>(['a', 'e', 'i', 'o', 'u', 'y']);
			var longestVowelsStringStart = -1;
			var longestVowelsStringEnd = -1;

			var input = Console.ReadLine();

			var badSymbols = IsLowerAscii(input);

			if (badSymbols.Count > 0)
			{
				Console.WriteLine($"Были введены неподходящие символы: {string.Join("", badSymbols)}");
			}
			else
			{
				var symbolCount = new Dictionary<char, int>();

				var result = input.Length % 2 == 0
					? string.Concat(Reverse(input[..(input.Length / 2)]), Reverse(input[(input.Length / 2)..]))
					: string.Concat(Reverse(input), input);

				for (var i = 0; i < result.Length; i++)
				{
					var symbol = result[i];

					if (symbolCount.ContainsKey(symbol))
					{
						symbolCount[symbol]++;
					}
					else
					{
						symbolCount[symbol] = 1;
					}

					if (vowels.Contains(symbol))
					{
						if (longestVowelsStringStart == -1)
						{
							longestVowelsStringStart = i;
						}
						longestVowelsStringEnd = i;
					}
				}

				Console.WriteLine($"Обработанная строка: {result}");

				WriteDictionary(symbolCount);

				Console.WriteLine($"Самая длинная подстрока начинающаяся и заканчивающаяся на гласную: {((longestVowelsStringStart != -1) ? result.Substring(longestVowelsStringStart, longestVowelsStringEnd - longestVowelsStringStart + 1) : "ОТСУТСТВУЕТ")}");
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
