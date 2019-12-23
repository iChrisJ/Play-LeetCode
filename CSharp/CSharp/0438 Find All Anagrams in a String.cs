using System.Collections.Generic;

namespace LeetCodeInCS._0438_Find_All_Anagrams_in_a_String
{
	public class Solution
	{
		public IList<int> FindAnagrams(string s, string p)
		{
			int[] pArr = new int[26];
			for (int i = 0; i < p.Length; i++)
				pArr[p[i] - 'a']++;

			IList<int> res = new List<int>();
			for (int i = 0; i < s.Length - p.Length + 1; i++)
			{
				int[] sArr = new int[26];
				for (int j = i; j < i + p.Length; j++)
					sArr[s[j] - 'a']++;

				if (AreSameArrays(pArr, sArr))
					res.Add(i);
			}
			return res;
		}

		private bool AreSameArrays(int[] a, int[] b)
		{
			for (int i = 0; i < 26; i++)
				if (a[i] != b[i])
					return false;
			return true;
		}
	}

	public class Solution2
	{
		public IList<int> FindAnagrams(string s, string p)
		{
			int l = 0, r = 0;
			Dictionary<char, int> need = new Dictionary<char, int>();
			Dictionary<char, int> window = new Dictionary<char, int>();
			int match = 0;
			IList<int> res = new List<int>();

			foreach (char c in p)
			{
				if (need.ContainsKey(c))
					need[c]++;
				else
					need.Add(c, 1);
			}

			while (r < s.Length)
			{
				if (window.ContainsKey(s[r]))
					window[s[r]]++;
				else
					window.Add(s[r], 1);

				if (need.ContainsKey(s[r]) && window[s[r]] == need[s[r]])
					match++;
				r++;

				if (r - l == p.Length)
				{
					if (match == need.Count)
						res.Add(l);

					// because window[s[l]] will minus one soon, so if window[s[l]] == need[s[l]], then match will be reduced after window[s[l]]--
					if (need.ContainsKey(s[l]) && window[s[l]] == need[s[l]])
						match--;
					window[s[l]]--;

					l++;
				}
			}
			return res;
		}
	}
}
