using System.Collections.Generic;

namespace CSharp._0438_Find_All_Anagrams_in_a_String
{
	public class Solution
	{
		public IList<int> FindAnagrams(string s, string p)
		{
			int[] pht = new int[26];
			for (int i = 0; i < p.Length; i++)
				pht[p[i] - 'a']++;

			IList<int> res = new List<int>();

			for (int i = 0; i < s.Length - p.Length + 1; i++)
			{
				int[] stb = new int[26];
				for (int j = i; j < i + p.Length; j++)
				{
					stb[s[j] - 'a']++;
				}
				if (IsValueSameArray(pht, stb))
					res.Add(i);
			}
			return res;
		}

		private bool IsValueSameArray(int[] a, int[] b)
		{
			for (int i = 0; i < a.Length; i++)
			{
				if (b.Length <= i || a[i] != b[i])
					return false;
			}
			return true;
		}

		//static void Main(string[] args)
		//{
		//	IList<int> a = new Solution().FindAnagrams("abab", "ab");
		//}
	}
}
