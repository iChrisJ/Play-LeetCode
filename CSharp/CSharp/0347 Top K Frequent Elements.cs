using CSharp.Utilities;
using System.Collections.Generic;

namespace CSharp._0347_Top_K_Frequent_Elements
{
	public class Solution
	{
		public IList<int> TopKFrequent(int[] nums, int k)
		{
			Dictionary<int, int> freq = new Dictionary<int, int>();
			for ( int i = 0; i < nums.Length; i++)
			{
				if (freq.ContainsKey(nums[i]))
					freq[nums[i]]++;
				else
					freq.Add(nums[i], 1);
			}

			MinHeap<KeyValuePair<int, int>> minheap = new MinHeap<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((x, y) => { return x.Key - y.Key; }));
			foreach (var kv in freq)
			{
				if (minheap.Count < k)
					minheap.Insert(new KeyValuePair<int, int>(kv.Value, kv.Key));
				else if (kv.Value > minheap.Top().Key)
				{
					minheap.ExtractMin();
					minheap.Insert(new KeyValuePair<int, int>(kv.Value, kv.Key));
				}
			}

			int[] res = new int[minheap.Count];
			for (int i = res.Length - 1; i >= 0; i--)
				res[i] = minheap.ExtractMin().Value;

			return res;
		}

		//static void Main(string[] args)
		//{
		//	IList<int> aa = new Solution().TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3, 3, 3, 3 }, 2);
		//}
	}
}
