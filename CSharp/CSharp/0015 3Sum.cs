using System;
using System.Collections.Generic;

namespace CSharp._0015_3Sum
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
}
