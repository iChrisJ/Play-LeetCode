using System.Collections.Generic;

namespace LeetCodeInCS._0150_Evaluate_Reverse_Polish_Notation
{
	public class Solution
	{
		public int EvalRPN(string[] tokens)
		{
			if (tokens == null || tokens.Length == 0)
				return 0;

			Stack<int> stack = new Stack<int>();
			foreach (string token in tokens)
			{
				int sec, frst;
				switch (token)
				{
					case "+":
						sec = stack.Pop();
						frst = stack.Pop();
						stack.Push(frst + sec);
						break;
					case "-":
						sec = stack.Pop();
						frst = stack.Pop();
						stack.Push(frst - sec);
						break;
					case "*":
						sec = stack.Pop();
						frst = stack.Pop();
						stack.Push(frst * sec);
						break;
					case "/":
						sec = stack.Pop();
						frst = stack.Pop();
						stack.Push(frst / sec);
						break;
					default:
						stack.Push(int.Parse(token));
						break;
				}
			}
			return stack.Peek();
		}
	}
}
