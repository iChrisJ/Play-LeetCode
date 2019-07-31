using System.Collections.Generic;

namespace CSharp._0290_Word_Pattern
{
	public class Solution
	{
		public bool WordPattern(string pattern, string str)
		{
			Dictionary<char, string> map = new Dictionary<char, string>();
			Dictionary<string, char> rmap = new Dictionary<string, char>();

			string[] strArr = str.Split(" ");

			if (pattern.Length != strArr.Length)
				return false;

			for (int i = 0; i < strArr.Length; i++)
			{
				if (!map.ContainsKey(pattern[i]) && !rmap.ContainsKey(strArr[i]))
				{
					map.Add(pattern[i], strArr[i]);
					rmap.Add(strArr[i], pattern[i]);
				}
				else if (map.ContainsKey(pattern[i]) && rmap.ContainsKey(strArr[i]) && map[pattern[i]] == strArr[i] && rmap[strArr[i]] == pattern[i])
				{
					// let it pass, don't want to write the conditions in else {}
				}
				else
					return false;
			}
			return true;
		}
	}
}
