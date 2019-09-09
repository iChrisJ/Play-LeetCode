using System;
using System.Collections.Generic;

namespace CSharp._0239_Sliding_Window_Maximum
{

	public class Solution
	{
		public int[] MaxSlidingWindow(int[] nums, int k)
		{
			if (nums == null || nums.Length < k)
				throw new Exception("Incorrect parameters.");

			if (nums.Length == 0 || k <= 0)
				return new int[0];

			LinkedList<int> queue = new LinkedList<int>();
			int[] res = new int[nums.Length - k + 1];

			for (int i = 0; i < k - 1; i++)
			{
				while (queue.Count != 0 && queue.First.Value < nums[i])
					queue.RemoveFirst();
				queue.AddLast(nums[i]);
			}

			for (int i = k - 1; i < nums.Length; i++)
			{
				while ((queue.Count != 0 && (queue.First.Value < nums[i] || queue.First.Value < GetMaxValue(queue))) || queue.Count == k)
					queue.RemoveFirst();
				queue.AddLast(nums[i]);
				res[i - k + 1] = queue.First.Value;
			}
			return res;
		}

		private int GetMaxValue(LinkedList<int> queue)
		{
			if (queue == null || queue.Count == 0)
				return int.MinValue;
			int res = queue.First.Value;
			LinkedListNode<int> cur = queue.First;
			while (cur != null)
			{
				if (cur.Value > res)
					res = cur.Value;
				cur = cur.Next;
			}
			return res;
		}
	}

	public class Solution2
	{
		// TODO
		public int[] MaxSlidingWindow(int[] nums, int k)
		{
			if (nums == null || nums.Length < k)
				throw new Exception("Incorrect parameters.");

			if (nums.Length == 0 || k <= 0)
				return new int[0];

			throw new NotImplementedException();
		}

		private class MaxHeap
		{
			private List<int> data;

			public MaxHeap()
			{
				data = new List<int>();
			}

			public MaxHeap(int capacity)
			{
				data = new List<int>(capacity);
			}

			public void Push(int item)
			{
				data.Add(item);
				ShiftUp(data.Count - 1);
			}

			private void ShiftUp(int i)
			{
				while (i - 1 >= 0 && data[i] > data[(i - 1) / 2])
				{
					int temp = data[i];
					data[i] = data[(i - 1) / 2];
					data[(i - 1) / 2] = temp;
					i = (i - 1) / 2;
				}
			}

			public int Pop()
			{
				int res = data[0];
				data[0] = data[data.Count - 1];
				data.RemoveAt(data.Count - 1);
				ShiftDown(0);

				return res;
			}

			private void ShiftDown(int i)
			{
				while (2 * i + 1 < data.Count)
				{
					int p = 2 * i + 1;
					if (p + 1 < data.Count && data[p + 1] > data[p])
						p = p + 1;
					if (data[p] >= data[i])
						break;

					int temp = data[p];
					data[p] = data[i];
					data[i] = i;
					i = p;
				}
			}
		}
	}
}
