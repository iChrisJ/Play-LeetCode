using System;
using System.Collections.Generic;

namespace CSharp._0703_Kth_Largest_Element_in_a_Stream
{
	public class KthLargest
	{
		private MinHeap minHeap;
		private int capacity;

		public KthLargest(int k, int[] nums)
		{
			if (k < 1 || nums.Length < k - 1)
				throw new Exception("Incorrect Parameters.");

			minHeap = new MinHeap(k);
			capacity = k;

			for (int i = 0; i < nums.Length; i++)
			{
				if (i < k)
					minHeap.Push(nums[i]);
				else if (i >= k && minHeap.Peek < nums[i])
					minHeap.Peek = nums[i];
			}
		}

		public int Add(int val)
		{
			if (minHeap.Count < capacity)
				minHeap.Push(val);
			else
			{
				if (minHeap.Peek < val)
					minHeap.Peek = val;
			}

			return minHeap.Peek;
		}

		private class MinHeap
		{
			private List<int> data;

			public int Peek
			{
				get
				{
					return data[0];
				}
				set
				{
					data[0] = value;
					ShiftDown(0);
				}
			}

			public int Count
			{
				get
				{
					return data.Count;
				}
			}

			public MinHeap()
			{
				data = new List<int>();
			}

			public MinHeap(int capacity)
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
				while (i - 1 >= 0 && data[i] < data[(i - 1) / 2])
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
					if (p + 1 < data.Count && data[p + 1] < data[p])
						p = p + 1;
					if (data[p] >= data[i])
						break;

					int temp = data[p];
					data[p] = data[i];
					data[i] = temp;
					i = p;
				}
			}
		}

		//static void Main()
		//{
		//	int k = 3;
		//	int[] arr = new int[] { 4, 5, 8, 2 };
		//	KthLargest kthLargest = new KthLargest(3, arr);
		//	kthLargest.Add(3);   // returns 4
		//	kthLargest.Add(5);   // returns 5
		//	kthLargest.Add(10);  // returns 5
		//	kthLargest.Add(9);   // returns 8
		//	kthLargest.Add(4);   // returns 8
		//}
	}
}
