using System.Collections.Generic;
using System.Text;

namespace CSharp._0402_Remove_K_Digits
{
	public class Solution
	{
		public string RemoveKdigits(string num, int k)
		{
			if (k <= 0)
				return num;

			if (k == num.Length)
				return "0";

			Stack<int> stack = new Stack<int>();
			StringBuilder sb = new StringBuilder(num);

			for (int i = 0; i < k; i++)
			{
				while (sb[0] == '0')
					sb.Remove(0, 1);
				stack.Clear();
				stack.Push(0);
				for (int j = 1; j < sb.Length; j++)
				{
					if (sb[j] <= sb[stack.Peek()])
						stack.Push(j);
					else
						break;
				}
				sb.Remove(stack.Peek(), 1);
			}

			while (sb.Length > 1 && sb[0] == '0')
				sb.Remove(0, 1);

			return sb.ToString();
		}
	}
}
