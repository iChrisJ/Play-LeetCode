using System.Collections.Generic;

namespace LeetCodeInCS._0131_Palindrome_Partitioning
{
	public class Solution
	{
		private IList<IList<string>> res;

		private bool[,] isPalindrome;

		public IList<IList<string>> Partition(string s)
		{
			res = new List<IList<string>>();
			if (s == null || s.Length == 0)
				return res;

			// Refer to LeetCode 5 - Longest Palindromic Substring.
			isPalindrome = new bool[s.Length, s.Length];
			for (int i = s.Length - 1; i >= 0; i--)
			{
				for (int j = i; j < s.Length; j++)
				{
					if (i == j || (s[i] == s[j] && (i + 1 == j || isPalindrome[i + 1, j - 1])))
						isPalindrome[i, j] = true;
				}
			}
			Partition(s, 0, new List<string>(), isPalindrome);
			return res;
		}

		private void Partition(string s, int start, IList<string> palindromes, bool[,] isPalindrome)
		{
			if (start == s.Length)
			{
				res.Add(new List<string>(palindromes));
				return;
			}

			for (int i = start; i < s.Length; i++)
			{
				if (isPalindrome[start, i])
				{
					string p = s.Substring(start, i - start + 1);
					palindromes.Add(p);
					Partition(s, i + 1, palindromes, isPalindrome);
					palindromes.RemoveAt(palindromes.Count - 1);
				}
			}
		}
	}
}
