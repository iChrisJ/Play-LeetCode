using System.Collections.Generic;

namespace LeetCodeInCS._0242_Valid_Anagram
{
	public class Solution
	{
		public bool IsAnagram(string s, string t)
		{
			Dictionary<char, int> dic = new Dictionary<char, int>();
			for (int i = 0; i < s.Length; i++)
			{
				if (dic.ContainsKey(s[i]))
				{
					dic[s[i]]++;
				}
				else
				{
					dic.Add(s[i], 1);
				}
			}

			for (int i = 0; i < t.Length; i++)
			{
				if (dic.ContainsKey(t[i]))
				{
					if (dic[t[i]] > 1) dic[t[i]]--;
					else dic.Remove(t[i]);
				}
				else
				{
					return false;
				}
			}

			return dic.Count == 0;
		}
	}

	public class Solution2
	{
		public bool IsAnagram(string s, string t)
		{
			int[] dic = new int[26];

			for (int i = 0; i < s.Length; i++)
				dic[s[i] - 'a'] += 1;

			for (int i = 0; i < t.Length; i++)
				dic[t[i] - 'a'] -= 1;

			for (int i = 0; i < dic.Length; i++)
			{
				if (dic[i] != 0)
					return false;
			}
			return true;
		}
	}
}
