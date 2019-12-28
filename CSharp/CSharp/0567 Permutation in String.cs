using System;

namespace LeetCodeInCS._0567_Permutation_in_String
{
	public class Solution
	{
		public bool CheckInclusion(string s1, string s2)
		{
			if (s1 == null || s2 == null || s1.Length > s2.Length)
				return false;

			int[] s1map = new int[26];

			foreach (char c in s1)
				s1map[c - 'a']++;

			int l = 0;
			while (l <= s2.Length - s1.Length)
			{
				if (s1map[s2[l] - 'a'] > 0)
				{
					int match = s1.Length;
					int[] copy = new int[26];
					Array.Copy(s1map, copy, 26);
					for (int i = l; i < l + s1.Length; i++)
					{
						if (copy[s2[i] - 'a'] > 0)
						{
							copy[s2[i] - 'a']--;
							match--;
						}
						else
							break;
					}

					if (match == 0)
						return true;
				}
				l++;
			}
			return false;
		}
	}
}
