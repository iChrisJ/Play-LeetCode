using System.Collections.Generic;

namespace CSharp._0119_Pascal_s_Triangle_II
{
	public class Solution
	{
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

		//public static void Main(string[] args)
		//{
		//	var a = new Solution().GetRow(4);
		//}
	}
}
