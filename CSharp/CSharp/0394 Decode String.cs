using System.Collections.Generic;
using System.Text;

namespace LeetCodeInCS._0394_Decode_String
{
	public class Solution
	{
		public string DecodeString(string s)
		{
			if (s == null || s.Length == 0)
				return string.Empty;

			StringBuilder res = new StringBuilder();
			int multi = 0;
			Stack<int> multi_stack = new Stack<int>();
			Stack<StringBuilder> res_stack = new Stack<StringBuilder>();

			foreach (char c in s)
			{
				if (c >= '0' && c <= '9')
					multi = multi * 10 + int.Parse(c.ToString());
				else if (c == '[')
				{
					multi_stack.Push(multi);
					res_stack.Push(res);
					multi = 0;
					res = new StringBuilder();
				}
				else if (c == ']')
				{
					int cur_multi = multi_stack.Pop();
					StringBuilder tmp = res_stack.Pop();
					while ((cur_multi--) > 0)
						tmp.Append(res);
					res = tmp;
				}
				else
					res.Append(c);
			}
			return res.ToString();
		}
	}
}
