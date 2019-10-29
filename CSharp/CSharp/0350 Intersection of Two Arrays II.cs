using System.Collections.Generic;

namespace LeetCodeInCS._0350_Intersection_of_Two_Arrays_II
{
	public class Solution
	{
		public int[] Intersect(int[] nums1, int[] nums2)
		{
			Dictionary<int, int> records = new Dictionary<int, int>();
			for (int i = 0; i < nums1.Length; i++)
			{
				if (records.ContainsKey(nums1[i]))
					records[nums1[i]]++;
				else
					records.Add(nums1[i], 1);
			}
			List<int> resList = new List<int>();
			for (int i = 0; i < nums2.Length; i++)
			{
				if (records.ContainsKey(nums2[i]) && records[nums2[i]] > 0)
				{
					resList.Add(nums2[i]);
					records[nums2[i]]--;
				}
			}

			return resList.ToArray();
		}
	}
}
