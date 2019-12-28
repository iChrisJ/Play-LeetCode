using System;

namespace LeetCodeInCS._0480_Sliding_Window_Median
{
	public class Solution
	{
		public double[] MedianSlidingWindow(int[] nums, int k)
		{
			if (nums == null || nums.Length * k == 0)
				return new double[0];

			int[] range = new int[k];
			int l = 0, r = 0;
			double[] medians = new double[nums.Length - k + 1];

			while (r < nums.Length)
			{
				range[r % k] = nums[r];
				r++;

				if (r - l == k)
				{
					int[] sorted = new int[k];
					Array.Copy(range, sorted, k);
					Array.Sort<int>(sorted);
					medians[l] = k % 2 == 0 ? sorted[k / 2] / 2.0 + sorted[k / 2 - 1] / 2.0 : sorted[k / 2];
					l++;
				}
			}
			return medians;
		}
	}

	public class Solution2
	{
		public double[] MedianSlidingWindow(int[] nums, int k)
		{
			if (nums == null || nums.Length * k == 0)
				return new double[0];

			int[] range = new int[k];
			double[] medians = new double[nums.Length - k + 1];

			for (int i = 0; i < k; i++)
				range[i] = nums[i];

			for (int i = k; i <= nums.Length; i++)
			{
				medians[i - k] = k % 2 == 0
						? GetKthItem(range, 0, range.Length - 1, k / 2) / 2.0 + GetKthItem(range, 0, range.Length - 1, k / 2 - 1) / 2.0
						: GetKthItem(range, 0, range.Length - 1, k / 2);
				if (i == nums.Length)
					break;

				for (int j = 0; j < k; j++)
				{
					if (range[j] == nums[i - k])
						range[j] = nums[i];
				}
			}
			return medians;
		}

		private int GetKthItem(int[] nums, int l, int r, int k)
		{
			if (l == r)
				return nums[l];

			int p = Partition(nums, l, r);

			if (p > k)
				return GetKthItem(nums, l, p - 1, k);
			else if (p < k)
				return GetKthItem(nums, p + 1, r, k);
			else
				return nums[p];
		}

		private int Partition(int[] nums, int l, int r)
		{
			int pos = l;
			int temp;
			for (int i = l + 1; i <= r; i++)
			{
				if (nums[i] <= nums[l])
				{
					temp = nums[++pos];
					nums[pos] = nums[i];
					nums[i] = temp;
				}
			}

			temp = nums[pos];
			nums[pos] = nums[l];
			nums[l] = temp;

			return pos;
		}
	}

	public class Solution3
	{
		public double[] MedianSlidingWindow(int[] nums, int k)
		{
			if (nums == null || nums.Length * k == 0)
				return new double[0];

			int[] range = new int[k];
			double[] medians = new double[nums.Length - k + 1];

			for (int i = 0; i < k; i++)
				range[i] = nums[i];
			Array.Sort<int>(range);

			for (int i = k; i <= nums.Length; i++)
			{
				medians[i - k] = range[k / 2] / 2.0 + range[(k - 1) / 2] / 2.0;
				if (i == nums.Length)
					break;

				Remove(range, nums[i - k]);
				Insert(range, nums[i]);
			}
			return medians;
		}

		// Insert val into window, window[k - 1] is empty before inseration
		private void Insert(int[] window, int val)
		{
			int i = 0;
			while (i < window.Length - 1 && val > window[i]) ++i;
			int j = window.Length - 1;
			while (j > i)
				window[j] = window[--j];
			window[j] = val;
		}

		// Remove val from window and shrink it.
		private void Remove(int[] window, int val)
		{
			int i = 0;
			while (i < window.Length && val != window[i])
				++i;
			while (i < window.Length - 1)
				window[i] = window[++i];
		}
	}
}
