﻿namespace CSharp._0088_Merge_Sorted_Array
{
	public class Solution
	{
		public void Merge(int[] nums1, int m, int[] nums2, int n)
		{
			int i = m - 1, j = n - 1;
			for (int k = m + n - 1; k >= 0; k--)
			{
				if (i < 0)
				{
					nums1[k] = nums2[j];
					j--;
				}
				else if (j < 0)
				{
					nums1[k] = nums1[i];
					i--;
				}
				else if (nums1[i] > nums2[j])
				{
					nums1[k] = nums1[i];
					i--;
				}
				else //nums1[i] <= nums2[j]
				{
					nums1[k] = nums2[j];
					j--;
				}
			}
		}
	}
}
