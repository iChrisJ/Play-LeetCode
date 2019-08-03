using System;
using System.Collections.Generic;

namespace CSharp._0049_Group_Anagrams
{
	public class Solution
	{
		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();

			foreach (string str in strs)
			{
				char[] keychar = str.ToCharArray();
				Array.Sort<char>(keychar);
				string key = new string(keychar);
				if (map.ContainsKey(key))
					map[key].Add(str);
				else
					map.Add(key, new List<string> { str });
			}

			IList<IList<string>> res = new List<IList<string>>();
			foreach (var item in map)
				res.Add(item.Value);
			return res;
		}

		//static void Main(string[] args)
		//{
		//	var a = new Solution().GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
		//}
	}
}
