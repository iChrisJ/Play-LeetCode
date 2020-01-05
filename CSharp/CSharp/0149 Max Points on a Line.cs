using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0149_Max_Points_on_a_Line
{
	public class Solution
	{
		public int MaxPoints(int[][] points)
		{
			if (points == null || points.Length == 0)
				return 0;

			if (points.Length <= 2)
				return points.Length;

			int res = 2;
			for (int i = 0; i < points.Length - 1; i++)
			{
				Dictionary<(int, int), int> dict = new Dictionary<(int, int), int>();
				int dup = 1;
				int maxCount = 0;
				for (int j = i + 1; j < points.Length; j++)
				{
					if (points[i][0] == points[j][0] && points[i][1] == points[j][1])
						dup++;
					else
					{
						(int, int) slope = GetSlope(points[j], points[i]);

						if (dict.ContainsKey(slope))
							dict[slope]++;
						else
							dict.Add(slope, 1);
						maxCount = Math.Max(maxCount, dict[slope]);
					}
				}

				res = Math.Max(res, maxCount + dup);
			}
			return res;
		}

		private (int, int) GetSlope(int[] pb, int[] pa)
		{
			int dy = pb[1] - pa[1];
			int dx = pb[0] - pa[0];

			// vertical line
			if (dx == 0)
				return (0, pa[0]);

			// horizontal line
			if (dy == 0)
				return (pa[1], 0);

			int d = GetGCD(dy, dx);
			return (dy / d, dx / d);
		}

		// 辗转相除法获取最大公约数
		private int GetGCD(int m, int n)
		{
			return n == 0 ? m : GetGCD(n, m % n);
		}
	}
}
