using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0003_Longest_Substring_Without_Repeating_Characters
{
	public class Solution
	{
		public int LengthOfLongestSubstring(string s)
		{
			if (s == null || s.Length == 0)
				return 0;

			Dictionary<char, int> dict = new Dictionary<char, int>();
			int l = 0, r = -1; //[l..r] doesn't has dup char.
			int res = 0;
			while (r + 1 < s.Length)  // when r is in the end of string, the loop ends.
			{
				if (!dict.ContainsKey(s[++r])) // if next value of r index is not in the dict, add it.
					dict.Add(s[r], r);
				else // otherwise, move l index to the next of previous s[r]
				{
					int prev = dict[s[r]];
					l = prev < l ? l : prev + 1; // make sure l moves to right.
					dict[s[r]] = r;
				}
				res = Math.Max(res, r - l + 1);
			}
			return res;
		}
	}

	public class Solution2
	{
		public int LengthOfLongestSubstring(string s)
		{
			if (s == null || s.Length == 0)
				return 0;

			Dictionary<char, int> dict = new Dictionary<char, int>();
			int l = 0, r = -1; //[l..r] doesn't has dup char.
			int res = 0;
			while (l < s.Length)
			{
				if (r + 1 < s.Length && !dict.ContainsKey(s[r + 1]))
					dict.Add(s[++r], 1);
				else
					dict.Remove(s[l++]);
				res = Math.Max(res, r - l + 1);
			}
			return res;
		}
	}
}
