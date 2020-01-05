using LeetCodeInCS.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeInCS._0451_Sort_Characters_By_Frequency
{
	/// <summary>
	/// Array Sort
	/// </summary>
	public class Solution
	{
		public string FrequencySort(string s)
		{
			Dictionary<char, int> dict = new Dictionary<char, int>();
			foreach (char c in s)
			{
				if (dict.ContainsKey(c))
					dict[c]++;
				else
					dict.Add(c, 1);
			}

			char[] cArr = s.ToCharArray();
			Array.Sort<char>(cArr,
				(x, y) =>
				{
					return dict[y] == dict[x] ? y - x : dict[y] - dict[x];
				});
			return new string(cArr);
		}
	}

	/// <summary>
	/// Priority Queue (Heap)
	/// </summary>
	public class Solution2
	{
		public string FrequencySort(string s)
		{
			if (s == null || s.Length == 0)
				return s;

			Dictionary<char, int> dict = new Dictionary<char, int>();
			foreach (char c in s)
			{
				if (dict.ContainsKey(c))
					dict[c]++;
				else
					dict.Add(c, 1);
			}

			PriorityQueue<(StringBuilder, int)> pq = new PriorityQueue<(StringBuilder, int)>(
				Comparer<(StringBuilder, int)>.Create(
					(x, y) =>
					{
						return x.Item2 > y.Item2 ? 1 : x.Item2 < y.Item2 ? -1 : 0;
					}
				));

			foreach (var kv in dict)
				pq.Enqueue(
					(new StringBuilder().Append(kv.Key, kv.Value),
					kv.Value));

			StringBuilder res = new StringBuilder();
			while (pq.Count > 0)
				res.Append(pq.Dequeue().Item1);

			return res.ToString();
		}
	}

	/// <summary>
	/// Bucket Sort
	/// </summary>
	public class Solution3
	{
		public string FrequencySort(string s)
		{
			if (s == null || s.Length == 0)
				return s;

			Dictionary<char, int> dict = new Dictionary<char, int>();
			foreach (char c in s)
			{
				if (dict.ContainsKey(c))
					dict[c]++;
				else
					dict.Add(c, 1);
			}

			StringBuilder[] buckets = new StringBuilder[s.Length + 1];
			foreach (var kv in dict)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(kv.Key, kv.Value);
				buckets[kv.Value] = buckets[kv.Value] == null ? sb : buckets[kv.Value].Append(sb);
			}

			StringBuilder res = new StringBuilder();
			for (int i = buckets.Length - 1; i >= 0; i--)
			{
				if (buckets[i] != null && buckets[i].Length != 0)
					res.Append(buckets[i]);
			}

			return res.ToString();
		}
	}
}
