using System;
using System.Collections.Generic;

namespace CSharp._0120_Triangle
{
	public class Solution
	{
		public int MinimumTotal(IList<IList<int>> triangle)
		{
			if (triangle == null || triangle.Count == 0)
				return 0;

			for (int i = 1; i < triangle.Count; i++)
			{
				triangle[i][0] += triangle[i - 1][0];
				triangle[i][i] += triangle[i - 1][i - 1];
				for (int j = 1; j < i; j++)
					triangle[i][j] += Math.Min(triangle[i - 1][j - 1], triangle[i - 1][j]);
			}

			int res = int.MaxValue;
			for (int i = 0; i < triangle[triangle.Count - 1].Count; i++)
			{
				if (res > triangle[triangle.Count - 1][i])
					res = triangle[triangle.Count - 1][i];
			}
			return res;
		}
	}
}
