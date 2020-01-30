using System.Collections.Generic;

namespace LeetCodeInCS._0118_Pascal_s_Triangle
{
	public class Solution
	{
		public IList<IList<int>> Generate(int numRows)
		{
			IList<IList<int>> res = new List<IList<int>>();
			int i = 1;
			while (i <= numRows)
			{
				IList<int> line = new List<int>();
				for (int j = 0; j < i; j++)
				{
					if (j == 0 || j == i - 1)
						line.Add(1);
					else
						line.Add(res[i - 1 - 1][j - 1] + res[i - 1 - 1][j]);
				}
				res.Add(line);
				i++;
			}
			return res;
		}
	}

	public class Solution2
	{
		public IList<IList<int>> Generate(int numRows)
		{
			IList<IList<int>> res = new List<IList<int>>();
			if (numRows <= 0)
				return res;

			Generate(res, numRows - 1);
			return res;
		}

		private void Generate(IList<IList<int>> result, int rowIndex)
		{
			if (rowIndex == 0)
				result.Add(new List<int> { 1 });
			else
			{
				Generate(result, rowIndex - 1);
				IList<int> line = new List<int>(rowIndex + 1);
				for (int i = 0; i <= rowIndex; i++)
				{
					if (i == 0 || i == rowIndex)
						line.Add(1);
					else
						line.Add(result[rowIndex - 1][i - 1] + result[rowIndex - 1][i]);
				}
				result.Add(line);
			}
		}
	}
}
