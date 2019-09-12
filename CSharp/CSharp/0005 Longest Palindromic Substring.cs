namespace CSharp._0005_Longest_Palindromic_Substring
{
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
					if ((i == j) || (j - i == 1 && s[i] == s[j]) || (s[i] == s[j] && dp[i + 1, j - 1] == true))
						dp[i, j] = true;

					if (dp[i, j] == true && j - i + 1 > res.Length)
						res = s.Substring(i, j - i + 1);
				}
			}

			return res;
		}
	}
}
