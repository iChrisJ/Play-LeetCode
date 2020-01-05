using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0015_3Sum
{
	public class Solution
	{
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			HashSet<(int, int, int)> set = new HashSet<(int, int, int)>();

			Array.Sort<int>(nums);

			for (int i = 0; i < nums.Length - 1; i++)
			{
				int l = i + 1, r = nums.Length - 1;

				while (l < r)
				{
					if (nums[l] + nums[r] + nums[i] > 0)
						r--;
					else if (nums[l] + nums[r] + nums[i] < 0)
						l++;
					else
					{
						set.Add((nums[i], nums[l], nums[r]));
						l++;
						r--;

					}
				}
			}

			IList<IList<int>> res = new List<IList<int>>();
			foreach ((int, int, int) item in set)
				res.Add(new List<int>() { item.Item1, item.Item2, item.Item3 });
			return res;
		}
	}

	public class Solution2
	{
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			IList<IList<int>> res = new List<IList<int>>();
			if (nums == null || nums.Length <= 2)
				return res;

			Array.Sort<int>(nums);

			for (int i = 0; i < nums.Length - 2; i++)
			{
				int l = i + 1, r = nums.Length - 1;

				while (l < r)
				{
					int total = nums[i] + nums[l] + nums[r];
					if (total == 0)
					{
						res.Add(new List<int> { nums[i], nums[l], nums[r] });

						while (l < r && nums[l] == nums[l + 1])
							l++;
						while (l < r && nums[r] == nums[r - 1])
							r--;

						l++;
						r--;
					}
					else if (total < 0)
						l++;
					else
						r--;
				}

				while (i < nums.Length - 2 && nums[i] == nums[i + 1])
					i++;
			}

			return res;
		}
	}

	public class Solution3
	{
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			IList<IList<int>> res = new List<IList<int>>();
			if (nums == null || nums.Length <= 2)
				return res;

			Array.Sort<int>(nums);
			HashSet<(int, int, int)> resSet = new HashSet<(int, int, int)>();

			// If we can get the lower bound index of 0, then we can reduce the execution time.
			for (int i = 0; i < nums.Length - 2; i++)
			{
				for (int j = nums.Length - 1; j > i; j--)
				{
					int l = i + 1, r = j - 1;

					while (l <= r)
					{
						int mid = l + (r - l) / 2;
						int total = nums[i] + nums[mid] + nums[j];
						if (total > 0)
							r = mid - 1;
						else if (total < 0)
							l = mid + 1;
						else
						{
							resSet.Add((nums[i], nums[mid], nums[j]));
							break;
						}
					}
				}
			}

			foreach ((int, int, int) item in resSet)
				res.Add(new List<int> { item.Item1, item.Item2, item.Item3 });

			return res;
		}
	}
}
