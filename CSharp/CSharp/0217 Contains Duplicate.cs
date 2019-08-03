using System.Collections.Generic;

namespace CSharp._0217_Contains_Duplicate
{
	public class Solution
	{
		public bool ContainsDuplicate(int[] nums)
		{
			HashSet<int> set = new HashSet<int>();
			foreach (int num in nums)
			{
				if (set.Contains(num))
					return true;
				set.Add(num);
			}
			return false;
		}

		//public static void Main(string[] args)
		//{
		//	bool a = new Solution().ContainsDuplicate(new int[] { 1, 2, 3, 1 });
		//}
	}
}
