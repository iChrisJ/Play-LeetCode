using System.Collections.Generic;

namespace CSharp._0225_Implement_Stack_using_Queues
{
	public class MyStack
	{
		private Queue<int> queue;
		/** Initialize your data structure here. */
		public MyStack()
		{
			queue = new Queue<int>();
		}

		/** Push element x onto stack. */
		public void Push(int x)
		{
			Queue<int> auxQ = new Queue<int>(queue.Count + 1);
			auxQ.Enqueue(x);
			while (queue.Count != 0)
				auxQ.Enqueue(queue.Dequeue());

			while (auxQ.Count != 0)
				queue.Enqueue(auxQ.Dequeue());
		}

		/** Removes the element on top of the stack and returns that element. */
		public int Pop()
		{
			return queue.Dequeue();
		}

		/** Get the top element. */
		public int Top()
		{
			return queue.Peek();
		}

		/** Returns whether the stack is empty. */
		public bool Empty()
		{
			return queue.Count == 0;
		}
	}
}
