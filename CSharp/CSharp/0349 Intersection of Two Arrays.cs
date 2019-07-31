using System.Collections.Generic;

namespace CSharp._0349_Intersection_of_Two_Arrays
{
	public class Solution
	{
		public int[] Intersection(int[] nums1, int[] nums2)
		{
			HashSet<int> set1 = new HashSet<int>(nums1);

			HashSet<int> res = new HashSet<int>();
			for (int i = 0; i < nums2.Length; i++)
			{
				if (set1.Contains(nums2[i]))
					res.Add(nums2[i]);
			}

			int[] ret = new int[res.Count];
			res.CopyTo(ret);
			return ret;
		}
	}
}
