using System.Collections.Generic;

namespace LeetCodeInCS._0017_Letter_Combinations_of_a_Phone_Number
{
	public class Solution
	{
		private Dictionary<char, string> dict;

		private IList<string> res;

		public IList<string> LetterCombinations(string digits)
		{
			res = new List<string>();
			if (digits == null || digits.Length == 0)
				return res;

			dict = new Dictionary<char, string>
			{
				{'2', "abc"},
				{'3', "def"},
				{'4', "ghi"},
				{'5', "jkl"},
				{'6', "mno"},
				{'7', "pqrs"},
				{'8', "tuv"},
				{'9', "wxyz"}
			};

			GenerateCombination(digits, 0, string.Empty);
			return res;
		}

		// DFS
		private void GenerateCombination(string digits, int index, string cur_combine)
		{
			if (index == digits.Length)
			{
				res.Add(cur_combine);
				return;
			}

			for (int i = 0; i < dict[digits[index]].Length; i++)
				GenerateCombination(digits, index + 1, cur_combine + dict[digits[index]][i]);
		}
	}
}
