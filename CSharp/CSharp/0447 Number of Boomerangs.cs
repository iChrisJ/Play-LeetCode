using System.Collections.Generic;

namespace CSharp._0447_Number_of_Boomerangs
{
	public class Solution
	{
		public int NumberOfBoomerangs(int[][] points)
		{
			int res = 0;
			for (int i = 0; i < points.Length; i++)
			{
				Dictionary<int, int> record = new Dictionary<int, int>();
				for (int j = 0; j < points.Length; j++)
				{
					if (i != j)
					{
						int dis = Distance(points[i], points[j]);

						if (record.ContainsKey(dis))
							record[dis] += 1;
						else
							record.Add(dis, 1);
					}
				}

				foreach (var item in record)
				{
					if (item.Value > 1) // can be removed
						res += item.Value * (item.Value - 1);
				}
			}
			return res;
		}

		private int Distance(int[] pa, int[] pb)
		{
			return (pa[0] - pb[0]) * (pa[0] - pb[0]) + (pa[1] - pb[1]) * (pa[1] - pb[1]);
		}
	}
}
