using System;

namespace LeetCodeInCS._0010_Regular_Expression_Matching
{
	public class Solution
	{
		public bool IsMatch(string s, string p)
		{
			if (s == null || p == null)
				throw new ArgumentException("Invalid Parameters.");

			// dp[i,j]表示 p[0..j]是否匹配 s[0..i]
			bool[,] dp = new bool[s.Length + 1, p.Length + 1];

			// 初始化
			// 1. dp[0, 0] == true, 表示s, p都为空字符串时, p 可以匹配 s.
			dp[0, 0] = true;

			// 2. dp[0..i, 0] = false, 如果 p 为空字符串, s 是非空字符串, 此时 p 是无法匹配 s 的.(数组的初始值为false, 不用额外设置)
			// 3. dp[0, 0..j]: 如果 s 为空字符串, p 为非空. 此时只有 p 是 #*#*#*...的格式的时候, 才可以匹配 s 成功.
			// 此时, 我们可以看到 p 的长度应该是偶数, 并且偶数位置上的字符应该是 '*'
			// 因此对于奇数长度, dp[0, j] == false,数组默认值 我们可以跳过.
			// 其实我们可以看到重复的子模式 #*, 其长度只有 2. 我们可以只使用 dp[0, j-2], 而不是每次扫描 j的长度来检查是否匹配#*#*#*模式
			for (int j = 2; j <= p.Length; j += 2)
				if (p[j - 1] == '*')
					dp[0, j] = dp[0, j - 2];

			// 1. 如果 p[j] == s[i], dp[i, j] == dp[i-1, j-1]
			// 2. 如果 p[j] == '.', dp[i, j] == dp[i-1, j-1]
			// 3. 如果 p[j] == '*'
			//	  a. 如果 p[j-1] != '.' && p[j-1] != s[i], 则 b* 当作空字符, 此时 dp[i, j] == dp[i, j-2]
			//	  #########a(i)
			//	  ########b*(j)
			//	  b. 如果 p[j-1] == '.' || p[j-1] == s[i]
			//		如果 p[j-1] 被算作空字符, 则 dp[i, j] == dp[i, j-2]
			//		如果 * 算作一个, 则 dp[i, j] == dp[i-1, j-2]
			//		如果 * 算作多个, 则 dp[i, j] == dp[i-1, j]
			for (int i = 1; i <= s.Length; i++)
			{
				for (int j = 1; j <= p.Length; j++)
				{
					if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
						dp[i, j] = dp[i - 1, j - 1];
					else if (p[j - 1] == '*')
					{
						if (p[j - 2] != '.' && s[i - 1] != p[j - 2])
							dp[i, j] = dp[i, j - 2];
						else
							dp[i, j] = dp[i, j - 2] || dp[i - 1, j - 2] || dp[i - 1, j];
					}
				}
			}
			return dp[s.Length, p.Length];
		}
	}
}
