using System.Collections.Generic;

namespace CSharp._0119_Pascal_s_Triangle_II
{
	public class Solution
	{
		/// Recursive
		public IList<int> GetRow(int rowIndex)
		{
			if (rowIndex == 0)
				return new List<int> { 1 };

			IList<int> line = GetRow(rowIndex - 1);
			IList<int> res = new List<int>();
			for (int i = 0; i <= rowIndex; i++)
			{
				if (i == 0 || i == rowIndex)
					res.Add(1);
				else
					res.Add(line[i - 1] + line[i]);
			}
			return res;
		}
	}

	public class Solution2
	{
		// Iteration 
		public IList<int> GetRow(int rowIndex)
		{
			IList<IList<int>> res = new List<IList<int>>(2) { new List<int>(1), new List<int>(2) };
			int i = 0;
			while (i <= rowIndex)
			{
				IList<int> curLine = new List<int>(i + 1);
				for (int j = 0; j <= i; j++)
				{
					if (j == 0 || j == i)
						curLine.Add(1);
					else
						curLine.Add(res[(i - 1) % 2][j - 1] + res[(i - 1) % 2][j]);
				}

				res[i % 2] = curLine;
				i++;
			}

			return res[rowIndex % 2];
		}
	}
}
