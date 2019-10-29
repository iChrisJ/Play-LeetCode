using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0451_Sort_Characters_By_Frequency
{
	public class Solution
	{
		public string FrequencySort(string s)
		{
			Dictionary<char, int> dict = new Dictionary<char, int>();
			foreach (char c in s)
			{
				if (dict.ContainsKey(c))
					dict[c]++;
				else
					dict.Add(c, 1);
			}

			char[] cArr = s.ToCharArray();
			Array.Sort<char>(cArr,
				(x, y) =>
				{
					return dict[y] == dict[x] ? y - x : dict[y] - dict[x];
				});
			return new string(cArr);
		}
	}
}
