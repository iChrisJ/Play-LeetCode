using System;

namespace LeetCodeInCS._0004_Median_of_Two_Sorted_Arrays
{
	public class Solution
	{
		public double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			int m = nums1.Length, n = nums2.Length;
			if (m > n)
				return FindMedianSortedArrays(nums2, nums1);

			int imin = 0, imax = m;

			while (imin <= imax)
			{
				int i = (imin + imax) / 2;
				int j = (m + n + 1) / 2 - i;

				if (j > 0 && i < m && nums2[j - 1] > nums1[i])
					imin = i + 1;
				else if (i > 0 && j < n && nums2[j] < nums1[i - 1])
					imax = i - 1;
				else
				{
					int max_of_left = 0;
					if (i == 0)
						max_of_left = nums2[j - 1];
					else if (j == 0)
						max_of_left = nums1[i - 1];
					else
						max_of_left = Math.Max(nums1[i - 1], nums2[j - 1]);

					if ((m + n) % 2 == 1)
						return max_of_left;

					int min_of_right = 0;
					if (i == m)
						min_of_right = nums2[j];
					else if (j == n)
						min_of_right = nums1[i];
					else
						min_of_right = Math.Min(nums1[i], nums2[j]);

					return (min_of_right + max_of_left) / 2.0;
				}
			}

			return 0;
		}
	}
}
