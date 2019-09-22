using System;

namespace CSharp.KMP_Algorithm
{
	class KMPAlgo
	{
		public int KMPSearch(string text, string pattern)
		{
			if (pattern == null || pattern.Length == 0)
				return 0;

			if (text == null || text.Length < pattern.Length)
				return -1;

			int[] prefixArr = GetPrefix(pattern);

			for (int i = 0, j = 0; i < text.Length; i++)
			{
				while (j > 0 && text[i] != pattern[j])
					j = prefixArr[j - 1];

				if (text[i] == pattern[j])
					j++;
				if (j == pattern.Length)
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
