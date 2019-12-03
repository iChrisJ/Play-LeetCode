using System;

namespace LeetCodeInCS._0044_Wildcard_Matching
{
	class _0044_Wildcard_Matching
	{
		/// <summary>
		/// dp[i,j] 表示是 p[0..j-1]是否匹配 s[0..i-1]
		/// 1. 如果 s, p 都是空字符串,则匹配成功 dp[0,0]==true;
		/// 2. 如果 p 为空字符串, s 为非空字符串,则p不会成功匹配s, 即 dp[0...i, 0]==false;
		/// 3. 如果 s 为空字符串, p 为非空字符串,则只有 p 全部为*时,才会匹配成功,否则在 p 的第一个不是*的位置匹配失败
		/// 4. 如果 s, p 均不为空字符串, 则如果 s[i] == p[j] 或者 p[j] == '?',且 p[0..j-1]与 s[0..i-1]匹配成功, p[0..j]与 s[0..i]匹配成功
		/// 5. 如果 s, p 均不为空字符串, 如果 p[j] == '*', 此时如果 p[0..j-1]与 s[0..i]匹配成功或者 p[0..j]与 s[0..i-1]匹配成功, 则 p[0..j]与 s[0..i]匹配成功.(请细想!)
		/// </summary>
		public class Solution
		{
			public bool IsMatch(string s, string p)
			{
				if (s == null || p == null)
					throw new ArgumentException("Invalid Parameters.");

				bool[,] dp = new bool[s.Length + 1, p.Length + 1];
				dp[0, 0] = true;

				for (int i = 1; i <= p.Length; i++)
				{
					if (p[i - 1] == '*')
						dp[0, i] = true;
					else
						break;
				}

				for (int i = 1; i <= s.Length; i++)
				{
					for (int j = 1; j <= p.Length; j++)
					{
						if (s[i - 1] == p[j - 1] || p[j - 1] == '?')
							dp[i, j] = dp[i - 1, j - 1];
						else if (p[j - 1] == '*')
							dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
					}
				}
				return dp[s.Length, p.Length];
			}
		}
	}
}
