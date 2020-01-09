using System.Collections.Generic;

namespace LeetCodeInCS._0155_Min_Stack
{
	public class MinStack
	{
		Stack<int> data;
		Stack<int> mins;

		public MinStack()
		{
			data = new Stack<int>();
			mins = new Stack<int>();
		}

		public void Push(int x)
		{
			data.Push(x);
			if (mins.Count == 0 || mins.Peek() >= x)
				mins.Push(x);
		}

		public void Pop()
		{
			int top = data.Pop();

			if (top == mins.Peek())
				mins.Pop();
		}

		public int Top()
		{
			return data.Peek();
		}

		public int GetMin()
		{
			return mins.Peek();
		}
	}
}
