using LeetCodeInCS.Utilities;
using System.Collections.Generic;

namespace LeetCodeInCS._0347_Top_K_Frequent_Elements
{
	public class Solution
	{
		public IList<int> TopKFrequent(int[] nums, int k)
		{
			Dictionary<int, int> freq = new Dictionary<int, int>();
			foreach (int num in nums)
			{
				if (freq.ContainsKey(num))
					freq[num]++;
				else
					freq.Add(num, 1);
			}

			PriorityQueue<(int, int)> queue = new PriorityQueue<(int, int)>
				(Comparer<(int, int)>.Create((x, y) => { return y.Item2 - x.Item2; }));

			foreach (KeyValuePair<int, int> kv in freq)
			{
				if (queue.Count < k)
					queue.Enqueue((kv.Key, kv.Value));
				else
				{
					if (kv.Value > queue.Peek().Item2)
					{
						queue.Dequeue();
						queue.Enqueue((kv.Key, kv.Value));
					}
				}
			}

			IList<int> res = new List<int>();
			while (queue.Count > 0)
				res.Add(queue.Dequeue().Item1);
			return res;
		}
	}
}
