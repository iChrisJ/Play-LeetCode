using System;
using System.Text;

namespace LeetCodeInCS._0014_Longest_Common_Prefix
{
	public class Solution
	{
		public string LongestCommonPrefix(string[] strs)
		{
			string res = string.Empty;

			if (strs == null || strs.Length == 0)
				return res;

			res = strs[0];
			if (strs.Length == 1)
				return res;

			for (int i = 1; i < strs.Length; i++)
			{
				if (string.IsNullOrEmpty(res))
					return res;
				int len = Math.Min(res.Length, strs[i].Length);
				if (len < res.Length)
					res = res.Substring(0, len);

				for (int j = 0; j < len; j++)
				{
					if (res[j] != strs[i][j])
					{
						res = res.Substring(0, j);
						break;
					}
				}
			}
			return res;
		}
	}

	public class Solution2
	{
		public string LongestCommonPrefix(string[] strs)
		{
			if (strs == null || strs.Length == 0)
				return string.Empty;

			if (strs.Length == 1)
				return strs[0];

			StringBuilder res = new StringBuilder();
			for (int i = 0; i < strs[0].Length; i++)
			{
				for (int j = 1; j < strs.Length; j++)
				{
					if (strs[j].Length <= i || strs[j][i] != strs[0][i])
						return res.ToString();
				}
				res = res.Append(strs[0][i]);
			}
			return res.ToString();
		}
	}
}
