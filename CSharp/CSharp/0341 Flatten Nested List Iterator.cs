using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0341_Flatten_Nested_List_Iterator
{
	// This is the interface that allows for creating nested lists.
	// You should not implement it, or speculate about its implementation
	public interface NestedInteger
	{
		// @return true if this NestedInteger holds a single integer, rather than a nested list.
		bool IsInteger();

		// @return the single integer that this NestedInteger holds, if it holds a single integer
		// Return null if this NestedInteger holds a nested list
		int GetInteger();

		// @return the nested list that this NestedInteger holds, if it holds a nested list
		// Return null if this NestedInteger holds a single integer
		IList<NestedInteger> GetList();
	}

	public class NestedIterator
	{
		private Queue<int> queue;

		public NestedIterator(IList<NestedInteger> nestedList)
		{
			queue = new Queue<int>();
			ConvertListToQueue(nestedList, queue);
		}

		private void ConvertListToQueue(IList<NestedInteger> nestedList, Queue<int> queue)
		{
			foreach (NestedInteger nested_val in nestedList)
			{
				if (nested_val.IsInteger())
					queue.Enqueue(nested_val.GetInteger());
				else
					ConvertListToQueue(nested_val.GetList(), queue);
			}
		}

		public bool HasNext()
		{
			return queue.Count > 0;
		}

		public int Next()
		{
			if (HasNext())
				return queue.Dequeue();
			throw new InvalidOperationException("The NextedInteger list is empty.");
		}
	}

	/**
	 * Your NestedIterator will be called like this:
	 * NestedIterator i = new NestedIterator(nestedList);
	 * while (i.HasNext()) v[f()] = i.Next();
	 */
}
