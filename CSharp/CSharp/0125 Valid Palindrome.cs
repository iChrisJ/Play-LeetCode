using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp._0125_Valid_Palindrome
{
	public class Solution
	{
		public bool IsPalindrome(string s)
		{
			int i = 0, j = s.Length - 1;
			while (i <= j)
			{
				if (char.IsLetterOrDigit(s[i]) && char.IsLetterOrDigit(s[j]) && char.ToLower(s[i]) != char.ToLower(s[j]))
					return false;
				else if (!char.IsLetterOrDigit(s[i]))
					i++;
				else if (!char.IsLetterOrDigit(s[j]))
					j--;
				else // char.IsLetterOrDigit(s[i]) && char.IsLetterOrDigit(s[j]) && char.ToLower(s[i]) == char.ToLower(s[j])
				{
					i++;
					j--;
				}
			}
			return true;
		}
	}
}
