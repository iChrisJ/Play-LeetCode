using System;
using System.Collections;

namespace LeetCodeInCS._0003_Longest_Substring_Without_Repeating_Characters
{
	public class Solution
	{
		public int LengthOfLongestSubstring(string s)
		{
			if (s.Length == 0)
				return 0;
			int i = 0, j = -1;
			Hashtable ht = new Hashtable();
			int res = 0;
			while (i < s.Length)
			{
				if (j + 1 < s.Length && ht[s[j + 1]] == null)
				{
					j++;
					ht[s[j]] = 1;
				}
				else
				{
					ht[s[i]] = null;
					i++;
				}
				res = Math.Max(res, j - i + 1);
			}
			return res;
		}
	}
}
