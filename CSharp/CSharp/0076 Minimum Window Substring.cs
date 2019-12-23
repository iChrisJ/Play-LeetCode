using System.Collections.Generic;

namespace LeetCodeInCS._0076_Minimum_Window_Substring
{
	public class Solution
	{
		public string MinWindow(string s, string t)
		{
			int left = 0, right = 0, start = 0; //[left, right)
			Dictionary<char, int> need = new Dictionary<char, int>();
			Dictionary<char, int> window = new Dictionary<char, int>();
			int match = 0;
			int res = s.Length + 1;

			foreach (char c in t)
			{
				if (need.ContainsKey(c))
					need[c]++;
				else
					need.Add(c, 1);
			}

			while (right < s.Length)
			{
				if (window.ContainsKey(s[right]))
					window[s[right]]++;
				else
					window.Add(s[right], 1);

				if (need.ContainsKey(s[right]) && window[s[right]] == need[s[right]])
					match++;
				right++;

				while (match == need.Count)
				{
					if (right - left < res)
					{
						start = left;
						res = right - left;
					}

					window[s[left]]--;
					if (need.ContainsKey(s[left]) && window[s[left]] < need[s[left]])
						match--;
					left++;
				}
			}

			return res == s.Length + 1 ? "" : s.Substring(start, res);
		}
	}
}
