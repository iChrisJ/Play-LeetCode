using System;

namespace LeetCodeInCS._0032_Longest_Valid_Parentheses
{
	public class Solution
	{
		public int LongestValidParentheses(string s)
		{
			if (s == null)
				return 0;

			// dp[i] 表示以 s[i-1] 字符结尾时最长有效的括号
			// 默认 dp[0] = 1 为 s 为空字符串时, 此时最长有效括号为0
			// dp[1] = 0, 表示 s 中的第一个字符, 此时最长有效括号亦为 0. 
			// 因为C#数组的默认值就是 0, 所以不用额外赋值
			int[] dp = new int[s.Length + 1];
			int res = 0;

			for (int i = 1; i < s.Length; i++)
			{
				// 只有当当前字符是')', 才会有有效括号的可能, 所以 s[i] == '(' 不用考虑
				// 1. 如果s[i] == ')', s[i-1] == '(', 则 dp[i] = dp[i-1] +2
				// 2. 如果s[i] == ')', s[i-1] == ')', 则看 dp[i-1]是否为0, 如果为 0, 怎表示之前不是有效括号, 此时dp[i] == 0
				//	  如果 dp[i-1]不为0, 则看dp[i-1]有效括号区域前的第一个字符是否为 '(', 如果是, 则 dp[i] = dp[i-1] + dp[i - 1 - dp[i-1] - 1] + 2;
				if (s[i] == ')')
				{
					if (s[i - 1] == '(')
						dp[i + 1] = dp[i - 1] + 2;
					else if (dp[i] > 0 && i - dp[i] - 1 >= 0 && s[i - dp[i] - 1] == '(')
						dp[i + 1] = dp[i] + dp[i - dp[i] - 1] + 2;
					res = Math.Max(res, dp[i + 1]);
				}
			}
			return res;
		}
	}
}
