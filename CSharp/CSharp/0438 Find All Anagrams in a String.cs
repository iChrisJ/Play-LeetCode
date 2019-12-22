using System.Collections.Generic;

namespace LeetCodeInCS._0438_Find_All_Anagrams_in_a_String
{
	public class Solution
	{
		public IList<int> FindAnagrams(string s, string p)
		{
			int[] pArr = new int[26];
			for (int i = 0; i < p.Length; i++)
				pArr[p[i] - 'a']++;

			IList<int> res = new List<int>();
			for (int i = 0; i < s.Length - p.Length + 1; i++)
			{
				int[] sArr = new int[26];
				for (int j = i; j < i + p.Length; j++)
					sArr[s[j] - 'a']++;

				if (AreSameArrays(pArr, sArr))
					res.Add(i);
			}
			return res;
		}

		private bool AreSameArrays(int[] a, int[] b)
		{
			for (int i = 0; i < 26; i++)
				if (a[i] != b[i])
					return false;
			return true;
		}
	}
}
