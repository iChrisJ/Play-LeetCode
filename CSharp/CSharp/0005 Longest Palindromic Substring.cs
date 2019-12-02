namespace LeetCodeInCS._0005_Longest_Palindromic_Substring
{
	/// <summary>
	/// dp[i, j]表示字符串s从i..j之间是否为回文字符串
	/// 1. 如果 j == i, 表示一个字符,它是回文
	/// 2. 如果 i+1 == j, 表示表示两个相邻的字符, 如果两个字符相同,则为回文
	/// 3. 如果 i 与 j 处字符相同, 并且 i+1...j-1 之间也是回文字符串, 那么左右都加一个相同的字符,那么也是回文
	/// </summary>
	public class Solution
	{
		public string LongestPalindrome(string s)
		{
			if (s == null || s.Length <= 1)
				return s;

			bool[,] dp = new bool[s.Length, s.Length];
			string res = s.Substring(0, 1);

			for (int i = s.Length - 1; i >= 0; i--)
			{
				for (int j = i; j < s.Length; j++)
				{
					//if ((i == j) || (j - i == 1 && s[i] == s[j]) || (s[i] == s[j] && dp[i + 1, j - 1] == true))
					if (i == j || (s[i] == s[j] && (j == i + 1 || dp[i + 1, j - 1])))
						dp[i, j] = true;

					if (dp[i, j] && j - i + 1 > res.Length)
						res = s.Substring(i, j - i + 1);
				}
			}
			return res;
		}
	}
}
