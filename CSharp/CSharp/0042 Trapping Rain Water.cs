using System;

namespace LeetCodeInCS._0042_Trapping_Rain_Water
{
	public class Solution
	{
		public int Trap(int[] height)
		{
			if (height == null || height.Length <= 2)
				return 0;

			int res = 0;
			for (int i = 0; i < height.Length; i++)
			{
				int max_left = 0;
				for (int l = i; l >= 0; l--)
					max_left = Math.Max(max_left, height[l]);

				int max_right = 0;
				for (int r = i; r < height.Length; r++)
					max_right = Math.Max(max_right, height[r]);
				res += Math.Min(max_left, max_right) - height[i];
			}
			return res;
		}
	}

	/// <summary>
	/// Store left_most and right_most of each height in extra arrays.
	/// </summary>
	public class Solution2
	{
		public int Trap(int[] height)
		{
			if (height == null || height.Length <= 2)
				return 0;

			int[] max_left = new int[height.Length];
			max_left[0] = height[0];
			for (int i = 1; i < height.Length; i++)
				max_left[i] = Math.Max(max_left[i - 1], height[i]);

			int[] max_right = new int[height.Length];
			max_right[height.Length - 1] = height[height.Length - 1];
			for (int i = height.Length - 2; i >= 0; i--)
				max_right[i] = Math.Max(max_right[i + 1], height[i]);

			int res = 0;
			for (int i = 0; i < height.Length; i++)
				res += Math.Min(max_left[i], max_right[i]) - height[i];
			return res;
		}
	}


	/// <summary>
	/// Two Points
	/// </summary>
	public class Solution3
	{
		public int Trap(int[] height)
		{
			if (height == null || height.Length <= 2)
				return 0;

			int l = 0, r = height.Length - 1;
			int lMost = 0, rMost = 0;
			int res = 0;

			while (l < r)
			{
				if (height[l] <= height[r])
				{
					if (lMost < height[l])
						lMost = height[l];
					else
						res += lMost - height[l];
					l++;
				}
				else
				{
					if (rMost < height[r])
						rMost = height[r];
					else
						res += rMost - height[r];
					r--;
				}
			}
			return res;
		}
	}
}
