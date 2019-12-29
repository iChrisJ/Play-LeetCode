using System.Collections.Generic;

namespace LeetCodeInCS._0290_Word_Pattern
{
	public class Solution
	{
		public bool IsIsomorphic(string s, string t)
		{
			if (s.Length != t.Length)
				return false;

			Dictionary<char, char> dict1 = new Dictionary<char, char>();
			Dictionary<char, char> dict2 = new Dictionary<char, char>();
			for (int i = 0; i < s.Length; i++)
			{
				if (dict1.ContainsKey(s[i]) != dict2.ContainsKey(t[i]))
					return false;

				if (!dict1.ContainsKey(s[i]) && !dict2.ContainsKey(t[i]))
				{
					dict1.Add(s[i], t[i]);
					dict2.Add(t[i], s[i]);
				}
				else if (dict1[s[i]] != t[i] || dict2[t[i]] != s[i])
					return false;
			}
			return true;
		}
	}
}
