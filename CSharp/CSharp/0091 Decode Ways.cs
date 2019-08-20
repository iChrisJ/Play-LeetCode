namespace CSharp._0091_Decode_Ways
{

	/// Dynamic Programming
	/// Time Complexity: O(n)
	/// Space Complexity: O(n)
	public class Solution
	{
		public int NumDecodings(string s)
		{
			if (string.IsNullOrEmpty(s) || s[0] == '0')
				return 0;

			int[] dp = new int[s.Length + 1];
			dp[0] = 1;
			for (int i = 1; i < dp.Length; i++)
			{
				dp[i] = s[i - 1] == '0' ? 0 : dp[i - 1];
				if (i - 2 >= 0 && (s[i - 2] == '1' || (s[i - 2] == '2' && s[i - 1] <= '6')))
					dp[i] += dp[i - 2];
			}
			return dp[s.Length];
		}
	}
}
