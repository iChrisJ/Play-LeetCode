using System.Collections.Generic;

namespace LeetCodeInCS._0205_Isomorphic_Strings
{
	public class Solution
	{
		public bool IsIsomorphic(string s, string t)
		{
			if (s.Length != t.Length)
				return false;

			Dictionary<char, char> map = new Dictionary<char, char>();
			Dictionary<char, char> rmap = new Dictionary<char, char>();

			for (int i = 0; i < s.Length; i++)
			{
				if (!map.ContainsKey(s[i]) && !rmap.ContainsKey(t[i]))
				{
					map.Add(s[i], t[i]);
					rmap.Add(t[i], s[i]);
				}
				else if (map.ContainsKey(s[i]) && rmap.ContainsKey(t[i]) && map[s[i]] == t[i] && rmap[t[i]] == s[i])
				{
					// let it pass, don't want to write the conditions in else {}
				}
				else
					return false;
			}
			return true;
		}
	}
}
