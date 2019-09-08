using System.Collections.Generic;

namespace CSharp._0232_Implement_Queue_using_Stacks
{
	public class MyQueue
	{
		private Stack<int> input;
		private Stack<int> output;
		/** Initialize your data structure here. */
		public MyQueue()
		{
			input = new Stack<int>();
			output = new Stack<int>();
		}

		/** Push element x to the back of queue. */
		public void Push(int x)
		{
			input.Push(x);
		}

		/** Removes the element from in front of queue and returns that element. */
		public int Pop()
		{
			StackTransfer();
			return output.Pop();
		}

		/** Get the front element. */
		public int Peek()
		{
			StackTransfer();
			return output.Peek();
		}

		/** Returns whether the queue is empty. */
		public bool Empty()
		{
			return input.Count == 0 && output.Count == 0;
		}

		private void StackTransfer()
		{
			if (output.Count == 0)
			{
				while (input.Count != 0)
					output.Push(input.Pop());
			}
		}
	}
}
