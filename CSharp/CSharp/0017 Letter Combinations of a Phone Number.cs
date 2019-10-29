using System.Collections.Generic;

namespace LeetCodeInCS._0017_Letter_Combinations_of_a_Phone_Number
{
	public class Solution
	{
		// Time Complexity: O(3^n) = O(2^n)
		public IList<string> Result { get; private set; }

		public IList<string> LetterCombinations(string digits)
		{
			Result = new List<string>();
			if (string.IsNullOrEmpty(digits))
				return Result;
			FindLetterCombinations(digits, 0, string.Empty);
			return Result;
		}

		private void FindLetterCombinations(string digits, int index, string str)
		{
			if (index == digits.Length)
			{
				Result.Add(str);
				return;
			}

			char c = digits[index];
			string letters = LetterMap(c);
			for (int i = 0; i < letters.Length; i++)
				FindLetterCombinations(digits, index + 1, str + letters[i]);
		}

		private string LetterMap(char c)
		{
			switch (c)
			{
				case '0':
					return " ";
				case '2':
					return "abc";
				case '3':
					return "def";
				case '4':
					return "ghi";
				case '5':
					return "jkl";
				case '6':
					return "mno";
				case '7':
					return "pqrs";
				case '8':
					return "tuv";
				case '9':
					return "wxyz";
				case '1':
				default:
					return "";
			}
		}
	}
}
