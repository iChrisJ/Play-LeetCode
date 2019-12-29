using System.Collections.Generic;

namespace LeetCodeInCS._0349_Intersection_of_Two_Arrays
{
	public class Solution
	{
		public int[] Intersection(int[] nums1, int[] nums2)
		{
			if (nums1 == null || nums2 == null || nums1.Length * nums2.Length == 0)
				return new int[0];

			HashSet<int> set = new HashSet<int>();
			HashSet<int> ans = new HashSet<int>();
			for (int i = 0; i < nums1.Length; i++)
				set.Add(nums1[i]);

			for (int i = 0; i < nums2.Length; i++)
				if (set.Contains(nums2[i]))
					ans.Add(nums2[i]);

			int[] res = new int[ans.Count];
			ans.CopyTo(res);
			return res;
		}
	}
}
