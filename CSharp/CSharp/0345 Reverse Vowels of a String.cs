using System.Collections.Generic;

namespace LeetCodeInCS._0345_Reverse_Vowels_of_a_String
{
	public class Solution
	{
		public string ReverseVowels(string s)
		{
			if (s == null || s.Length <= 1)
				return s;

			HashSet<char> set = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
			char[] chars = s.ToCharArray();
			for (int l = 0, r = chars.Length - 1; l < r;)
			{
				if (!set.Contains(chars[l]))
					l++;
				else if (!set.Contains(chars[r]))
					r--;
				else
				{
					char temp = chars[l];
					chars[l] = chars[r];
					chars[r] = temp;
					l++;
					r--;
				}
			}

			return new string(chars);
		}
	}
}
