using System.Collections.Generic;

namespace LeetCodeInCS._0242_Valid_Anagram
{
	public class Solution
	{
		public bool IsAnagram(string s, string t)
		{
			if (s == null || t == null || s.Length != t.Length)
				return false;

			Dictionary<int, int> dict = new Dictionary<int, int>();
			for (int i = 0; i < s.Length; i++)
			{
				if (dict.ContainsKey(s[i]))
					dict[s[i]]++;
				else
					dict.Add(s[i], 1);
			}

			for (int i = 0; i < t.Length; i++)
			{
				if (!dict.ContainsKey(t[i]))
					return false;

				dict[t[i]]--;
				if (dict[t[i]] == 0)
					dict.Remove(t[i]);
			}
			return dict.Count == 0;
		}
	}

	public class Solution2
	{
		public bool IsAnagram(string s, string t)
		{
			if (s == null || t == null || s.Length != t.Length)
				return false;

			int[] dict = new int[26];
			for (int i = 0; i < s.Length; i++)
				dict[s[i] - 'a']++;

			for (int i = 0; i < t.Length; i++)
			{
				if (dict[t[i] - 'a'] == 0)
					return false;
				dict[t[i] - 'a']--;
			}

			for (int i = 0; i < dict.Length; i++)
				if (dict[i] != 0)
					return false;
			return true;
		}
	}
}
