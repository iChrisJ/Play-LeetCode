using System.Collections.Generic;

namespace CSharp._0118_Pascal_s_Triangle
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

		//public static void Main(string[] args)
		//{
		//	var a = new Solution().Generate(5);
		//}
	}
}
