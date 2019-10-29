using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0150_Evaluate_Reverse_Polish_Notation
{
	public class Solution
	{
		public int EvalRPN(string[] tokens)
		{
			Stack<int> nums = new Stack<int>();

			for (int i = 0; i < tokens.Length; i++)
			{
				int num;
				char oper;
				if (int.TryParse(tokens[i], out num))
					nums.Push(num);
				else if (char.TryParse(tokens[i], out oper))
				{
					if (nums.Count <= 1)
						throw new InvalidOperationException();

					int second = nums.Pop();
					int first = nums.Pop();

					int val = Calculate(first, second, oper);
					nums.Push(val);
				}
			}

			if (nums.Count == 1)
				return nums.Pop();
			throw new InvalidOperationException();
		}

		private int Calculate(int first, int second, char oper)
		{
			switch (oper)
			{
				case '+':
					return first + second;
				case '-':
					return first - second;
				case '*':
					return first * second;
				case '/':
					if (second == 0)
						throw new DivideByZeroException("Cannot be zero");
					return first / second;
			}
			throw new InvalidOperationException("Can't be calculated here.");
		}
	}
}
