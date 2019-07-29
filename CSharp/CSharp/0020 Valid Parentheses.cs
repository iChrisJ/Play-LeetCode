using System.Collections.Generic;

namespace CSharp._0020_Valid_Parentheses
{
	public class Solution
	{
		public bool IsValid(string s)
		{
			Stack<char> stack = new Stack<char>();
			for (int i = 0; i < s.Length; i++)
			{
				if (stack.Count != 0 && (((char)stack.Peek() == '(' && s[i] == ')')
					|| ((char)stack.Peek() == '[' && s[i] == ']')
					|| ((char)stack.Peek() == '{' && s[i] == '}')))
					stack.Pop();
				else
					stack.Push(s[i]);
			}

			return stack.Count == 0;
		}
	}
}
