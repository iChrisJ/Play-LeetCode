using System;

namespace LeetCodeInCS._0028_Implement_strStr__
{
	public class Solution
	{
		public int StrStr(string haystack, string needle)
		{
			if (needle == null || needle.Length == 0)
				return 0;

			if (haystack == null || haystack.Length < needle.Length)
				return -1;

			for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
				if (haystack[i] == needle[0] && haystack.Substring(i, needle.Length) == needle)
					return i;
			return -1;
		}
	}

	public class Solution2
	{
		/// KMP Algorithm
		public int StrStr(string haystack, string needle)
		{
			if (needle == null || needle.Length == 0)
				return 0;

			if (haystack == null || haystack.Length < needle.Length)
				return -1;

			int[] prefix = GetPrefix(needle);

			for (int i = 0, j = 0; i < haystack.Length; i++)
			{
				while (j > 0 && haystack[i] != needle[j])
					j = prefix[j - 1];

				if (haystack[i] == needle[j])
					j++;

				if (j == needle.Length)
					return i - j + 1;
			}
			return -1;
		}

		private int[] GetPrefix(string pattern)
		{
			if (pattern == null || pattern.Length == 0)
				throw new Exception("Incorrect Parameter.");

			int[] prefixArr = new int[pattern.Length];

			for (int i = 1, j = 0; i < pattern.Length; i++)
			{
				while (j > 0 && pattern[i] != pattern[j])
					j = prefixArr[j - 1];

				if (pattern[i] == pattern[j])
					j++;
				prefixArr[i] = j;
			}
			return prefixArr;
		}
	}
}
