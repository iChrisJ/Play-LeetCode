using System;
using System.Collections.Generic;

namespace LeetCodeInCS._0835_Image_Overlap
{
	public class Solution
	{
		public int LargestOverlap(int[][] A, int[][] B)
		{
			List<(int, int)> la = new List<(int, int)>();
			List<(int, int)> lb = new List<(int, int)>();
			for (int i = 0; i < A.Length; i++)
			{
				for (int j = 0; j < A[0].Length; j++)
				{
					if (A[i][j] == 1)
						la.Add((i, j));
					if (B[i][j] == 1)
						lb.Add((i, j));
				}
			}

			Dictionary<(int, int), int> dict = new Dictionary<(int, int), int>();

			for (int i = 0; i < la.Count; i++)
			{
				for (int j = 0; j < lb.Count; j++)
				{
					int x = la[i].Item1 - lb[j].Item1;
					int y = la[i].Item2 - lb[j].Item2;

					if (dict.ContainsKey((x, y)))
						dict[(x, y)]++;
					else
						dict.Add((x, y), 1);
				}
			}

			int max = 0;
			foreach (var item in dict)
				max = Math.Max(max, item.Value);
			return max;
		}
	}
}
