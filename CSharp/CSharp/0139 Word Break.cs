using System.Collections.Generic;

namespace LeetCodeInCS._0139_Word_Break
{
	public class Solution
	{
		public bool WordBreak(string s, IList<string> wordDict)
		{
			bool[] dp = new bool[s.Length + 1];

			HashSet<string> set = new HashSet<string>(wordDict);

			for (int i = 1; i <= s.Length; i++)
			{
				if (set.Contains(s.Substring(0, i)))
				{
					dp[i] = true;
					continue;
				}

				for (int j = i - 1; j > 0; j--)
				{
					if (dp[j] && set.Contains(s.Substring(j, i - j)))
						dp[i] = true;
				}
			}

			return dp[s.Length];
		}
	}
}
