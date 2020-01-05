using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0049_Group_Anagrams
{
	public class Solution
	{
		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			IList<IList<string>> res = new List<IList<string>>();
			if (strs == null || strs.Length == 0)
				return res;

			Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();

			foreach (string str in strs)
			{
				char[] chars = str.ToCharArray();
				Array.Sort(chars);
				string key = new string(chars);

				if (dict.ContainsKey(key))
					dict[key].Add(str);
				else
					dict.Add(key, new List<string> { str });
			}

			foreach (var item in dict)
				res.Add(item.Value);

			return res;
		}
	}
}
