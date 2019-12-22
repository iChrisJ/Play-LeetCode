namespace LeetCodeInCS._0125_Valid_Palindrome
{
	/// <summary>
	/// Two points.
	/// </summary>
	public class Solution
	{
		public bool IsPalindrome(string s)
		{
			if (s == null)
				return false;
			if (s.Length <= 1)
				return true;

			int l = 0, r = s.Length - 1;
			while (l <= r)
			{
				if (!char.IsLetterOrDigit(s[l]))
					l++;
				else if (!char.IsLetterOrDigit(s[r]))
					r--;
				else if (char.ToLower(s[l]) != char.ToLower(s[r]))
					return false;
				else
				{
					l++;
					r--;
				}
			}
			return true;
		}
	}
}
