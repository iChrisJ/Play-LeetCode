using System;

namespace LeetCodeInCS._1071_Greatest_Common_Divisor_of_Strings
{
	public class Solution
	{
		public string GcdOfStrings(string str1, string str2)
		{
			int len1 = str1.Length, len2 = str2.Length;

			for (int i = Math.Min(len1, len2); i >= 1; i--)
			{
				if (len1 % i == 0 && len2 % i == 0)
				{
					string factor = str1.Substring(0, i);
					if (Check(str1, factor) && Check(str2, factor))
						return factor;
				}
			}
			return string.Empty;
		}

		private bool Check(string str, string factor)
		{
			int lenx = str.Length / factor.Length;
			string ans = string.Empty;
			while ((lenx--) > 0)
				ans += factor;
			return ans == str;
		}
	}

	public class Solution2
	{
		public string GcdOfStrings(string str1, string str2)
		{
			if (str1 + str2 != str2 + str1)
				return string.Empty;
			return str1.Substring(0, GetGCD(str1.Length, str2.Length));
		}

		private int GetGCD(int m, int n)
		{
			return n == 0 ? m : GetGCD(n, m % n);
		}
	}
}
