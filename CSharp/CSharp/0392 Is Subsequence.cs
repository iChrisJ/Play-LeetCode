namespace CSharp._0392_Is_Subsequence
{
	public class Solution
	{
		public bool IsSubsequence(string s, string t)
		{
			if (string.IsNullOrEmpty(s))
				return true;
			if (string.IsNullOrEmpty(t))
				return false;

			int i = 0, j = 0;

			while (j < s.Length && i < t.Length)
			{
				if (s[j] == t[i])
				{
					i++;
					j++;
				}
				else
					i++;
			}

			return j == s.Length;
		}
	}
}
